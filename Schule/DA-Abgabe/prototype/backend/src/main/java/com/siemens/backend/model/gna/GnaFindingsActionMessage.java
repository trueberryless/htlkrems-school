package com.siemens.backend.model.gna;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class GnaFindingsActionMessage {
    @JsonProperty("action")
    public GnaFindingsActionType Action;

    @JsonProperty("finding")
    public GnaFinding finding;
}
