package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.dashboard.ClassPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.SeverityPercentage;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.valueTypes.GroupByPercentage;
import org.springframework.stereotype.Component;

@Component
public class FromGroupByPercentagesToClassPercentage implements FromMapper<GroupByPercentage, ClassPercentage> {
    private final FromMapper<String, ClassNameInfo> toClassName;

    public FromGroupByPercentagesToClassPercentage(FromMapper<String, ClassNameInfo> toClassName) {
        this.toClassName = toClassName;
    }

    @Override
    public ClassPercentage mapFrom(GroupByPercentage object) {
        return ClassPercentage.builder()
                .className(toClassName.mapFrom(object.getKey()))
                .percentage(object.getPercentage())
                .build();

    }
}
