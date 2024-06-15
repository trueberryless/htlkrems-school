package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import com.siemens.backend.api.graphqlTypes.findings.AttachmentFinding;
import com.siemens.backend.api.graphqlTypes.findings.EquipmentFinding;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import org.springframework.stereotype.Component;

@Component
public class FromModelFindingToAttachmentFinding implements FromMapper<ModelFinding, AttachmentFinding> {
    private final FromMapper<ModelObject,ModelObjectInfo> toModelObjectInfo;

    public FromModelFindingToAttachmentFinding(FromMapper<ModelObject, ModelObjectInfo> toModelObjectInfo) {
        this.toModelObjectInfo = toModelObjectInfo;
    }

    @Override
    public AttachmentFinding mapFrom(ModelFinding object) {
        var attachment = AttachmentFinding.builder()
                .guid(object.getGuid())
                .category(object.getCategory())
                .severity(object.getSeverity())
                .message(object.getMessage())
                .build();

        if(object.getReferencedEquipment().isPresent()) {
            var referenced = object.getReferencedEquipment().get();
            attachment.setReferencedEquipment(toModelObjectInfo.mapFrom(referenced));
        }
        else {
            attachment.setReferencedEquipment(
                    ModelObjectInfo.builder()
                            .guid(object.getReferencedEquipmentId().getId())
                            .build()
            );
        }

        if(object.getReferencedNode().isPresent()) {
            var referenced = object.getReferencedNode().get();
            attachment.setReferencedNode(toModelObjectInfo.mapFrom(referenced));
        }
        else {
            attachment.setReferencedNode(
                    ModelObjectInfo.builder()
                            .guid(object.getReferencedNodeId().getId())
                            .build()
            );
        }


        return attachment;
    }
}
