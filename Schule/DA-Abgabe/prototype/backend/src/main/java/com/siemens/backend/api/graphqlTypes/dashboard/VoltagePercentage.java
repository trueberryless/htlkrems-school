package com.siemens.backend.api.graphqlTypes.dashboard;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class VoltagePercentage {
    private double voltage;
    private double percentage;
}
