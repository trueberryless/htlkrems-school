package com.siemens.backend.api.graphqlTypes.modelObjects;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class SubContainer {
    UUID guid;
    Boolean included;
}
