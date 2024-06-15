package com.siemens.backend.model.repositories;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public interface DeleteRepository {
    void deleteAllByIdArray(UUID[] ids, String table, String idColumn) throws SQLException;
}
