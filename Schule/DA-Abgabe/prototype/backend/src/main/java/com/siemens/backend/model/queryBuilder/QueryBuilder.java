package com.siemens.backend.model.queryBuilder;

import lombok.Data;
import lombok.Getter;

import java.util.HashMap;
import java.util.Map;

@Getter
public class QueryBuilder {
    private StringBuilder query = new StringBuilder();
    private Map<String, Object> paramMap = new HashMap<>();

    public String getQuery() {
        return query.toString();
    }

    public void AddString(String s) {
        query.append(s);
    }

    public void AddParam(String s, Object o) {
        paramMap.put(s, o);
    }
}
