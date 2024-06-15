package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ContainerInfo;
import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import com.siemens.backend.api.graphqlTypes.findings.EquipmentFinding;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import org.springframework.stereotype.Component;

@Component
public class FromModelFindingToEquipmentFinding implements FromMapper<ModelFinding, EquipmentFinding> {
    private final FromMapper<ModelObject,ModelObjectInfo> toModelObjectInfo;

    public FromModelFindingToEquipmentFinding(FromMapper<ModelObject, ModelObjectInfo> toModelObjectInfo) {
        this.toModelObjectInfo = toModelObjectInfo;
    }

    @Override
    public EquipmentFinding mapFrom(ModelFinding object) {
        var equipment = EquipmentFinding.builder()
                .guid(object.getGuid())
                .category(object.getCategory())
                .severity(object.getSeverity())
                .message(object.getMessage())
                .build();

        if(object.getReferencedEquipment().isEmpty()) {
            equipment.setReferencedEquipment(
                    ModelObjectInfo.builder()
                            .guid(object.getReferencedEquipmentId().getId())
                            .build()
            );
            return equipment;
        }

        var referenced = object.getReferencedEquipment().get();
        equipment.setReferencedEquipment(toModelObjectInfo.mapFrom(referenced));

        return equipment;
    }
}
