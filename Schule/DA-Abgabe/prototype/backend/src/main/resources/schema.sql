CREATE TABLE IF NOT EXISTS model_objects (
    guid UUID PRIMARY KEY,
    name VARCHAR(255) NOT NULL ,
    class_name VARCHAR(255) NOT NULL ,
    container_id UUID,
    type VARCHAR(255) NOT NULL,
    nominal_voltage FLOAT
);
CREATE TABLE IF NOT EXISTS connections (
    guid UUID PRIMARY KEY,
    referencer UUID NOT NULL,
    referencing UUID NOT NULL
);


CREATE TABLE IF NOT EXISTS findings (
      guid UUID PRIMARY KEY,
      type VARCHAR(255) NOT NULL,
      severity VARCHAR(255) NOT NULL,
      category VARCHAR(255) NOT NULL,
      message TEXT NOT NULL,
      referenced_node UUID,
      referenced_container UUID,
      referenced_equipment UUID
);
