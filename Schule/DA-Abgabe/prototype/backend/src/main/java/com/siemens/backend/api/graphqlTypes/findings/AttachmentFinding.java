package com.siemens.backend.api.graphqlTypes.findings;

import com.siemens.backend.api.graphqlTypes.ModelObjectInfo;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

@Data
@SuperBuilder
@NoArgsConstructor
@AllArgsConstructor
public class AttachmentFinding extends Finding {
    ModelObjectInfo referencedNode;
    ModelObjectInfo referencedEquipment;
}

