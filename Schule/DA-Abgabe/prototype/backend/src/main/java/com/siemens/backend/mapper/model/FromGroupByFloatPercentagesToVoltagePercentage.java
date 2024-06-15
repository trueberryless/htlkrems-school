package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.dashboard.VoltagePercentage;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.valueTypes.GroupByDoublePercentage;
import org.springframework.stereotype.Component;

@Component
public class FromGroupByFloatPercentagesToVoltagePercentage implements FromMapper<GroupByDoublePercentage, VoltagePercentage> {
    @Override
    public VoltagePercentage mapFrom(GroupByDoublePercentage object) {
        return VoltagePercentage.builder()
                .voltage(object.getKey())
                .percentage(object.getPercentage())
                .build();

    }
}
