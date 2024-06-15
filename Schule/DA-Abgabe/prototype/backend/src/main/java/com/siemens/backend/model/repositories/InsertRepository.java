package com.siemens.backend.model.repositories;

import java.util.List;
import java.util.UUID;

public interface InsertRepository<T> {
    T insert(T entity);
    Iterable<T> insertAll(Iterable<T> entities);

    void insertAllPartitioned(List<T> entities);

}
