package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import com.siemens.backend.api.graphqlTypes.findings.EquipmentFinding;
import com.siemens.backend.api.graphqlTypes.findings.NodeFinding;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import org.springframework.stereotype.Component;

@Component
public class FromModelFindingToNodeFinding implements FromMapper<ModelFinding, NodeFinding> {
    private final FromMapper<ModelObject,ModelObjectInfo> toModelObjectInfo;

    public FromModelFindingToNodeFinding(FromMapper<ModelObject, ModelObjectInfo> toModelObjectInfo) {
        this.toModelObjectInfo = toModelObjectInfo;
    }

    @Override
    public NodeFinding mapFrom(ModelFinding object) {
        var node = NodeFinding.builder()
                .guid(object.getGuid())
                .category(object.getCategory())
                .severity(object.getSeverity())
                .message(object.getMessage())
                .build();

        if(object.getReferencedNode().isEmpty()) {
            node.setReferencedNode(
                    ModelObjectInfo.builder()
                            .guid(object.getReferencedNodeId().getId())
                            .build()
            );
            return node;
        }

        var referenced = object.getReferencedNode().get();
        node.setReferencedNode(toModelObjectInfo.mapFrom(referenced));

        return node;
    }
}
