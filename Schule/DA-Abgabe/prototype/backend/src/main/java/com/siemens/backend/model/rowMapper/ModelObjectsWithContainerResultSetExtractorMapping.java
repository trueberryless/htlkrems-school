package com.siemens.backend.model.rowMapper;

import com.siemens.backend.model.entities.Connection;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import org.springframework.dao.DataAccessException;
import org.springframework.jdbc.core.ResultSetExtractor;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.*;

public class ModelObjectsWithContainerResultSetExtractorMapping implements ResultSetExtractor<List<ModelObject>> {

    @Override
    public List<ModelObject> extractData(ResultSet rs) throws SQLException, DataAccessException {
        List<ModelObject> modelObjects = new ArrayList<>();
        Optional<ModelObject> lastObject = Optional.empty();
        while(rs.next()) {
            ModelObject m = ModelObject.builder()
                    .Guid(UUID.fromString(rs.getString("model_guid")))
                    .Name(rs.getString("model_name"))
                    .ClassName(rs.getString("model_class_name"))
                    .Type(ModelObjectType.valueOf(rs.getString("model_type")))
                    .build();

            var referencedContainerId = rs.getString("model_container_id");
            if(referencedContainerId != null) {
                m.setContainerId(UUID.fromString(referencedContainerId));
            }

            var containerId = rs.getString("container_guid");
            if(containerId != null) {
                m.setContainer(
                ModelObject.builder()
                        .Guid(UUID.fromString(containerId))
                        .Name(rs.getString("container_name"))
                        .ClassName(rs.getString("container_class_name"))
                        .NominalVoltage(rs.getDouble("container_nominal_voltage"))
                        .Type(ModelObjectType.valueOf(rs.getString("container_type")))
                        .build()
                );
            }

            var set = new HashSet<Connection>();
            var connectionId = rs.getString("connection_guid");
            if(connectionId != null) {
                var connection = Connection.builder()
                        .Guid(UUID.fromString(connectionId))
                        .Referencer(UUID.fromString(rs.getString("connection_referencer")))
                        .Referencing(UUID.fromString(rs.getString("connection_referencing")))
                        .build();
                set.add(connection);
            }
            m.setConnections(set);

            if(lastObject.isPresent() && lastObject.get().getGuid().equals(m.getGuid())) {
                var connections = lastObject.get().getConnections();
                connections.addAll(m.getConnections());
            }
            else {
                lastObject = Optional.of(m);
                modelObjects.add(m);
            }
        }
        return modelObjects;
    }
}
