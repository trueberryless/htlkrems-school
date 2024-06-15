package com.siemens.backend.api.graphqlTypes.modelObjects;

import lombok.*;

import java.util.List;
import java.util.Set;
import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ModelObjectInput {
    Set<UUID> ModelObjectsToLoad;
    Set<UUID> ModelObjectsToIgnore;
    Integer depth;
}
