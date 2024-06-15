package com.siemens.backend.api.graphqlTypes.dashboard;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ClassPercentage {
    private ClassNameInfo className;
    private double percentage;

}
