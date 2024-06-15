package com.siemens.backend.model.repositories;

import com.siemens.backend.api.graphqlTypes.findings.FindingInput;
import com.siemens.backend.api.graphqlTypes.findings.SortDirection;
import com.siemens.backend.api.graphqlTypes.findings.SortFinding;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.queryBuilder.FindingsSearchQueryBuilder;
import com.siemens.backend.model.rowMapper.SearchFindingsRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.namedparam.NamedParameterJdbcTemplate;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ModelFindingSearchRepositoryImpl implements ModelFindingSearchRepository {
    private final NamedParameterJdbcTemplate jdbcTemplate;

    public ModelFindingSearchRepositoryImpl(NamedParameterJdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<ModelFinding> searchFindings(FindingInput searchInput) {
        var queryBuilder = new FindingsSearchQueryBuilder(searchInput);
        queryBuilder
                .SelectAll()
                .AddFrom()
                .AddFilter()
                .AddSorting()
                .AddLimitAndOffset();

        return jdbcTemplate.query(queryBuilder.getQuery(), queryBuilder.getParamMap(), new SearchFindingsRowMapper());
    }

    @Override
    public Integer searchFindingsCount(FindingInput searchInput) {
        var queryBuilder = new FindingsSearchQueryBuilder(searchInput);
        queryBuilder
                .SelectCount()
                .AddFrom()
                .AddFilter();

        return jdbcTemplate.queryForObject(queryBuilder.getQuery(), queryBuilder.getParamMap(), Integer.class);
    }
}
