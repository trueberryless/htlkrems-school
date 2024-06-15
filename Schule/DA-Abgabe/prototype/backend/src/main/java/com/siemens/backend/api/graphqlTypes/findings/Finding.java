package com.siemens.backend.api.graphqlTypes.findings;

import com.siemens.backend.api.graphqlTypes.PageInfo;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import java.util.UUID;

@Data
@SuperBuilder
@NoArgsConstructor
@AllArgsConstructor
public abstract class Finding {
    UUID guid;
    String category;
    String severity;
    String message;
}

