package com.siemens.backend.api.graphqlTypes.dashboard;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class SeverityPercentage {
    private String severity;
    private double percentage;
}

