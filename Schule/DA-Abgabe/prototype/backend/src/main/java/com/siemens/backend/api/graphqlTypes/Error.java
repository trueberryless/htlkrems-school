package com.siemens.backend.api.graphqlTypes;

import com.siemens.backend.api.graphqlTypes.findings.FindingsMaybe;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class Error implements FindingsMaybe {
    String cause;
    String detailedMessage;
}
