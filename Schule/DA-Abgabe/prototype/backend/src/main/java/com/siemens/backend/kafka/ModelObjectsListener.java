package com.siemens.backend.kafka;

import com.siemens.backend.model.gna.GnaModelObject;
import com.siemens.backend.services.ModelObjectsService;
import org.slf4j.LoggerFactory;
import org.slf4j.Logger;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.kafka.annotation.RetryableTopic;
import org.springframework.stereotype.Component;

import java.sql.SQLException;
import java.util.List;

@Component
public class ModelObjectsListener {
    private final ModelObjectsService modelObjectsService;
    private final Logger logger = LoggerFactory.getLogger(ModelObjectsListener.class);

    public ModelObjectsListener(ModelObjectsService modelObjectsService) {
        this.modelObjectsService = modelObjectsService;
    }

    @KafkaListener(topics = "model_objects", batch = "true", concurrency = "3",
            properties = { "spring.json.value.default.type=com.siemens.backend.model.gna.GnaModelObject" }
    )
    public void processMessage(List<GnaModelObject> content) throws SQLException {
        logger.debug("received %s GnaModelObjects on topic model_objects".formatted(content.size()));
       modelObjectsService.insertAndDeleteGnaModelObjects(content);
    }
}
