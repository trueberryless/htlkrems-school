package com.siemens.backend.model.repositories;

import com.siemens.backend.model.entities.ModelObject;
import org.springframework.data.jdbc.repository.query.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.ListCrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface ModelObjectRepository extends CrudRepository<ModelObject, UUID>, ListCrudRepository<ModelObject, UUID>, InsertRepository<ModelObject>, GraphModelObjectRepository {
    @Query("""
            select distinct mo1.class_name from model_objects mo1
                                             join model_objects mo2 on mo2.container_id = mo1.guid
                                             join findings f on mo2.guid in (f.referenced_container, f.referenced_equipment, f.referenced_node)
                                             order by mo1.class_name
     """)
    public List<String> getDistinctClassNameOfFindingsForContainers();

    @Query("""
            select distinct mo1.class_name from model_objects mo1
                                             join findings f on mo1.guid in (f.referenced_container, f.referenced_equipment, f.referenced_node)
                                             order by mo1.class_name
     """)
    public List<String> getDistinctClassNameOfFindingsForNonContainer();

    @Query(""" 
            select distinct mo1.nominal_voltage from model_objects mo1
                                             join model_objects mo2 on mo2.container_id = mo1.guid
                                             join findings f on mo2.guid in (f.referenced_container, f.referenced_equipment, f.referenced_node)
                                             where mo1.nominal_voltage is not null
                                             order by mo1.nominal_voltage
             """)
    public List<Double> getDistinctNominalVoltageOfFindings();

}
