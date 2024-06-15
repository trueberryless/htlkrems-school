package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.ContainerInfo;
import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import org.springframework.stereotype.Component;

@Component
public class FromModelObjectToModelObjectInfo implements FromMapper<ModelObject, ModelObjectInfo> {
    private final FromMapper<ModelObject, ContainerInfo> toContainerInfo;
    private final FromMapper<String, ClassNameInfo> toClassName;

    public FromModelObjectToModelObjectInfo(FromMapper<ModelObject, ContainerInfo> toContainerInfo, FromMapper<String, ClassNameInfo> toClassName) {
        this.toContainerInfo = toContainerInfo;
        this.toClassName = toClassName;
    }


    @Override
    public ModelObjectInfo mapFrom(ModelObject object) {
        if(object.getType() == ModelObjectType.CONTAINER)
            throw new RuntimeException("Cannot convert container to ModelObjectInfo");

        var modelObjectInfo = ModelObjectInfo.builder()
                        .guid(object.getGuid())
                        .name(object.getName())
                        .className(toClassName.mapFrom(object.getClassName()))
                        .build();

        if(object.getContainer().isEmpty()) {
            if(object.getContainerId().isPresent()) {
                modelObjectInfo.setContainer(
                        ContainerInfo.builder()
                            .guid(object.getContainerId().get())
                            .build()
                );
            }
           return  modelObjectInfo;
        }

        var container = object.getContainer().get();
        modelObjectInfo.setContainer(toContainerInfo.mapFrom(container));
        return modelObjectInfo;
    }
}
