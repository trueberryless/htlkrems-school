package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.dashboard.CategoryPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.ClassPercentage;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.valueTypes.GroupByPercentage;
import org.springframework.stereotype.Component;

@Component
public class FromGroupByPercentagesToCategoryPercentage implements FromMapper<GroupByPercentage, CategoryPercentage> {
    @Override
    public CategoryPercentage mapFrom(GroupByPercentage object) {
        return CategoryPercentage.builder()
                .category(object.getKey())
                .percentage(object.getPercentage())
                .build();

    }
}
