package com.siemens.backend.model.entities;

import lombok.*;
import org.springframework.data.annotation.Id;
import org.springframework.data.annotation.PersistenceCreator;
import org.springframework.data.annotation.Transient;
import org.springframework.data.jdbc.core.mapping.AggregateReference;
import org.springframework.data.relational.core.mapping.Column;
import org.springframework.data.relational.core.mapping.Table;

import java.util.Objects;
import java.util.Optional;
import java.util.UUID;

@ToString
@Getter
@Setter
@NoArgsConstructor
@Table("findings")
@Builder
@AllArgsConstructor(onConstructor = @__(@PersistenceCreator))
public class ModelFinding {
    @Id @Column("guid")
    UUID Guid;

    @Column("type")
    FindingType type;

    @Column("severity")
    String Severity;

    @Column("category")
    String Category;

    @Column("message")
    String Message;

    @Column("referenced_container")
    AggregateReference<ModelObject, UUID> ReferencedContainerId;

    @Transient
    ModelObject ReferencedContainer;

    public Optional<ModelObject> getReferencedContainer() {
        return Optional.ofNullable(this.ReferencedContainer);
    }

    @Column("referenced_equipment")
    AggregateReference<ModelObject, UUID> ReferencedEquipmentId;

    @Transient
    ModelObject ReferencedEquipment;

    public Optional<ModelObject> getReferencedEquipment() {
        return Optional.ofNullable(this.ReferencedEquipment);
    }


    @Column("referenced_node")
    AggregateReference<ModelObject, UUID> ReferencedNodeId;

    @Transient
    ModelObject ReferencedNode;

    public Optional<ModelObject> getReferencedNode() {
        return Optional.ofNullable(this.ReferencedNode);
    }
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof ModelFinding that)) return false;
        return Objects.equals(this.Guid, that.Guid);
    }

    @Override
    public int hashCode() {
        return Objects.hash(this.getGuid());
    }
}
