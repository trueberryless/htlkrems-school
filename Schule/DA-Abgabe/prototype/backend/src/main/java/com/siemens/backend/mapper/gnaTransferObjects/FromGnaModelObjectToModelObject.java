package com.siemens.backend.mapper.gnaTransferObjects;

import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.Connection;
import com.siemens.backend.model.entities.ModelObject;
import com.siemens.backend.model.entities.ModelObjectType;
import com.siemens.backend.model.gna.GnaModelObjectType;
import com.siemens.backend.model.gna.GnaModelObject;
import org.springframework.data.jdbc.core.mapping.AggregateReference;
import org.springframework.stereotype.Component;

import java.util.*;
import java.util.stream.Collectors;

@Component
public class FromGnaModelObjectToModelObject implements FromMapper<GnaModelObject, ModelObject> {
    private final FromMapper<GnaModelObjectType, ModelObjectType> toType;

    public FromGnaModelObjectToModelObject(FromMapper<GnaModelObjectType, ModelObjectType> toType) {
        this.toType = toType;
    }

    @Override
    public ModelObject mapFrom(GnaModelObject object) {
        return ModelObject.builder()
                .Guid(object.getGuid())
                .Name(object.getName())
                .ClassName(object.getClassName())
                .ContainerId(object.getContainer().orElse(null))
                .Type(toType.mapFrom(object.getModelObjectType()))
                .NominalVoltage(object.getNominalVoltage())
                .Connections(toConnections(object.getLinkedObjects(), object.getGuid()))
                .build();
    }

    private Set<Connection> toConnections(Set<UUID> connections, UUID referencer) {
        if(connections == null || connections.isEmpty()) {
            return new HashSet<Connection>();
        }
        return connections.stream().map(con -> Connection
                .builder()
                .Guid(UUID.randomUUID())
                .Referencer(referencer)
                .Referencing(con)
                .build()
        ).collect(Collectors.toSet());
    }
}
