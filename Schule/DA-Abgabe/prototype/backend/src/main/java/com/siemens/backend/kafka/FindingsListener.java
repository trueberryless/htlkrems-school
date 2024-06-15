package com.siemens.backend.kafka;

import com.siemens.backend.model.gna.GnaFinding;
import com.siemens.backend.model.gna.GnaFindingsActionMessage;
import com.siemens.backend.model.gna.GnaModelObject;
import com.siemens.backend.services.FindingsService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.kafka.annotation.RetryableTopic;
import org.springframework.stereotype.Component;

import java.sql.SQLException;
import java.util.List;

@Component
public class FindingsListener {
    private final FindingsService findingsService;
    private final Logger logger = LoggerFactory.getLogger(FindingsListener.class);

    public FindingsListener(FindingsService findingsService) {
        this.findingsService = findingsService;
    }


    @KafkaListener(topics = "findings", batch = "true", concurrency = "1",
            properties = { "spring.json.value.default.type=com.siemens.backend.model.gna.GnaFindingsActionMessage" }
    )
    public void processMessage(List<GnaFindingsActionMessage> content) throws SQLException {
        logger.debug("received %s GnaFindingsActionMessage on topic model_objects".formatted(content.size()));
       findingsService.processFindingsActions(content);
    }
}
