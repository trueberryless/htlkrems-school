package com.siemens.backend.model.repositories;

import com.siemens.backend.model.entities.ModelObject;

import java.util.List;
import java.util.UUID;

public interface GraphModelObjectRepository {
    public List<ModelObject> getGraphModelObjectsByGuids(List<UUID> guids);
}
