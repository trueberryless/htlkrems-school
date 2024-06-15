package com.siemens.backend.api.graphqlTypes.modelObjects;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ModelObjectResult {
    List<ModelObject> result;
}
