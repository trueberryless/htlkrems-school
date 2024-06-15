package com.siemens.backend.api.graphqlTypes;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor

public class ContainerInfo {
    UUID guid;
    String name;
    ClassNameInfo className;
    Double nominalVoltage;
}
