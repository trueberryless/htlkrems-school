package com.siemens.backend.api.controller;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.api.graphqlTypes.modelObjects.ModelObjectInput;
import com.siemens.backend.api.graphqlTypes.modelObjects.ModelObjectResult;
import com.siemens.backend.services.ModelObjectsService;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;

@Controller
public class ModelObjectsController {

    private final ModelObjectsService modelObjectsService;

    public ModelObjectsController(ModelObjectsService modelObjectsService) {
        this.modelObjectsService = modelObjectsService;
    }

    @QueryMapping
    public List<ClassNameInfo> classesOfFindings() {
        return this.modelObjectsService.getClassesOfFindings();
    }

    @QueryMapping
    public List<Double> voltagesOfFindings() {
        return this.modelObjectsService.getVoltagesOfFindings();
    }

    @QueryMapping
    public ModelObjectResult modelObjects(@Argument  ModelObjectInput input) {
        return modelObjectsService.getModelObjects(input);
    }
}
