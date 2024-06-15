package com.siemens.backend.model.repositories;

import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.queryBuilder.ModelObjectGraphQueryBuilder;
import com.siemens.backend.model.rowMapper.ModelObjectsWithContainerResultSetExtractorMapping;
import org.springframework.jdbc.core.namedparam.NamedParameterJdbcTemplate;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class GraphModelObjectRepositoryImpl implements GraphModelObjectRepository {
    private final NamedParameterJdbcTemplate jdbcTemplate;

    public GraphModelObjectRepositoryImpl(NamedParameterJdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<ModelObject> getGraphModelObjectsByGuids(List<UUID> guids) {
        if(guids == null || guids.isEmpty())
            return new ArrayList<>();

        var queryBuilder = new ModelObjectGraphQueryBuilder()
                .SelectAll()
                .AddFrom()
                .AddFilter(guids)
                .AddSorting();

        return jdbcTemplate.query(queryBuilder.getQuery(), queryBuilder.getParamMap(), new ModelObjectsWithContainerResultSetExtractorMapping());
    }
}
