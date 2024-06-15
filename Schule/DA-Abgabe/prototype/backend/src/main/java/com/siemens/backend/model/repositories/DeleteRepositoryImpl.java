package com.siemens.backend.model.repositories;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;
import java.sql.SQLException;
import java.util.UUID;

@Component
public class DeleteRepositoryImpl<T> implements DeleteRepository {
    private final JdbcTemplate jdbcTemplate;

    private final String DeleteStatement = "DELETE FROM %s WHERE %s = ANY(?)";

    public DeleteRepositoryImpl(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }


    @Override
    public void deleteAllByIdArray(UUID[] ids, String table, String idColumn) throws SQLException  {
        if(ids.length == 0) { return; }

        var delete = DeleteStatement.formatted(table,idColumn);
        jdbcTemplate.update(delete, ps -> {
            ps.setArray(1, ps.getConnection().createArrayOf("uuid", ids));
        });
    }
}
