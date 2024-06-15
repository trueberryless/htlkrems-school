package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.findings.*;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import org.springframework.stereotype.Component;

@Component
public class FromModelFindingToFinding  implements FromMapper<ModelFinding, Finding> {
    private final FromMapper<ModelFinding, EquipmentFinding> toEquipmentFinding;
    private final FromMapper<ModelFinding, ContainerFinding> toContainerFinding;
    private final FromMapper<ModelFinding, NodeFinding> toNodeFinding;
    private final FromMapper<ModelFinding, AttachmentFinding> toAttachmentFinding;

    public FromModelFindingToFinding(FromMapper<ModelFinding, EquipmentFinding> toEquipmentFinding, FromMapper<ModelFinding, ContainerFinding> toContainerFinding, FromMapper<ModelFinding, NodeFinding> toNodeFinding, FromMapper<ModelFinding, AttachmentFinding> toAttachmentFinding) {
        this.toEquipmentFinding = toEquipmentFinding;
        this.toContainerFinding = toContainerFinding;
        this.toNodeFinding = toNodeFinding;
        this.toAttachmentFinding = toAttachmentFinding;
    }

    @Override
    public Finding mapFrom(ModelFinding object) {
        return switch (object.getType()) {
            case NODE -> toNodeFinding.mapFrom(object);
            case CONTAINER -> toContainerFinding.mapFrom(object);
            case EQUIPMENT -> toEquipmentFinding.mapFrom(object);
            case ATTACHMENT_FINDING -> toAttachmentFinding.mapFrom(object);
        };
    }
}
