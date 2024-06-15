package com.siemens.backend.services;

import com.siemens.backend.api.graphqlTypes.PageInfo;
import com.siemens.backend.api.graphqlTypes.dashboard.CategoryPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.ClassPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.SeverityPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.VoltagePercentage;
import com.siemens.backend.api.graphqlTypes.findings.Finding;
import com.siemens.backend.api.graphqlTypes.findings.FindingInput;
import com.siemens.backend.api.graphqlTypes.findings.FindingsResult;
import com.siemens.backend.mapper.FromMapper;
import com.siemens.backend.model.entities.ModelFinding;
import com.siemens.backend.model.gna.GnaFinding;
import com.siemens.backend.model.gna.GnaFindingsActionMessage;
import com.siemens.backend.model.repositories.ModelFindingRepository;
import com.siemens.backend.model.valueTypes.GroupByDoublePercentage;
import com.siemens.backend.model.valueTypes.GroupByPercentage;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class FindingsService {
    private final ModelFindingRepository modelFindingRepository;
    private final FromMapper<ModelFinding, Finding> fromModelFindingToFinding;
    private final FromMapper<GnaFinding, ModelFinding> fromGnaToFinding;

    private final FromMapper<GroupByPercentage, SeverityPercentage> fromPercentageToSeverityPercentage;
    private final FromMapper<GroupByPercentage, ClassPercentage> fromPercentageToClassPercentage;
    private final FromMapper<GroupByPercentage, CategoryPercentage> fromPercentageToCategoryPercentage;
    private final FromMapper<GroupByDoublePercentage, VoltagePercentage> fromPercentageToVoltagePercentage;
    private final Logger logger = LoggerFactory.getLogger(FindingsService.class);

    public FindingsService(ModelFindingRepository modelFindingRepository, FromMapper<ModelFinding, Finding> fromModelFindingToFinding, FromMapper<GnaFinding, ModelFinding> fromGnaToFinding, FromMapper<GroupByPercentage, SeverityPercentage> fromPercentageToSeverityPercentage, FromMapper<GroupByPercentage, ClassPercentage> fromPercentageToClassPercentage, FromMapper<GroupByPercentage, CategoryPercentage> fromPercentageToCategoryPercentage, FromMapper<GroupByDoublePercentage, VoltagePercentage> fromPercentageToVoltagePercentage) {
        this.modelFindingRepository = modelFindingRepository;
        this.fromModelFindingToFinding = fromModelFindingToFinding;
        this.fromGnaToFinding = fromGnaToFinding;
        this.fromPercentageToSeverityPercentage = fromPercentageToSeverityPercentage;
        this.fromPercentageToClassPercentage = fromPercentageToClassPercentage;
        this.fromPercentageToCategoryPercentage = fromPercentageToCategoryPercentage;
        this.fromPercentageToVoltagePercentage = fromPercentageToVoltagePercentage;
    }

    public FindingsResult searchFindings(FindingInput findingInput) {
        var foundModelFindings = this.modelFindingRepository.searchFindings(findingInput);
        var findings = foundModelFindings.stream().map(fromModelFindingToFinding::mapFrom).toList();

        var count = modelFindingRepository.searchFindingsCount(findingInput);

        var pageInfo = PageInfo.builder()
                .position(findingInput.getOffset() + findings.size())
                .count((int) count)
                .build();

        return FindingsResult.builder()
                .result(findings)
                .pageInfo(pageInfo)
                .build();
    }

    public List<String> getCategories() {
        return modelFindingRepository.getDistinctCategories();
    }

    public List<String> getSeverities() {
        return modelFindingRepository.getDistinctSeverities();
    }

    public void insertGnaFindings(List<GnaFinding> gnaFindings) {
        var findings = gnaFindings.stream().map(fromGnaToFinding::mapFrom).toList();
        insertFindings(findings);
    }
    public void insertFindings(List<ModelFinding> modelFindings) {
        logger.info("inserting %s findings".formatted(modelFindings.size()));
        modelFindingRepository.insertAllPartitioned(modelFindings);
        logger.info("finished inserting %s findings".formatted(modelFindings.size()));
    }

    public void processFindingsActions(List<GnaFindingsActionMessage> messages) {
        var gnaFindingsToInsert = new ArrayList<GnaFinding>();

        for (var m : messages) {
            switch (m.getAction()) {
                case ADD -> {
                    gnaFindingsToInsert.add(m.finding);
                }
                case TRUNCATE -> {
                    gnaFindingsToInsert = new ArrayList<>();
                    modelFindingRepository.deleteAll();
                    logger.info("finished truncating findings");
                }
            }
        }

        insertGnaFindings(gnaFindingsToInsert);
    }

    public List<SeverityPercentage> getSeverityPercentages() {
        var percentages = modelFindingRepository.getPercentageSeverity();
        return percentages.stream().map(fromPercentageToSeverityPercentage::mapFrom).toList();
    }

    public List<CategoryPercentage> getCategoryPercentages() {
        var percentages = modelFindingRepository.getPercentageCategory();
        return percentages.stream().map(fromPercentageToCategoryPercentage::mapFrom).toList();
    }

    public List<ClassPercentage> getClassPercentages() {
        var percentages = modelFindingRepository.getPercentageClass();
        return percentages.stream().map(fromPercentageToClassPercentage::mapFrom).toList();
    }

    public List<VoltagePercentage> getVoltagePercentage() {
        var percentages = modelFindingRepository.getPercentageVoltage();
        return percentages.stream().map(fromPercentageToVoltagePercentage::mapFrom).toList();
    }
}
