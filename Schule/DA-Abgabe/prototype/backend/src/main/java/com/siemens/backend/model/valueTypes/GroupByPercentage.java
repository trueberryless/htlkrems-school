package com.siemens.backend.model.valueTypes;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class GroupByPercentage {
    private String key;
    private double percentage;
}
