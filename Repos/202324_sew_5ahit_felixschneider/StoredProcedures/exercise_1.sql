use projects;


-- ---------------------------------------------------------------------- -
-- 1.1) Beispiel: Stored Procedures (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Schreiben Sie eine Stored Procedure CREATE_PROJECT_REPORTS, die
--           die folgende Logik ausführt.
--
--           - Legen Sie eine Tabelle PROJECT_REPORTS mit folgender Struktur an.
--             Übertragen Sie die Daten aus den entsprechenden Tabellen.
--
--             Hinweis: Verwenden Sie den CREATE TABLE ... SELECT ...
--
--           - Falls die PROJECT_REPORTS Tabelle bereits existiert löschen Sie sie.
--           - Rufen Sie die Prozedur auf


--   PROJECT_ID       PROJECTS_BT.PROJECT_ID
--   TITLE            PROJECTS_BT.TITLE
--   PROJECT_TYPE     VARCHAR2(40)
--   PROJECT_FUNDING  PROJECT_DEBITORS_JT.AMOUNT

-- endregion

drop procedure if exists CREATE_PROJECT_REPORTS;

CREATE PROCEDURE IF NOT EXISTS CREATE_PROJECT_REPORTS()
BEGIN
    drop table if exists PROJECT_REPORTS;

    create table PROJECT_REPORTS
    with PROJECT_TYPES as (select case
                                      when MP.PROJECT_ID is not null then 'MANAGEMENT_PROJECT'
                                      when RFP.PROJECT_ID is not null then 'REQUEST_FUNDING_PROJECT'
                                      when R.PROJECT_ID is not null then 'RESEARCH_PROJECT'
                                      end as PROJECT_TYPE,
                                  PROJECTS_BT.PROJECT_ID
                           from PROJECTS_BT
                                    left join projects.MANAGEMENT_PROJECTS MP on PROJECTS_BT.PROJECT_ID = MP.PROJECT_ID
                                    left join projects.REQUEST_FUNDING_PROJECTS RFP
                                              on PROJECTS_BT.PROJECT_ID = RFP.PROJECT_ID
                                    left join projects.RESEARCH_FUNDING_PROJECTS R
                                              on PROJECTS_BT.PROJECT_ID = R.PROJECT_ID),
         PROJECT_FUNDINGS as (select PROJECT_ID, sum(AMOUNT) PROJECT_FUNDING
                              from PROJECT_DEBITORS_JT
                              group by PROJECT_ID)
    select PROJECTS_BT.PROJECT_ID, TITLE, pt.PROJECT_TYPE, pf.PROJECT_FUNDING
    from PROJECTS_BT
             left join PROJECT_TYPES pt on PROJECTS_BT.PROJECT_ID = pt.PROJECT_ID
             left join PROJECT_FUNDINGS pf on PROJECTS_BT.PROJECT_ID = pf.PROJECT_ID;
END;

call CREATE_PROJECT_REPORTS();
-- endregion

-- ---------------------------------------------------------------------- -
-- 1.2) Beispiel: Stored Procedures  (1.Punkt)
-- ---------------------------------------------------------------------- -
-- Schreiben Sie die folgende StoredProcedure LOG. Führen Sie die folgenden
-- Schritte durch:
--
-- Signatur: LOG( IN P_LOG_TYPE  VARCHAR(5), IN P_PROCEDURE_NAME VARCHAR(32), IN MESSAGE TEXT)
--
--       1) Prüfen Sie ob der P_LOG_TYPE Parameter einen gültigen Wert hat
--          Hinweis: Sie können die EXISTS Klausel in IF Statements verwenden

--       2) Ist der Parameter gültig legen Sie die folgenden Tabellen an falls
--          es sie noch gibt: E_LOG_TYPES, LOGS
--
--          Prüfen Sie zuvor ob die beiden Tabellen bereits angelegt sind!
--          Sorgen Sie dafür dass die E_LOG_TYPES Werte eingetragen werden, falls
--          sie noch nicht eingetragen worden sind.
--
--       3) Tragen Sie den gewünschten Datensatz in die LOGS Tabelle ein
--       4) Rufen Sie die Prozedur auf

-- Theorie
-- Variablen:
--   IN ...... Initialisierte Konstante
--   OUT ..... Nicht initialisierte Variable
--   INOUT ... Initialisierte Variable

drop procedure if exists insert_log;

create procedure insert_log(
    in P_LOG_TYPE varchar(5),
    in P_PROCEDURE_NAME varchar(32),
    in P_MESSAGE text
)
begin
    CREATE TABLE if not exists E_LOG_TYPES
    (
        LOG_TYPE VARCHAR(5) NOT NULL,
        PRIMARY KEY (LOG_TYPE)
    );

    IF NOT EXISTS(SELECT *
                  FROM E_LOG_TYPES) THEN
        INSERT INTO E_LOG_TYPES (LOG_TYPE)
        VALUES ('INFO');
        INSERT INTO E_LOG_TYPES (LOG_TYPE)
        VALUES ('WARN');
        INSERT INTO E_LOG_TYPES (LOG_TYPE)
        VALUES ('ERROR');
        COMMIT;
    END IF;

    CREATE TABLE if not exists LOGS
    (
        LOG_ID         INT         NOT NULL AUTO_INCREMENT,
        LOGGED_AT      DATE        NOT NULL,
        LOG_TYPE       VARCHAR(5)  NOT NULL,
        PROCEDURE_NAME VARCHAR(32) NOT NULL,
        MESSAGE        TEXT        NOT NULL,
        PRIMARY KEY (LOG_ID),
        CONSTRAINT FK_LOGS_LOG_TYPE FOREIGN KEY (LOG_TYPE)
            REFERENCES E_LOG_TYPES (LOG_TYPE)
    );

    IF P_LOG_TYPE IN (SELECT * FROM E_LOG_TYPES)
    THEN
        INSERT INTO LOGS (LOGGED_AT, LOG_TYPE, PROCEDURE_NAME, MESSAGE)
        values (CURRENT_TIMESTAMP, P_LOG_TYPE, P_PROCEDURE_NAME, P_MESSAGE);
    end if;
end;

CALL insert_log('INFO', 'HUGO', 'Hugo mag Züge');

-- -------------------------------------------------------------------------- -
-- 1.3) Beispiel: Funktion  (1.Punkt)
-- -------------------------------------------------------------------------- -
-- Schreiben Sie eine Funktion die prüft ob eine bestimmte Tabelle existiert.
-- Rufen Sie die Funktion anschließend auf.
--
-- Hinweis: Mit folgender Abfrage können Informationen zur Struktur der
--          Datenbank abgefragt werden.
--
--          SELECT count(*)
--          FROM information_schema.TABLES
--          WHERE (TABLE_SCHEMA = 'your_db_name') AND (TABLE_NAME = 'name_of_table');
--
--
-- Hinweis: die SELECT INTO Klausel erlaubt das Setzten von Werten

-- Signatur: FUNCTION TABLE_EXISTS( IN P_SCHEMA VARCHAR(32), IN P_TABLE VARCHAR(32))
--           RETURNS TINYINT

-- Hinweis: Mit SELECT TABLE_EXISTS('projects', 'PROJECTS_BT') kann die Funktion
--          aufgerufen werden.


SELECT *
FROM information_schema.TABLES
WHERE (TABLE_SCHEMA = 'projects')
  AND (TABLE_NAME = 'PROJECTS_BT');

drop function if exists TABLE_EXISTS;

create function TABLE_EXISTS(P_SCHEMA VARCHAR(32), P_TABLE VARCHAR(32))
    RETURNS TINYINT
    deterministic
begin
    DECLARE L_TABLE_EXISTS tinyint default 0;

    SELECT count(*)
    into L_TABLE_EXISTS
    FROM information_schema.TABLES
    WHERE (TABLE_SCHEMA = P_SCHEMA)
      AND (TABLE_NAME = P_TABLE);

    return L_TABLE_EXISTS;
end;

select table_exists('projects', 'PROJECTS_BT') AS TABLE_EXISTS;



-- -------------------------------------------------------------------------- -
-- 1.4) Beispiel: Function  (1.Punkt)
-- -------------------------------------------------------------------------- -
-- Schreiben Sie eine Funktion die prüft ob eine Reihe von Tabellen existiert
-- bestimmte Tabelle existiert. Testen Sie die Funktion anschließend.
--
-- 1) Legen Sie außerhalb der Funktion die folgende Tabelle an:
--

DROP TABLE if exists M_TABLES;
CREATE TABLE IF NOT EXISTS M_TABLES
(
    TABLE_NAME  VARCHAR(32) NOT NULL,
    SCHEMA_NAME VARCHAR(32) NOT NULL,
    PRIMARY KEY (TABLE_NAME)
);

-- 2) Tragen Sie in die Tabelle jene Werte ein die der Prüfung unterzogen werden
--    sollen

-- 3) Schreiben Sie die Funktion:
--    Signatur: FUNCTION  TABLES_EXISTS() RETURNS TINYINT

--
-- Hinweis: Verwenden Sie die zuvor erstellte TABLE_EXISTS Funktion
-- Hinweis: Sie können eine Temporäre Tabelle erstellen um sie wie eine Collection
--          zu verwenden
--
--           CREATE TEMPORARY TABLE IF NOT EXISTS table_name SELECT ... ;
--           DROP TEMPORARY TABLE table_name;
--
-- Hinweis: Sie brauchen keine Schleifen!

REPLACE INTO M_TABLES (TABLE_NAME, SCHEMA_NAME) value ('PROJECTS_BT', 'projects');
REPLACE INTO M_TABLES (TABLE_NAME, SCHEMA_NAME) value ('EMPLOYEES', 'projects');

drop function if exists TABLES_EXIST;

create FUNCTION TABLES_EXIST() RETURNS TINYINT
    deterministic
begin
    declare L_COUNT_NOT_EXISTS tinyint default 1;

    CREATE TEMPORARY TABLE IF NOT EXISTS tables_exist
    SELECT TABLE_EXISTS(SCHEMA_NAME, TABLE_NAME) as table_exists from M_TABLES;

    SELECT count(table_exists)
    into L_COUNT_NOT_EXISTS
    from tables_exist
    where table_exists = 0;

    DROP TEMPORARY TABLE tables_exist;

    if L_COUNT_NOT_EXISTS = 0 then
        return 1;
    end if;

    return 0;
end;

select TABLES_EXIST();
