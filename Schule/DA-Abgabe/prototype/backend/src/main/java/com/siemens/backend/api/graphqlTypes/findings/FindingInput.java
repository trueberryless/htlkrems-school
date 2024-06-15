package com.siemens.backend.api.graphqlTypes.findings;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;
import org.springframework.graphql.data.method.annotation.Argument;

import java.util.List;
import java.util.Optional;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class FindingInput {
    Integer limit;
    Integer offset;
    SortFinding sorting;
    SortDirection direction;
    String filter;
    List<String> categories;
    List<String> severities;
    List<String> classes;
    List<Double> voltages;

    public Optional<String> getFilter() {
        return Optional.ofNullable(filter);
    }

    public Optional<List<String>> getCategories() {
        return Optional.ofNullable(categories);
    }

    public Optional<List<String>> getSeverities() {
        return Optional.ofNullable(severities);
    }

    public Optional<List<String>> getClasses() { return Optional.ofNullable(classes); }
    public Optional<List<Double>> getVoltages() { return Optional.ofNullable(voltages); }
}
