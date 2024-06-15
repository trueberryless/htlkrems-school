package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.dashboard.SeverityPercentage;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.valueTypes.GroupByPercentage;
import org.springframework.stereotype.Component;

@Component
public class FromGroupByPercentagesToSeverityPercentage implements FromMapper<GroupByPercentage, SeverityPercentage> {
    @Override
    public SeverityPercentage mapFrom(GroupByPercentage object) {
        return SeverityPercentage.builder()
                .severity(object.getKey())
                .percentage(object.getPercentage())
                .build();

    }
}
