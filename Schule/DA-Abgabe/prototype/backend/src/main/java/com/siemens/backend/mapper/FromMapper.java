package com.siemens.backend.mapper;

public interface FromMapper<F, T> {
    T mapFrom(F object);
}
