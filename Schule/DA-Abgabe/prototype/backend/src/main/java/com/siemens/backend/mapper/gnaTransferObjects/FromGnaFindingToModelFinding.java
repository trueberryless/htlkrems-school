package com.siemens.backend.mapper.gnaTransferObjects;

import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.*;
import com.siemens.backend.model.gna.GnaFinding;
import org.springframework.data.jdbc.core.mapping.AggregateReference;
import org.springframework.stereotype.Component;

import java.util.UUID;

@Component
public class FromGnaFindingToModelFinding implements FromMapper<GnaFinding, ModelFinding> {

    @Override
    public ModelFinding mapFrom(GnaFinding object) {
        return switch (object) {
            //Container
            case GnaFinding obj when obj.getPowerSystemResourceGuid().isEmpty() && object.getNodeGuid().isEmpty() && object.getStaticDataModelObjectGuid().isPresent() ->
                    ModelFinding.builder()
                            .Guid(UUID.randomUUID())
                            .type(FindingType.CONTAINER)
                            .Severity(obj.getSeverity())
                            .Category(obj.getCategory())
                            .Message(obj.getAssembledMessage())
                            .ReferencedContainerId(AggregateReference.to(obj.getStaticDataModelObjectGuid().orElseThrow()))
                            .build();
            //Node
            case GnaFinding obj when obj.getPowerSystemResourceGuid().isEmpty() && object.getNodeGuid().isPresent() && object.getStaticDataModelObjectGuid().isPresent() ->
                    ModelFinding.builder()
                            .Guid(UUID.randomUUID())
                            .type(FindingType.NODE)
                            .Severity(obj.getSeverity())
                            .Category(obj.getCategory())
                            .Message(obj.getAssembledMessage())
                            .ReferencedNodeId(AggregateReference.to(obj.getNodeGuid().orElseThrow()))
                            .build();
            //Equipment
            case GnaFinding obj when obj.getPowerSystemResourceGuid().isPresent() && object.getNodeGuid().isEmpty() && object.getStaticDataModelObjectGuid().isPresent() ->
                    ModelFinding.builder()
                            .Guid(UUID.randomUUID())
                            .type(FindingType.EQUIPMENT)
                            .Severity(obj.getSeverity())
                            .Category(obj.getCategory())
                            .Message(obj.getAssembledMessage())
                            .ReferencedEquipmentId(AggregateReference.to(obj.getPowerSystemResourceGuid().orElseThrow()))
                            .build();
            //Attachment
            case GnaFinding obj when obj.getPowerSystemResourceGuid().isPresent() && object.getNodeGuid().isPresent() && object.getStaticDataModelObjectGuid().isEmpty() ->
                    ModelFinding.builder()
                            .Guid(UUID.randomUUID())
                            .type(FindingType.ATTACHMENT_FINDING)
                            .Severity(obj.getSeverity())
                            .Category(obj.getCategory())
                            .Message(obj.getAssembledMessage())
                            .ReferencedNodeId(AggregateReference.to(obj.getNodeGuid().orElseThrow()))
                            .ReferencedEquipmentId(AggregateReference.to(obj.getPowerSystemResourceGuid().orElseThrow()))
                            .build();
            default -> throw new RuntimeException("GnaFinding could not be mapped to Finding");
        };
    }
}
