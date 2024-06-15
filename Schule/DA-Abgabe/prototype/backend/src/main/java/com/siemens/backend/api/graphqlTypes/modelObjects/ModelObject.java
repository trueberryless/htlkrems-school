package com.siemens.backend.api.graphqlTypes.modelObjects;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.ContainerInfo;
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

public class ModelObject {
    UUID guid;
    String name;
    ClassNameInfo className;
    ContainerInfo container;
    List<Connection> connections;
}
