package com.siemens.backend.model.repositories;

import com.siemens.backend.api.graphqlTypes.findings.FindingInput;
import com.siemens.backend.model.entities.ModelFinding;

import java.util.List;

public interface ModelFindingSearchRepository {
    List<ModelFinding> searchFindings(FindingInput searchInput);
    Integer searchFindingsCount(FindingInput searchInput);
}
