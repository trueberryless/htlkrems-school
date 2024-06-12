-- ---------------------------------------------------------------------- -
-- 1.1) Beispiel: Trigger (5.Punkte)
-- ---------------------------------------------------------------------- -
-- Entwickeln Sie für das Tracking der Änderungen der Daten der
-- PROJECT_FUNDINGS_JT Tabelle eine Lösung.

-- Es soll ersichtlich sein wer, wann welche Spalten der Tabelle mit
-- welcher Operation verändert hat. Falls gegeben soll der ursprüngliche
-- Wert einer Spalte bzw. der Wert mit dem sie ersetzt wurden
-- getrackt werden.

-- region

DROP TABLE TRACKERS;
DROP TABLE TRACKER_COLUMNS;

CREATE TABLE IF NOT EXISTS TRACKERS
(
    TRACKER_ID int auto_increment,
    USER       varchar(255) not null,
    OPERATION  varchar(255) not null,
    TIMESTAMP  datetime default CURRENT_TIMESTAMP,

    primary key (TRACKER_ID)
);

CREATE TABLE IF NOT EXISTS TRACKER_COLUMNS
(
    TRACKER_COLUMN_ID int auto_increment not null,
    TRACKER_ID        int                not null,
    COLUMN_NAME       varchar(255),
    OLD_VALUE         varchar(255),
    NEW_VALUE         varchar(255),

    primary key (TRACKER_COLUMN_ID, TRACKER_ID),
    foreign key (TRACKER_ID) references TRACKERS (TRACKER_ID)
);

DROP TRIGGER IF EXISTS tracker_insert;

CREATE TRIGGER tracker_insert
    AFTER INSERT
    ON migrationproject.PROJECT_FUNDINGS_JT
    FOR EACH ROW
BEGIN
    DECLARE TRACKER_ID INT;

    INSERT INTO TRACKERS (USER, OPERATION)
    select current_user,
           'INSERT';

    SET TRACKER_ID = last_insert_id();

    INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
    select TRACKER_ID, 'PROJECT_ID', null, NEW.PROJECT_ID
    from TRACKERS;

    INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
    select TRACKER_ID, 'DEBITOR_ID', null, NEW.DEBITOR_ID
    from TRACKERS;

    INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
    select TRACKER_ID, 'FACILITY_ID', null, NEW.FACILITY_ID
    from TRACKERS;

    INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
    select TRACKER_ID, 'FUNDED_AT', null, NEW.FUNDED_AT
    from TRACKERS;

    INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
    select TRACKER_ID, 'FUNDING_AMOUNT', null, NEW.FUNDING_AMOUNT
    from TRACKERS;
END;

DROP TRIGGER IF EXISTS tracker_update;

CREATE TRIGGER tracker_update
    AFTER UPDATE
    ON migrationproject.PROJECT_FUNDINGS_JT
    FOR EACH ROW
BEGIN
    DECLARE L_TRACKER_ID INT;

    INSERT INTO TRACKERS (USER, OPERATION)
    select current_user,
           'UPDATE';

    SET L_TRACKER_ID = last_insert_id();

    IF (OLD.PROJECT_ID <> NEW.PROJECT_ID) THEN
        INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
        select L_TRACKER_ID, 'PROJECT_ID', OLD.PROJECT_ID, NEW.PROJECT_ID
        from TRACKERS;
    END IF;

    IF (OLD.DEBITOR_ID <> NEW.DEBITOR_ID) THEN
        INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
        select L_TRACKER_ID, 'DEBITOR_ID', OLD.DEBITOR_ID, NEW.DEBITOR_ID
        from TRACKERS;
    END IF;

    IF (OLD.FACILITY_ID <> NEW.FACILITY_ID) THEN
        INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
        select L_TRACKER_ID, 'FACILITY_ID', OLD.FACILITY_ID, NEW.FACILITY_ID
        from TRACKERS;
    END IF;

    IF (OLD.FUNDED_AT <> NEW.FUNDED_AT) THEN
        INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
        select L_TRACKER_ID, 'FUNDED_AT', OLD.FUNDED_AT, NEW.FUNDED_AT
        from TRACKERS;
    END IF;

    IF (OLD.FUNDING_AMOUNT <> NEW.FUNDING_AMOUNT) THEN
        INSERT INTO TRACKER_COLUMNS (TRACKER_ID, COLUMN_NAME, OLD_VALUE, NEW_VALUE)
        select L_TRACKER_ID, 'FUNDING_AMOUNT', OLD.FUNDING_AMOUNT, NEW.FUNDING_AMOUNT
        from TRACKERS;
    END IF;
END;

DROP TRIGGER IF EXISTS tracker_delete;

CREATE TRIGGER tracker_delete
    AFTER DELETE
    ON migrationproject.PROJECT_FUNDINGS_JT
    FOR EACH ROW
BEGIN

END;

call migrate_fundings();

UPDATE PROJECT_FUNDINGS_JT
SET FUNDING_AMOUNT = 69
WHERE PROJECT_ID = 2;

DROP TABLE TRACKER_COLUMNS;
DROP TABLE TRACKERS;

-- endregion
