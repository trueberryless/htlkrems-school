package com.siemens.backend.mapper.gnaTransferObjects;

import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelObjectType;
import com.siemens.backend.model.gna.GnaModelObjectType;
import org.springframework.stereotype.Component;

@Component
public class FromGnaModelObjectTypeToModelObjectType implements FromMapper<GnaModelObjectType, ModelObjectType> {
    @Override
    public ModelObjectType mapFrom(GnaModelObjectType object) {
        return switch (object) {
            case NODE -> ModelObjectType.NODE;
            case CONTAINER -> ModelObjectType.CONTAINER;
            case CONNECTED_EQUIPMENT -> ModelObjectType.CONNECTED_EQUIPMENT;
            case CONNECTING_EQUIPMENT -> ModelObjectType.CONNECTING_EQUIPMENT;
        };
    }
}
