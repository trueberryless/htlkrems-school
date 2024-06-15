package com.siemens.backend.model.repositories;

import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.valueTypes.GroupByDoublePercentage;
import com.siemens.backend.model.valueTypes.GroupByPercentage;
import org.springframework.data.jdbc.repository.query.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.ListCrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface ModelFindingRepository
        extends CrudRepository<ModelFinding, UUID>,
                ListCrudRepository<ModelFinding, UUID>,
                InsertRepository<ModelFinding>,
                ModelFindingSearchRepository {

    @Query("select distinct category from findings order by category")
    List<String> getDistinctCategories();

    @Query("select distinct severity from findings order by severity")
    List<String> getDistinctSeverities();

    @Query("""
            select 
                f.severity as key,
                (count(*)::float / (select count(*) from findings)::float) as percentage
            from findings f
            group by f.severity
            """)
    List<GroupByPercentage> getPercentageSeverity();

    @Query("""
            select 
                f.category as key,
                (count(*)::float / (select count(*) from findings)::float) as percentage
            from findings f
            group by f.category
            """)
    List<GroupByPercentage> getPercentageCategory();

    @Query("""
            select coalesce(mo1.class_name,mo2.class_name,mo3.class_name) as key,
                   (count(*)::float / (select count(*) from findings)::float) as percentage
            from findings f
                     left join model_objects mo1 on mo1.guid = f.referenced_container
                     left join model_objects mo2 on mo2.guid = f.referenced_node
                     left join model_objects mo3 on mo3.guid = f.referenced_equipment
            group by coalesce(mo1.class_name,mo2.class_name,mo3.class_name);
            """)
    List<GroupByPercentage> getPercentageClass();

    @Query("""
            select coalesce(mo1.nominal_voltage,mo2c.nominal_voltage,mo3c.nominal_voltage) as key,
                   (count(*)::float / (select count(*) from findings)::float) as percentage
            from findings f
                left join model_objects mo1 on mo1.guid = f.referenced_container
                left join model_objects mo2 on mo2.guid = f.referenced_node
                left join model_objects mo2c on mo2c.guid = mo2.container_id
                left join model_objects mo3 on mo3.guid = f.referenced_equipment
                left join model_objects mo3c on mo3c.guid = mo3.container_id
            group by coalesce(mo1.nominal_voltage,mo2c.nominal_voltage,mo3c.nominal_voltage);
            """)
    List<GroupByDoublePercentage> getPercentageVoltage();
}
