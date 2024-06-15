package com.siemens.backend.model.gna;

import com.siemens.backend.model.entities.ModelObject;

import java.util.function.Predicate;

public class GnaUtil {
    public static Predicate<GnaModelObject> getModelObjectHasOnlyGuid() {
        return modelObject -> modelObject.getGuid() != null
                && modelObject.getName() == null
                && modelObject.getClassName() == null
                && modelObject.getModelObjectType() == null
                && modelObject.getContainer().isEmpty()
                && modelObject.getNominalVoltage() == null
                && modelObject.getLinkedObjects() == null;
    }
}
