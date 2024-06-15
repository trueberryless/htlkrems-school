package com.siemens.backend.model.queryBuilder;

import org.springframework.data.jdbc.repository.query.Query;

import java.util.List;
import java.util.UUID;

public class ModelObjectGraphQueryBuilder extends  QueryBuilder{
    public ModelObjectGraphQueryBuilder SelectAll() {
        AddString("""
                select\s
                    o.guid AS model_guid,
                    o.name AS model_name,
                    o.class_name AS model_class_name,
                    o.container_id AS model_container_id,
                    o.type AS model_type,
                    container.guid AS container_guid,
                    container.name AS container_name,
                    container.class_name AS container_class_name,
                    container.container_id AS container_container_id,
                    container.type AS container_type,
                    container.nominal_voltage AS container_nominal_voltage,
                    connection.guid AS connection_guid,
                    connection.referencer AS connection_referencer,
                    connection.referencing AS connection_referencing
                                
                """);
        return this;
    }

    public ModelObjectGraphQueryBuilder AddFrom()  {
        AddString("""
                 FROM\s
                    model_objects o
                LEFT JOIN\s
                    model_objects container ON container.guid = o.container_id
                LEFT JOIN\s
                    connections connection ON connection.referencer = o.guid\s
                """);
        return this;
    }

    public ModelObjectGraphQueryBuilder AddSorting() {
        AddString("""
                 order by o.guid\s
                """);
        return this;
    }

    public ModelObjectGraphQueryBuilder AddFilter(List<UUID> guids) {
        AddString(" where o.guid in (:guids) ");
        AddString(" and ");
        AddString(" o.type in ('CONNECTED_EQUIPMENT', 'CONNECTING_EQUIPMENT', 'NODE') ");
        AddParam("guids", guids);
        return this;
    }

}
