package com.siemens.backend.model.gna;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Optional;
import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class GnaFinding {
    @JsonProperty("staticDataModelObjectGuid")
    UUID StaticDataModelObjectGuid;

    @JsonProperty("powerSystemResourceGuid")
    UUID PowerSystemResourceGuid;

    @JsonProperty("nodeGuid")
    UUID NodeGuid;

    @JsonProperty("severity")
    String Severity;

    @JsonProperty("category")
    String Category;

    @JsonProperty("assambledMessage")
    String AssembledMessage;

    public Optional<UUID> getStaticDataModelObjectGuid() {
        return Optional.ofNullable(this.StaticDataModelObjectGuid);
    }

    public Optional<UUID> getPowerSystemResourceGuid() {
        return Optional.ofNullable(this.PowerSystemResourceGuid);
    }

    public Optional<UUID> getNodeGuid() {
        return Optional.ofNullable(this.NodeGuid);
    }
}
