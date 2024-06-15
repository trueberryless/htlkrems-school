package com.siemens.backend.model.gna;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Optional;
import java.util.Set;
import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class GnaModelObject {
    @JsonProperty("guid")
    UUID Guid;

    @JsonProperty("name")
    String Name;

    @JsonProperty("className")
    String ClassName;

    @JsonProperty("modelObjectType")
    GnaModelObjectType ModelObjectType;

    @JsonProperty("container")
    UUID Container;

    @JsonProperty("nominalVoltage")
    Double NominalVoltage;

    public Optional<UUID> getContainer() {
        return Optional.ofNullable(this.Container);
    }

    @JsonProperty("linkedObjects")
    Set<UUID> linkedObjects;
}
