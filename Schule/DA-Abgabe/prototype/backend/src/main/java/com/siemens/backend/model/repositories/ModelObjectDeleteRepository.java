package com.siemens.backend.model.repositories;

import org.springframework.stereotype.Service;

import java.sql.SQLException;
import java.util.UUID;

@Service
public class ModelObjectDeleteRepository {
    private final DeleteRepository deleteRepository;

    public ModelObjectDeleteRepository(DeleteRepository deleteRepository) {
        this.deleteRepository = deleteRepository;
    }

    public void deleteAllByIdArray(UUID[] idArray) throws SQLException {
        deleteRepository.deleteAllByIdArray(idArray, "connections", "referencer");
        deleteRepository.deleteAllByIdArray(idArray, "model_objects", "guid");
    }
}
