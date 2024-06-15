package com.siemens.backend.model.entities;

import lombok.*;
import org.springframework.data.annotation.Id;
import org.springframework.data.annotation.PersistenceCreator;
import org.springframework.data.annotation.Transient;
import org.springframework.data.relational.core.mapping.*;

import java.util.*;

@ToString
@Getter
@Setter
@NoArgsConstructor
@Table("model_objects")
@Builder
@AllArgsConstructor(onConstructor = @__(@PersistenceCreator))
public class ModelObject {
    @Id @Column("guid")
    UUID Guid;

    @Column("name")
    String Name;

    @Column("class_name")
    String ClassName;

    @Column("container_id")
    UUID ContainerId;

    @Column("nominal_voltage")
    Double NominalVoltage;

    public Optional<Double> getNominalVoltage() {
       return Optional.ofNullable(this.NominalVoltage);
    }

    public Optional<UUID> getContainerId() {
        return Optional.ofNullable(this.ContainerId);
    }

    @Transient
    ModelObject Container;

    public Optional<ModelObject> getContainer() {
        return Optional.ofNullable(this.Container);
    }

    @Column("type")
    ModelObjectType Type;

    @MappedCollection(idColumn = "referencer")
    Set<Connection> Connections;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof ModelObject that)) return false;
        return Objects.equals(this.Guid, that.Guid);
    }

    @Override
    public int hashCode() {
        return Objects.hash(this.getGuid());
    }
}
