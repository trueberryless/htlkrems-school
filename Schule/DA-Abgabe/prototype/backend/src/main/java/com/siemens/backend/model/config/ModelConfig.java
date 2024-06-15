package com.siemens.backend.model.config;

import com.siemens.backend.model.entities.Connection;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.io.ClassPathResource;
import org.springframework.data.jdbc.repository.config.AbstractJdbcConfiguration;
import org.springframework.data.jdbc.repository.config.EnableJdbcRepositories;
import org.springframework.data.relational.core.mapping.event.BeforeConvertCallback;
import org.springframework.jdbc.datasource.init.DataSourceInitializer;
import org.springframework.jdbc.datasource.init.ResourceDatabasePopulator;

import javax.sql.DataSource;
import java.util.UUID;

@Configuration
@EnableJdbcRepositories(basePackages = "com.siemens.backend.model.repositories")
public class ModelConfig extends AbstractJdbcConfiguration {

    @Bean
    DataSourceInitializer initializer(DataSource dataSource) {

        var initializer = new DataSourceInitializer();
        initializer.setDataSource(dataSource);

        var script = new ClassPathResource("schema.sql");
        var populator = new ResourceDatabasePopulator(script);
        initializer.setDatabasePopulator(populator);

        return initializer;
    }
}

