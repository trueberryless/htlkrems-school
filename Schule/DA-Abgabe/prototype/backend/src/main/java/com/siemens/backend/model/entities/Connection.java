package com.siemens.backend.model.entities;

import lombok.*;
import org.springframework.data.annotation.PersistenceCreator;
import org.springframework.data.relational.core.mapping.Column;
import org.springframework.data.relational.core.mapping.Table;

import java.util.UUID;

@ToString
@Getter
@Setter
@NoArgsConstructor
@Builder
@AllArgsConstructor(onConstructor = @__(@PersistenceCreator))
@Table("connections")
public class Connection {
    @Column("guid")
    UUID Guid;

    @Column("referencer")
    UUID Referencer;

    @Column("referencing")
    UUID Referencing;
}
