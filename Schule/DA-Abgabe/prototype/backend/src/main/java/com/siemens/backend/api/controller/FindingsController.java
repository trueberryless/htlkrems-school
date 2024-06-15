package com.siemens.backend.api.controller;

import com.siemens.backend.api.graphqlTypes.Error;
import com.siemens.backend.api.graphqlTypes.dashboard.CategoryPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.ClassPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.SeverityPercentage;
import com.siemens.backend.api.graphqlTypes.dashboard.VoltagePercentage;
import com.siemens.backend.api.graphqlTypes.findings.*;
import com.siemens.backend.services.FindingsService;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;

@Controller
public class FindingsController {
    private final FindingsService findingsService;

    public FindingsController(FindingsService findingsService) {
        this.findingsService = findingsService;
    }

    @QueryMapping
    public FindingsMaybe findings(@Argument FindingInput input) {
        try {
            return this.findingsService.searchFindings(input);
        }
        catch (Exception e) {
            return Error.builder()
                    .cause(e.getCause().getMessage())
                    .detailedMessage(e.getMessage())
                    .build();
        }
    }

    @QueryMapping
    public List<String> categories() {
        return this.findingsService.getCategories();
    }

    @QueryMapping
    public List<String> severities() {
        return this.findingsService.getSeverities();
    }

    @QueryMapping
    public List<SeverityPercentage> severityPercentages() {
        return this.findingsService.getSeverityPercentages();
    }

    @QueryMapping
    public List<CategoryPercentage> categoryPercentages() {
        return this.findingsService.getCategoryPercentages();
    }

    @QueryMapping
    public List<ClassPercentage> classPercentages() {
        return this.findingsService.getClassPercentages();
    }

    @QueryMapping
    public List<VoltagePercentage> voltagePercentages() {
        return this.findingsService.getVoltagePercentage();
    }
}
