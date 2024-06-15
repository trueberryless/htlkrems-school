package com.siemens.backend.model.repositories;

import org.apache.commons.collections4.ListUtils;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.data.jdbc.core.JdbcAggregateTemplate;
import org.springframework.data.jdbc.core.mapping.AggregateReference;
import org.springframework.jdbc.core.JdbcTemplate;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

public class InsertRepositoryImpl<T> implements InsertRepository<T> {
    @Value("${app.inserts.partition_size:100000}")
    private Integer PartitionSize;

    private final JdbcAggregateTemplate jdbcAggregateTemplate;

    public InsertRepositoryImpl(JdbcAggregateTemplate jdbcAggregateTemplate, JdbcTemplate jdbcTemplate) {
        this.jdbcAggregateTemplate = jdbcAggregateTemplate;
    }

    @Override
    public T insert(T entity) {
        return jdbcAggregateTemplate.insert(entity);
    }

    @Override
    public Iterable<T> insertAll(Iterable<T> entities) {
        return jdbcAggregateTemplate.insertAll(entities);
    }

    @Override
    public void insertAllPartitioned(List<T> entities) {
        if(entities.isEmpty()) { return; }

        var partioned = ListUtils.partition(entities, PartitionSize);
        for(var partition : partioned) {
            jdbcAggregateTemplate.insertAll(partition);
        }
    }
}

