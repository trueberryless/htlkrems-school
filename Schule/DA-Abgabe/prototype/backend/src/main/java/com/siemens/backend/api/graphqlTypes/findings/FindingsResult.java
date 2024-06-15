package com.siemens.backend.api.graphqlTypes.findings;

import com.siemens.backend.api.graphqlTypes.PageInfo;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import java.util.List;

@Data
@SuperBuilder
@NoArgsConstructor
@AllArgsConstructor
public class FindingsResult implements FindingsMaybe {
    List<Finding> result;
    PageInfo pageInfo;
}
