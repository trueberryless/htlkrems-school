package com.siemens.backend.model.queryBuilder;

import com.siemens.backend.api.graphqlTypes.findings.FindingInput;
import com.siemens.backend.api.graphqlTypes.findings.SortDirection;
import com.siemens.backend.api.graphqlTypes.findings.SortFinding;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class FindingsSearchQueryBuilder extends QueryBuilder {
    private final FindingInput searchInput;

    public FindingsSearchQueryBuilder(FindingInput searchInput) {
        this.searchInput = searchInput;
    }

    public FindingsSearchQueryBuilder SelectCount() {
        AddString(" select count(*) ");
        return this;
    }

    public FindingsSearchQueryBuilder SelectAll() {
        AddString("""
                select 
                    f.guid as f_guid,
                    f.type as f_type,
                    f.severity as f_severity,
                    f.category as f_category,
                    f.message as f_message,
                    f.referenced_container as f_referenced_container,
                    f.referenced_node as f_referenced_node,
                    f.referenced_equipment as f_referenced_equipment,
                    
                    mo1.guid as mo1_guid,
                    mo1.name as mo1_name,
                    mo1.class_name as mo1_class_name,
                    mo1.nominal_voltage as mo1_nominal_voltage,
                    mo1.type as mo1_type,
                    
                    mo2.guid as mo2_guid,
                    mo2.name as mo2_name,
                    mo2.class_name as mo2_class_name,
                    mo2.type as mo2_type,
                    mo2.container_id as mo2_container_id,
                    
                    mo2c.guid as mo2c_guid,
                    mo2c.name as mo2c_name,
                    mo2c.class_name as mo2c_class_name,
                    mo2c.nominal_voltage as mo2c_nominal_voltage,
                    mo2c.type as mo2c_type,
                    
                    mo3.guid as mo3_guid,
                    mo3.name as mo3_name,
                    mo3.class_name as mo3_class_name,
                    mo3.type as mo3_type,
                    mo3.container_id as mo3_container_id,
                    
                    mo3c.guid as mo3c_guid,
                    mo3c.name as mo3c_name,
                    mo3c.class_name as mo3c_class_name,
                    mo3c.nominal_voltage as mo3c_nominal_voltage,
                    mo3c.type as mo3c_type
                    
                    """);
        return this;
    }

    public FindingsSearchQueryBuilder AddFrom() {
       AddString(""" 
                 from findings f
                    left join model_objects mo1 on mo1.guid = f.referenced_container
                    left join model_objects mo2 on mo2.guid = f.referenced_node
                    left join model_objects mo2c on mo2c.guid = mo2.container_id
                    left join model_objects mo3 on mo3.guid = f.referenced_equipment
                    left join model_objects mo3c on mo3c.guid = mo3.container_id 
               """);
       return this;
    }

    public FindingsSearchQueryBuilder AddFilter() {
        var where = new ArrayList<String>();

        if(searchInput.getFilter().isPresent() && !searchInput.getFilter().get().isEmpty()) {
            where.add(""" 
                    concat_ws(
                          ' ',
                          f.guid, f.type, f.severity, f.category, f.message, f.referenced_container, f.referenced_node, f.referenced_equipment,
                          mo1.guid, mo1.name, mo1.class_name, mo1.nominal_voltage, mo1.type,
                          mo2.guid, mo2.name, mo2.class_name, mo2.type, mo2.container_id,
                          mo2c.guid, mo2c.name, mo2c.class_name, mo2c.nominal_voltage, mo2c.type,
                          mo3.guid, mo3.name, mo3.class_name, mo3.type, mo3.container_id,
                          mo3c.guid, mo3c.name, mo3c.class_name, mo3c.nominal_voltage, mo3c.type
                      ) ~* :filter
                      """);
            AddParam("filter", searchInput.getFilter().get());
        }

        if(searchInput.getCategories().isPresent() && !searchInput.getCategories().get().isEmpty()) {
            where.add(" f.category in (:cat) ");
            AddParam("cat", searchInput.getCategories().get());
        }

        if(searchInput.getSeverities().isPresent() && !searchInput.getSeverities().get().isEmpty()) {
            where.add(" f.severity in (:sev) ");
            AddParam("sev", searchInput.getSeverities().get());
        }

        if(searchInput.getClasses().isPresent() && !searchInput.getClasses().get().isEmpty()) {
            where.add(
                    " ( mo1.class_name in (:classes) or " +
                            " mo2.class_name in (:classes) or " +
                            " mo2c.class_name in (:classes) or " +
                            " mo3.class_name in (:classes) or " +
                            " mo3c.class_name in (:classes)) "
            );
            AddParam("classes", searchInput.getClasses().get());
        }

        if(searchInput.getVoltages().isPresent() && !searchInput.getVoltages().get().isEmpty()) {
            var voltages = new ArrayList<>(searchInput.getVoltages().get());
            var whereVoltages = new ArrayList<String>();

            var noVoltageInclude = voltages.remove(-1D);
            if(noVoltageInclude) {
                whereVoltages.addAll(List.of("(f.type = 'CONTAINER' and mo1.nominal_voltage is null )",
                        "( f.type = 'NODE' and mo2c.nominal_voltage is null )",
                        "( f.type = 'ATTACHMENT_FINDING' and ( mo2c.nominal_voltage is null or mo3c.nominal_voltage is null ))",
                        "( f.type = 'EQUIPMENT' and mo3c.nominal_voltage is null )"));
            }

            if(!voltages.isEmpty()) {
                whereVoltages.addAll(List.of("mo1.nominal_voltage in (:voltages)",
                        "mo2c.nominal_voltage in (:voltages)",
                        "mo3c.nominal_voltage in (:voltages)"));
            }


            where.add(" ( " + String.join(" or ", whereVoltages) + " ) ");
            AddParam("voltages", voltages);
        }

        if(!where.isEmpty()) {
            var whereClause = String.join(" and ", where);
            AddString(" where " + whereClause + " ");
        }

        return this;
    }

    public FindingsSearchQueryBuilder AddSorting() {
        var sortColumns = mapSortFinding(searchInput.getSorting());
        var direction = mapSortDirection(searchInput.getDirection());

        AddString(" order by ");
        AddString(String.join(" %s , ".formatted(direction), sortColumns));
        AddString(" %s ".formatted(direction));

        return this;
    }

    public FindingsSearchQueryBuilder AddLimitAndOffset() {
        var limitAndOffset = " limit :limit offset :offset ";
        AddParam("limit", searchInput.getLimit());
        AddParam("offset", searchInput.getOffset());

        AddString(limitAndOffset);

        return this;
    }

    private String mapSortDirection(SortDirection sortDirection) {
        return switch (sortDirection) {
            case ASC -> "asc";
            case DSC -> "desc";
        };
    }

    private List<String> mapSortFinding(SortFinding sortFinding) {
        return switch (sortFinding) {
            case GUID -> List.of("f.guid");
            case SEVERITY -> List.of("f.severity","f.guid");
            case CATEGORY -> List.of("f.category","f.guid");
            case MESSAGE -> List.of("f.message","f.guid");
            case TYPE -> List.of("f.type","f.guid");
            case CLASS -> List.of("mo1.class_name","mo2.class_name","mo2c.class_name","mo3.class_name","mo3c.class_name","f.guid");
        };
    }
}
