package com.siemens.backend.mapper.model;

import com.siemens.backend.api.graphqlTypes.ClassNameInfo;
import com.siemens.backend.mapper.FromMapper;
import org.springframework.stereotype.Component;

@Component
public class FromClassNameStringToClassNameInfo implements FromMapper<String, ClassNameInfo> {

    @Override
    public ClassNameInfo mapFrom(String object) {
        return ClassNameInfo
                .builder()
                .fullName(object)
                .shortName(shortenClassName(object))
                .build();
    }

    public String shortenClassName(String className) {
        return className.substring(Math.min(className.lastIndexOf(".") + 1,className.length()));
    }
}
