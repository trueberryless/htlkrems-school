package com.siemens.backend.api.graphqlTypes.modelObjects;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor

public class Container {
    UUID guid;
    String name;
    String className;
    Float nominalVoltage;
    List<SubContainer> subContainer;
}
