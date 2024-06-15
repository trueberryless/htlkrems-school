package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ContainerInfo;
import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import com.siemens.backend.api.graphqlTypes.findings.ContainerFinding;
import com.siemens.backend.api.graphqlTypes.findings.EquipmentFinding;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import org.springframework.stereotype.Component;

@Component
public class FromModelFindingToContainerFinding implements FromMapper<ModelFinding, ContainerFinding> {
    private final FromMapper<ModelObject, ContainerInfo> toContainerInfo;

    public FromModelFindingToContainerFinding(FromMapper<ModelObject, ContainerInfo> toContainerInfo) {
        this.toContainerInfo = toContainerInfo;
    }

    @Override
    public ContainerFinding mapFrom(ModelFinding object) {
        var container = ContainerFinding.builder()
                .guid(object.getGuid())
                .category(object.getCategory())
                .severity(object.getSeverity())
                .message(object.getMessage())
                .build();

        if(object.getReferencedContainer().isEmpty()) {
            container.setReferencedContainer(ContainerInfo.builder()
                    .guid(object.getReferencedContainerId().getId())
                    .build());
            return container;
        }

        var referenced = object.getReferencedContainer().get();
        container.setReferencedContainer(toContainerInfo.mapFrom(referenced));

        return container;
    }
}
