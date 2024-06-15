package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.ContainerInfo;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import com.siemens.backend.model.entities.Connection;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.HashSet;

@Component
public class FromModelObjectToModelObjectGraphQL implements FromMapper<ModelObject, com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject> {
    private final FromMapper<ModelObject, ContainerInfo> toContainerInfo;
    private final FromMapper<String, ClassNameInfo> toClassName;

    public FromModelObjectToModelObjectGraphQL(FromMapper<ModelObject, ContainerInfo> toContainerInfo, FromMapper<String, ClassNameInfo> toClassName) {
        this.toContainerInfo = toContainerInfo;
        this.toClassName = toClassName;
    }


    @Override
    public com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject mapFrom(ModelObject object) {
        if(object.getType() == ModelObjectType.CONTAINER)
            throw new RuntimeException("Cannot convert container to ModelObjectInfo");

        var modelObjectGraphQL = com.siemens.backend.api.graphqlTypes.modelObjects.ModelObject.builder()
                        .guid(object.getGuid())
                        .name(object.getName())
                        .className(toClassName.mapFrom(object.getClassName()))
                        .build();

        if(object.getContainer().isEmpty()) {
            if(object.getContainerId().isPresent()) {
                modelObjectGraphQL.setContainer(
                        ContainerInfo.builder()
                            .guid(object.getContainerId().get())
                            .build()
                );
            }
        }
        else {
            var container = object.getContainer().get();
            modelObjectGraphQL.setContainer(toContainerInfo.mapFrom(container));
        }

        modelObjectGraphQL.setConnections(object.getConnections().stream().map(this::toConnectionGraphQL).toList());

        return modelObjectGraphQL;
    }

    private com.siemens.backend.api.graphqlTypes.modelObjects.Connection toConnectionGraphQL(Connection connection) {
       return com.siemens.backend.api.graphqlTypes.modelObjects.Connection.builder()
               .guid(connection.getGuid())
               .modelObjectGuid(connection.getReferencing())
               .included(false)
               .build();
    }
}
