package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.ContainerInfo;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import org.springframework.stereotype.Component;

@Component
public class FromModelObjectToContainerInfo implements FromMapper<ModelObject, ContainerInfo> {

    private final FromMapper<String, ClassNameInfo> toClassName;

    public FromModelObjectToContainerInfo(FromMapper<String, ClassNameInfo> toClassName) {
        this.toClassName = toClassName;
    }

    @Override
    public ContainerInfo mapFrom(ModelObject object) {
        if(object.getType() != ModelObjectType.CONTAINER)
            throw new RuntimeException("Cannot convert non Container ModelObject to ContainerInfo");
        return ContainerInfo.builder()
                .guid(object.getGuid())
                .className(toClassName.mapFrom(object.getClassName()))
                .name(object.getName())
                .nominalVoltage(object.getNominalVoltage().orElse(null))
                .build();
    }
}
