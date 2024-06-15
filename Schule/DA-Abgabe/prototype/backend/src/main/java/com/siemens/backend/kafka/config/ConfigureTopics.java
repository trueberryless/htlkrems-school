package com.siemens.backend.kafka.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.kafka.config.TopicBuilder;
import org.springframework.kafka.core.KafkaAdmin;

@Configuration
public class ConfigureTopics {
    @Bean
    public KafkaAdmin.NewTopics createTopics() {
        return new KafkaAdmin.NewTopics(

                TopicBuilder.name("model_objects")
                        .build(),
                TopicBuilder.name("findings")
                        .build()
        );
    }
}
