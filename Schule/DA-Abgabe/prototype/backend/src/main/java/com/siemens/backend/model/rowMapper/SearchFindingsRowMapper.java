package com.siemens.backend.model.rowMapper;

import com.siemens.backend.model.entities.FindingType;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import org.springframework.data.jdbc.core.mapping.AggregateReference;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.UUID;

public class SearchFindingsRowMapper implements RowMapper<ModelFinding> {
    @Override
    public ModelFinding mapRow(ResultSet rs, int rowNum) throws SQLException {
        var modelFinding = ModelFinding.builder()
                .Guid(UUID.fromString(rs.getString("f_guid")))
                .type(FindingType.valueOf(rs.getString("f_type")))
                .Severity(rs.getString("f_severity"))
                .Category(rs.getString("f_category"))
                .Message(rs.getString("f_message"))
                .build();

        var referencedContainerId = rs.getString("f_referenced_container");
        if (referencedContainerId != null) {
            modelFinding.setReferencedContainerId(
                    AggregateReference.to(
                            UUID.fromString(referencedContainerId)
                    )
            );

            var containerId = rs.getString("mo1_guid");
            if(containerId != null) {
                modelFinding.setReferencedContainer(
                        ModelObject.builder()
                                .Guid(UUID.fromString(containerId))
                                .Name(rs.getString("mo1_name"))
                                .ClassName(rs.getString("mo1_class_name"))
                                .NominalVoltage(rs.getDouble("mo1_nominal_voltage"))
                                .Type(ModelObjectType.valueOf(rs.getString("mo1_type")))
                            .build()
                );
            }
        }

        var referencedNodeId = rs.getString("f_referenced_node");
        if (referencedNodeId != null) {
            modelFinding.setReferencedNodeId(
                    AggregateReference.to(
                            UUID.fromString(referencedNodeId)
                    )
            );

            var nodeId = rs.getString("mo2_guid");
            if(nodeId != null) {
                var modelObject = ModelObject.builder()
                        .Guid(UUID.fromString(nodeId))
                        .Name(rs.getString("mo2_name"))
                        .ClassName(rs.getString("mo2_class_name"))
                        .Type(ModelObjectType.valueOf(rs.getString("mo2_type")))
                        .build();

                var containerId = rs.getString("mo2c_guid");
                if(containerId != null) {
                    modelObject.setContainerId(UUID.fromString(containerId));
                    modelObject.setContainer(
                            ModelObject.builder()
                                    .Guid(UUID.fromString(containerId))
                                    .Name(rs.getString("mo2c_name"))
                                    .ClassName(rs.getString("mo2c_class_name"))
                                    .NominalVoltage(rs.getDouble("mo2c_nominal_voltage"))
                                    .Type(ModelObjectType.valueOf(rs.getString("mo2c_type")))
                                    .build()
                    );
                }
                modelFinding.setReferencedNode(modelObject);
            }
        }

        var referencedEquipmentId = rs.getString("f_referenced_equipment");
        if (referencedEquipmentId != null) {
            modelFinding.setReferencedEquipmentId(
                    AggregateReference.to(
                            UUID.fromString(referencedEquipmentId)
                    )
            );

            var equipmentId = rs.getString("mo3_guid");
            if(equipmentId != null) {
                var modelObject = ModelObject.builder()
                        .Guid(UUID.fromString(equipmentId))
                        .Name(rs.getString("mo3_name"))
                        .ClassName(rs.getString("mo3_class_name"))
                        .Type(ModelObjectType.valueOf(rs.getString("mo3_type")))
                        .build();

                var containerId = rs.getString("mo3c_guid");
                if(containerId != null) {
                    modelObject.setContainerId(UUID.fromString(containerId));
                    modelObject.setContainer(
                            ModelObject.builder()
                                    .Guid(UUID.fromString(containerId))
                                    .Name(rs.getString("mo3c_name"))
                                    .ClassName(rs.getString("mo3c_class_name"))
                                    .NominalVoltage(rs.getDouble("mo3c_nominal_voltage"))
                                    .Type(ModelObjectType.valueOf(rs.getString("mo3c_type")))
                                    .build()
                    );
                }
                modelFinding.setReferencedEquipment(modelObject);
            }
        }

        return modelFinding;
    }
}
