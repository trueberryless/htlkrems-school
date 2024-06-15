package com.siemens.backend.services;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.siemens.backend.model.gna.GnaFinding;
import com.siemens.backend.model.gna.GnaModelObject;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Service;

import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;
import java.util.Optional;

@Service
public class ModelFromJsonFileLoader implements ApplicationRunner {
    private final FindingsService findingsService;
    private final ModelObjectsService modelObjectsService;

    @Value("${app.fileLoader.modelObjectsJsonFile:}")
    private Optional<String> ModelObjectsJsonFile;

    @Value("${app.fileLoader.findingsJsonFile:}")
    private Optional<String> FindingsJsonFile;

    private final ObjectMapper objectMapper;

    private final Logger logger = LoggerFactory.getLogger(ModelFromJsonFileLoader.class);

    public ModelFromJsonFileLoader(FindingsService findingsService, ModelObjectsService modelObjectsService, ObjectMapper objectMapper) {
        this.findingsService = findingsService;
        this.modelObjectsService = modelObjectsService;
        this.objectMapper = objectMapper;
    }


    @Override
    public void run(ApplicationArguments args) {
        try {
            if(ModelObjectsJsonFile.isPresent() && !ModelObjectsJsonFile.get().isEmpty()) {
                this.logger.info("Loading ModelObjects from file {}",ModelObjectsJsonFile.get());
                loadModelObjects(ModelObjectsJsonFile.get());
            }

            if(FindingsJsonFile.isPresent() && !FindingsJsonFile.get().isEmpty()) {
                this.logger.info("Loading Findings from file {}",FindingsJsonFile.get());
                loadFindings(FindingsJsonFile.get());
            }
        }
        catch (IOException e) {
            throw new RuntimeException(e);
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    private void loadModelObjects(String path) throws IOException, SQLException {
        List<GnaModelObject> modelObjects = objectMapper.readValue(new File(path), new TypeReference<List<GnaModelObject>>(){});
        this.logger.info("Saving all ModelObjects to Database");
        modelObjectsService.insertAndDeleteGnaModelObjects(modelObjects);

        this.logger.info("Loaded all ModelObjects");
    }

    private void loadFindings(String path) throws IOException {
        List<GnaFinding> modelObjects = objectMapper.readValue(new File(path), new TypeReference<List<GnaFinding>>(){});
        this.logger.info("Saving all Finding to Database");
        findingsService.insertGnaFindings(modelObjects);

        this.logger.info("Loaded all Findings");
    }
}
