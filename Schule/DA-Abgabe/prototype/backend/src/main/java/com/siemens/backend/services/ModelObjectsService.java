package com.siemens.backend.services;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.modelObjects.ModelObjectInput;
import com.siemens.backend.api.graphqlTypes.modelObjects.ModelObjectResult;
import com.siemens.backend.kafka.ModelObjectsListener;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.gna.GnaFinding;
import com.siemens.backend.model.gna.GnaModelObject;
import com.siemens.backend.model.gna.GnaUtil;
import com.siemens.backend.model.repositories.ModelFindingRepository;
import com.siemens.backend.model.repositories.ModelObjectDeleteRepository;
import com.siemens.backend.model.repositories.ModelObjectRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

import java.sql.SQLException;
import java.util.*;
import java.util.stream.Collectors;

@Service
public class ModelObjectsService {
    private final ModelObjectRepository modelObjectRepository;
    private final FromMapper<String, ClassNameInfo> toClassNameInfo;
    private final FromMapper<ModelObject, com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject> toModelObjectGraphQL;

    private final ModelObjectDeleteRepository modelObjectDeleteRepository;
    private final FromMapper<GnaModelObject, ModelObject> fromGnaToModelObject;

    private final Logger logger = LoggerFactory.getLogger(ModelObjectsService.class);


    public ModelObjectsService(ModelObjectRepository modelObjectRepository, FromMapper<String, ClassNameInfo> toClassNameInfo, FromMapper<ModelObject, com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject> toModelObjectGraphQL, ModelObjectDeleteRepository modelObjectDeleteRepository, FromMapper<GnaModelObject, ModelObject> fromGnaToModelObject) {
        this.modelObjectRepository = modelObjectRepository;
        this.toClassNameInfo = toClassNameInfo;
        this.toModelObjectGraphQL = toModelObjectGraphQL;
        this.modelObjectDeleteRepository = modelObjectDeleteRepository;
        this.fromGnaToModelObject = fromGnaToModelObject;
    }

    public List<ClassNameInfo> getClassesOfFindings() {
        var classes = modelObjectRepository.getDistinctClassNameOfFindingsForContainers();
        classes.addAll(modelObjectRepository.getDistinctClassNameOfFindingsForNonContainer());
        return classes.stream().map(toClassNameInfo::mapFrom).collect(Collectors.toSet()).stream().toList();
    }

    public List<Double> getVoltagesOfFindings() {
        return modelObjectRepository.getDistinctNominalVoltageOfFindings();
    }

    public ModelObjectResult getModelObjects(ModelObjectInput input) {
        var graph = new HashSet<com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject>();

        ResolveGraph(input.getModelObjectsToIgnore(), input.getModelObjectsToLoad(), graph, input.getDepth());

        return ModelObjectResult.builder()
                .result(graph.stream().toList())
                .build();
    }

    private void ResolveGraph(Set<UUID> alreadyLoaded, Set<UUID> toLoad, Set<com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject> graph, int depth) {
        if(depth <= 0 ) { return; }

        toLoad.removeAll(alreadyLoaded);
        if(toLoad.isEmpty()) { return; }

        var newModelObjects = modelObjectRepository.getGraphModelObjectsByGuids(toLoad.stream().toList());
        var newModelObjectsGraphQL = newModelObjects.stream().map(toModelObjectGraphQL::mapFrom).toList();

        alreadyLoaded.addAll(newModelObjectsGraphQL.stream().map(com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject::getGuid).toList());
        graph.addAll(newModelObjectsGraphQL);
        toLoad.clear();

        newModelObjectsGraphQL.forEach(m -> m.getConnections().forEach(c -> {
            if(alreadyLoaded.contains(c.getModelObjectGuid())) {
                c.setIncluded(true);
            }
            else if (depth - 1 > 0) {
                c.setIncluded(true);
                toLoad.add(c.getModelObjectGuid());
            }
        }));

        ResolveGraph(alreadyLoaded, toLoad, graph, depth - 1);
    }


    public void insertAndDeleteGnaModelObjects(List<GnaModelObject> gnaModelObjects) throws SQLException {
        var modelObjectsToRemove = gnaModelObjects.stream().filter(GnaUtil.getModelObjectHasOnlyGuid()).map(GnaModelObject::getGuid).toList();
        var modelObjects = gnaModelObjects.stream().filter(GnaUtil.getModelObjectHasOnlyGuid().negate()).map(fromGnaToModelObject::mapFrom).toList();
        insertAndDeleteModelObjects(modelObjects, modelObjectsToRemove);
    }
    public void insertAndDeleteModelObjects(List<ModelObject> modelObjectList) throws SQLException {
        insertAndDeleteModelObjects(modelObjectList, new ArrayList<>());
    }
    private void insertAndDeleteModelObjects(List<ModelObject> modelObjectList, List<UUID> uuidsToRemove) throws SQLException {
        var ids = new ArrayList<>(modelObjectList.stream().map(ModelObject::getGuid).toList());
        ids.addAll(uuidsToRemove);

        logger.info("inserting %s model objects".formatted(ids.size()));

        modelObjectDeleteRepository.deleteAllByIdArray(ids.toArray(new UUID[ids.size()]));
        modelObjectRepository.insertAllPartitioned(modelObjectList);
        logger.info("finished inserting %s model objects".formatted(ids.size()));
    }
}