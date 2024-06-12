-- -------------------------------------------------------------------------------- --
-- 1.Beispiel
-- -------------------------------------------------------------------------------- --
-- Schreiben Sie eine Prozedur die die folgenden Tabellen anlegt. Existieren die Tabellen
-- bereits, löschen Sie die eingetragenen Daten.


-- Hinweis: Verwenden Sie die TABLE_EXISTS Funktion zur Prüfung ob eine Tabelle
-- existiert.

CREATE FUNCTION TABLE_EXISTS(P_SCHEMA varchar(32), P_TABLE varchar(32))
    RETURNS TINYINT
    DETERMINISTIC
BEGIN
    DECLARE L_TABLE_EXISTS TINYINT DEFAULT 0;

    SELECT count(*)
    INTO L_TABLE_EXISTS
    FROM information_schema.TABLES
    WHERE (TABLE_SCHEMA = P_SCHEMA)
      AND (TABLE_NAME = P_TABLE);

    IF L_TABLE_EXISTS <> 0 THEN
        RETURN 1;
    ELSE
        RETURN 0;
    END IF;
END;

CREATE DATABASE IF NOT EXISTS migrationproject;
USE migrationproject;

drop procedure if exists create_base_tables;

create procedure create_base_tables()
begin

    set foreign_key_checks = 0;

    if TABLE_EXISTS('migrationproject', 'PROJECTS_ST') then
        truncate PROJECTS_ST;
    else
        CREATE TABLE PROJECTS_ST
        (
            PROJECT_ID       INT          NOT NULL,
            PROJECT_TYPE     VARCHAR(30)  NOT NULL,
            TITLE            VARCHAR(200) NOT NULL UNIQUE,
            DESCRIPTION      TEXT         NOT NULL,
            CREATED_AT       DATE         NOT NULL,
            LEGAL_FOUNDATION VARCHAR(4)   NOT NULL,
            IS_SMALL_PROJECT TINYINT      NOT NULL,
            IS_EU_SPONSORED  TINYINT      NOT NULL,
            IS_FFG_SPONSORED TINYINT      NOT NULL,
            IS_FWF_SPONSORED TINYINT      NOT NULL,
            PROJECT_START    DATE         NOT NULL,
            PROJECT_STATE    VARCHAR(20)  NOT NULL,
            PRIMARY KEY (PROJECT_ID),
            CONSTRAINT CK_PROJECTS_ST_TYPE CHECK ( PROJECT_TYPE IN
                                                   ('REQUEST_FUNDING_PROJECT', 'RESEARCH_FUNDING_PROJECT',
                                                    'MANAGEMENT_PROJECT') ),
            CONSTRAINT CK_PROJECTS_ST_PROJECT_STATE CHECK (PROJECT_STATE IN
                                                           ('APPROVED', 'CANCLED', 'DRAFT', 'FINISHED', 'IN_APPROVAL',
                                                            'RE_DRAFT', 'REJECTED', 'RUNNING')),
            CONSTRAINT CK_PROJECTS_ST_LEGAL CHECK ( LEGAL_FOUNDATION IN ('P_26', 'P_27', 'P_28', 'P_29', 'P_30'))
        );
    end if;

    if TABLE_EXISTS('migrationproject', 'DEBITORS') then
        truncate DEBITORS;
    else
        CREATE TABLE DEBITORS
        (
            DEBITOR_ID INT         NOT NULL AUTO_INCREMENT,
            NAME       VARCHAR(50) NOT NULL,
            PRIMARY KEY (DEBITOR_ID)
        );
    end if;

    if TABLE_EXISTS('migrationproject', 'FACILITIES') then
        truncate FACILITIES;
    else
        CREATE TABLE FACILITIES
        (
            FACILITY_ID INT          NOT NULL AUTO_INCREMENT,
            CODE        VARCHAR(7)   NOT NULL,
            TITLE       VARCHAR(100) NOT NULL,
            PRIMARY KEY (FACILITY_ID)
        );
    end if;

    if TABLE_EXISTS('migrationproject', 'PROJECT_FUNDINGS_JT') then
        truncate PROJECT_FUNDINGS_JT;
    else
        CREATE TABLE PROJECT_FUNDINGS_JT
        (
            PROJECT_ID     INT        NOT NULL,
            DEBITOR_ID     INT        NOT NULL,
            FACILITY_ID    INT        NOT NULL,
            FUNDING_AMOUNT DEC(10, 2) NOT NULL,
            FUNDED_AT      DATE       NOT NULL,
            PRIMARY KEY (PROJECT_ID, DEBITOR_ID, FACILITY_ID, FUNDED_AT),
            CONSTRAINT FK_PROJECT_FUNDINGS_PROJECT_ID FOREIGN KEY (PROJECT_ID)
                REFERENCES PROJECTS_ST (PROJECT_ID),
            CONSTRAINT FK_PROJECT_FUNDINGS_DEBITOR_ID FOREIGN KEY (DEBITOR_ID)
                REFERENCES DEBITORS (DEBITOR_ID),
            CONSTRAINT FK_PROJECT_FUNDINGS_FACILITY_ID FOREIGN KEY (FACILITY_ID)
                REFERENCES FACILITIES (FACILITY_ID)
        );
    end if;

    set foreign_key_checks = 1;
end;

call create_base_tables();


-- -------------------------------------------------------------------------------- --
-- 2.Beispiel
-- -------------------------------------------------------------------------------- --
-- Schreiben sie eine Prozedur zur Migration der folgenden Daten. Stellen Sie sicher
-- dass die Tabellen leer sind bevor Sie die Migration durchführen.


-- Tabelle: PROJECTS_ST

-- PROJECT_ID         -> PROJECTS_BT.PROJECT_ID
-- PROJECT_TYPE       -> Determine PROJECT_TYPE
-- (REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECT, MANAGEMENT_PROJECT)
-- TITLE              -> PROJECTS_BT.TITLE
-- DESCRIPTION        -> PROJECTS_BT.DESCRIPTION
-- CREATED_AT         -> PROJECTS_BT.CREATED_AT
-- LEGAL_FOUNDATION   -> PROJECTS_BT.LEGAL_FOUNDATION
-- IS_SMALL_PROJECT   -> A Project is considered to be a SMALL_PROJECT
-- if the project_funding doesn't exceed 50000
-- IS_EU_SPONSORED    -> RESEARCH_FUNDING_PROJECT.IS_EU_SPONSORED, if the project
-- has a different PROJECT_TYPE -> 0
-- IS_FFG_SPONSORED   -> RESEARCH_FUNDING_PROJECT.IS_FFG_SPONSORED, if the project
-- has a different PROJECT_TYPE -> 0
-- IS_FWF_SPONSORED   -> RESEARCH_FUNDING_PROJECT.IS_FWF_SPONSORED, if the project
-- has a different PROJECT_TYPE -> 0
-- PROJECT_START      -> the PROJECT_START date is equivalent to the PROJECT_HAS_STATES_JT
-- APPROVED State. If this entry doesn't exist PROJECTS_BT.CREATED_AT
-- PROJECT_STATE      -> the actural state of the project (PROJECT_HAS_STATES) do not use max


-- Tabelle: DEBITORS

-- DEBITOR_ID      ->   DEBITORS.DEBITOR_ID
-- NAME            ->   DEBITORS.NAME


-- Tabelle: FACILITIES

-- FACILITY_ID   ->  FACILITIES_ST.FACILITY_ID
-- CODE          ->  FACILITIES_ST.FACILITY_CODE
-- TITLE         ->  FACILITIES_ST.FACILITY_TITLE

drop procedure if exists migrate_projects;

create procedure migrate_projects()
begin
    insert into PROJECTS_ST (PROJECT_ID, PROJECT_TYPE, TITLE, DESCRIPTION, CREATED_AT, LEGAL_FOUNDATION,
                             IS_SMALL_PROJECT, IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, PROJECT_START,
                             PROJECT_STATE)
    with project_type as (select p.project_id,
                                 case
                                     when MP.PROJECT_ID is not null then 'MANAGEMENT_PROJECT'
                                     when RFP.PROJECT_ID is not null then 'RESEARCH_FUNDING_PROJECT'
                                     when R.PROJECT_ID is not null then 'REQUEST_FUNDING_PROJECT'
                                     end                                                 as PROJECT_TYPE,
                                 IF(RFP.PROJECT_ID is not null, RFP.IS_EU_SPONSORED, 0)  as IS_EU_SPONSORED,
                                 IF(RFP.PROJECT_ID is not null, RFP.IS_FFG_SPONSORED, 0) as IS_FFG_SPONSORED,
                                 IF(RFP.PROJECT_ID is not null, RFP.IS_FWF_SPONSORED, 0) as IS_FWF_SPONSORED
                          from projects.PROJECTS_BT p
                                   left join projects.MANAGEMENT_PROJECTS MP on p.PROJECT_ID = MP.PROJECT_ID
                                   left join projects.RESEARCH_FUNDING_PROJECTS RFP on p.PROJECT_ID = RFP.PROJECT_ID
                                   left join projects.REQUEST_FUNDING_PROJECTS R on p.PROJECT_ID = R.PROJECT_ID),
         is_small as (select p.PROJECT_ID, sum(PDJ.AMOUNT) < 50000 as IS_SMALL
                      from projects.PROJECTS_BT p
                               left join projects.PROJECT_DEBITORS_JT PDJ on p.PROJECT_ID = PDJ.PROJECT_ID
                      group by p.PROJECT_ID),
         start as (select p.PROJECT_ID,
                          if(PHSJ.STATE_CHANGED_AT is not null, PHSJ.STATE_CHANGED_AT, p.CREATED_AT) as STARTED_AT
                   from projects.PROJECTS_BT p
                            left join (select p.PROJECT_ID,
                                              PHSJ.STATE_CHANGED_AT
                                       from projects.PROJECTS_BT p
                                                left join projects.PROJECT_HAS_STATES_JT PHSJ on p.PROJECT_ID = PHSJ.PROJECT_ID
                                       where PHSJ.PROJECT_STATE = 'APPROVED') PHSJ on p.PROJECT_ID = PHSJ.PROJECT_ID),
         state as (select PHSJ.PROJECT_ID, PHSJ.PROJECT_STATE as PROJECT_STATE
                   from projects.PROJECT_HAS_STATES_JT PHSJ
                   where PHSJ.STATE_CHANGED_AT = (select max(PHSJ2.STATE_CHANGED_AT)
                                                  from projects.PROJECTS_BT p2
                                                           left join projects.PROJECT_HAS_STATES_JT PHSJ2
                                                                     on p2.PROJECT_ID = PHSJ2.PROJECT_ID
                                                  where PHSJ.PROJECT_ID = p2.PROJECT_ID
                                                  group by PHSJ2.PROJECT_ID))
    select p.PROJECT_ID           as PROJECT_ID,
           pt.PROJECT_TYPE        as PROJECT_TYPE,
           p.TITLE                as TITLE,
           p.DESCRIPTION          as DESCRIPTION,
           p.CREATED_AT           as CREATED_AT,
           p.LEGAL_FOUNDATION     as LEGAL_FOUNDATION,
           ifnull(sm.IS_SMALL, 1) as IS_SMALL,
           pt.IS_EU_SPONSORED     as IS_EU_SPONSORED,
           pt.IS_FFG_SPONSORED    as IS_FFG_SPONSORED,
           pt.IS_FWF_SPONSORED    as IS_FWF_SPONSORED,
           str.STARTED_AT         as PROJECT_START,
           ste.PROJECT_STATE      as PROJECT_STATE
    from projects.PROJECTS_BT p
             left join project_type pt
                       on p.PROJECT_ID = pt.PROJECT_ID
             left join is_small sm on p.PROJECT_ID = sm.PROJECT_ID
             left join start str on p.PROJECT_ID = str.PROJECT_ID
             left join state ste on p.PROJECT_ID = ste.PROJECT_ID;
end;

call migrate_projects();

SELECT *
FROM migrationproject.PROJECTS_ST;



drop procedure if exists migrate_debitors;

create procedure migrate_debitors()
begin
    insert into DEBITORS (DEBITOR_ID, NAME)
    select d.DEBITOR_ID, d.NAME
        from projects.DEBITORS d;
end;

call migrate_debitors();

select * from migrationproject.DEBITORS;



drop procedure if exists migrate_facilities;

create procedure migrate_facilities()
begin
    insert into FACILITIES (FACILITY_ID, CODE, TITLE)
    select f.FACILITY_ID, f.FACILITY_CODE as CODE, f.FACILITY_TITLE as TITLE
        from projects.FACILITIES_ST f;
end;

call migrate_facilities();

select * from migrationproject.FACILITIES;