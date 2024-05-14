-- ---------------------------------------------------------------------- -
-- 1. Beispiel) DDL Befehle
-- ---------------------------------------------------------------------- -


-- 1.0.1 Erstellen Sie die Datenbank USER_ASSIGNMENTS
create database USER_ASSIGNMENTS;

-- 1.0.2 Steigen Sie mittels Befehl in die neue Datenbank ein.
use USER_ASSIGNMENTS;


-- region Beschreibung) Jede Rolle im System wird durch eine Bezeichnung
--        (varchar(50) - not null, unique) identifiziert. Zusaetzlich
--        wird gespeichert wann (DATE - not null, default sysdate) die
--        Rolle angelegt worden ist. Gruppen und User sind Rollen.
--
--        Fuer eine Gruppe wird eine Funktionsbeschreibung (varchar(255))
--        gespeichert.

--        Fuer User wird ein Username (varchar(50) - not null, unique) und ein Passwort
--        (varchar(255) -  not null) gespeichert. Jeder User ist genau einer
--        Gruppe zugeordnet, die seine Hauptgruppe ist. Ein User kann beliebig
--        vielen Gruppen zugeordnet sein. Eine Gruppe besteht aus mehreren Usern.

-- endregion

-- region role-schema
create table ROLE_BT (
    ROLE_ID int primary key auto_increment,
    DESIGNATION varchar(50) not null,
    CREATED_AT DATE not null default (current_timestamp)
);

alter table roles_bt add constraint UX_DESIGNATION UNIQUE(DESIGNATION);

rename table ROLE_BT to ROLES_BT;

create table GROUPES (
    ROLE_ID int PRIMARY KEY,
    DESCRIPTION varchar(255) not null
);

alter table GROUPES add constraint FX_ROLE_ID foreign key (ROLE_ID) references ROLES_BT (ROLE_ID);

-- alter table GROUPES rename constraint FK_ROLE_ID foreign key (ROLE_ID) references ROLES_BT (ROLE_ID);

describe GROUPES;

create table USERS (
    ROLE_ID int PRIMARY KEY,
    USERNAME varchar(50) not null UNIQUE,
    PASSWORD varchar(255) not null
);

create table USER_HAS_GROUPES_JT (
    USER_ID int,
    GROUPES_ID int,
    PRIMARY KEY (USER_ID, GROUPES_ID)
);

alter table USER_HAS_GROUPES_JT rename column GROUPES_ID to GROUP_ID;

alter table USER_HAS_GROUPES_JT add constraint FK_USER_ID foreign key (USER_ID) references USERS (ROLE_ID);
alter table USER_HAS_GROUPES_JT add constraint FK_GROUPES_ID foreign key (GROUPES_ID) references GROUPES (ROLE_ID);

alter table USERS
    add column GROUP_ID int not null,
    add constraint FK_GROUP_ID foreign key (GROUP_ID) references GROUPES (ROLE_ID);



show tables;
describe roles_bt;
describe users;
describe groupes;
describe user_has_groupes_jt;


-- endregion

-- region 1.1) ALTER TABLE, CREATE TABLE

-- Verwenden Sie den ALTER TABLE Befehl um die Struktur der ROLES u. GROUPES
-- Tabellen entsprechend der Beschreibung des role Schemas zu adaptieren.

-- Hinweis: Implementieren Sie alle erforderlichen Constraints!

-- Hinweis: Beachten Sie die nachfolgenden INSERT Statements!

-- ROLES TABLE: ALTER TABLE

-- 1) Änders Sie den Namen der Tabelle auf ROLES_BT.

-- 2) Ändern Sie die Spalte ROLE_ID auf VARCHAR(50)

-- 3) Fügen Sie die Spalte CREATED_AT mit dem Standardwert der Systemzeit (date - not null)


-- GROUPES TABLE: ALTER TABLE

-- 1) Änders Sie die Spalte ROLE_ID auf VARCHAR(50)

-- 2) Fügen Sie einen Fremdschlüssel auf die Roles_BT Tabelle ein. Es sollte beim löschen der Rollen auch alle Gruppen mitgelöscht werden.
alter table users drop constraint FK_GROUP_ID;
alter table users add constraint FK_GROUP_ID foreign key (ROLE_ID) references roles_bt (ROLE_ID) on delete cascade;



-- USERS TABLE: ALTER TABLE

-- 1) Änders Sie die Spalte USER_NAME auf (VARCHAR(50) - unique)

-- 2) Änders Sie die Spalte ROLE_ID auf VARCHAR(50)

-- 3) Fügen Sie einen Fremdschlüssel auf die Roles_BT Tabelle ein. Es sollte beim löschen der Rollen auch alle Gruppen mitgelöscht werden.

-- 4) Fügen Sie eine Spalte DEFAULT_GROUP_ID (VARCHAR(50) NOT NULL) ein. Und diese sollte auch einen Fremdschlüssel auf die Groups (ROLE_ID) haben



-- GROUP_HAS_USERS TABLE:
-- Erstellen Sie eine Tabelle GROUP_HAS_USERS_JT mit folgenden Spalten:
--   GROUP_ID (VARCHAR(50) - NOT NULL), PK , FK (GROUPS - ROLE_ID)
--   USER_ID  (VARCHAR(50) - NOT NULL), PK , FK (USERS - ROLE_ID)






-- endregion

-- region Daten)

-- Spielen Sie die folgenden Daten in das Schema ein.

-- Hinweise: Aendern Sie die INSERT Statements nicht!

INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('SCHOOL_GR');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('3AHIT_GR');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('4AHIT_GR');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('4CHIT_GR');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('MEIER_USER');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('WAGNER_USER');
INSERT INTO ROLES_BT (ROLE_ID)
VALUES ('WANDL_USER');

INSERT INTO GROUPES (ROLE_ID, DESCRIPTION)
VALUES ('SCHOOL_GR', 'Group representing all users');
INSERT INTO GROUPES (ROLE_ID, DESCRIPTION)
VALUES ('3AHIT_GR', 'Group representing the student of a single class');
INSERT INTO GROUPES (ROLE_ID, DESCRIPTION)
VALUES ('4AHIT_GR', 'Group representing the student of a single class');
INSERT INTO GROUPES (ROLE_ID, DESCRIPTION)
VALUES ('4CHIT_GR', 'Group representing the student of a single class');


INSERT INTO USERS (ROLE_ID, USER_NAME, PASSWORD, DEFAULT_GROUP_ID)
VALUES ('MEIER_USER', 'meier@htlkrems.at', 'kuku', '3AHIT_GR');
INSERT INTO USERS (ROLE_ID, USER_NAME, PASSWORD, DEFAULT_GROUP_ID)
VALUES ('WAGNER_USER', 'wagner@htlkrems.at', 'karlfranz', '3AHIT_GR');
INSERT INTO USERS (ROLE_ID, USER_NAME, PASSWORD, DEFAULT_GROUP_ID)
VALUES ('WANDL_USER', 'wandl@htlkrems.at', 'moritari', '4CHIT_GR');

INSERT INTO GROUP_HAS_USERS_JT
VALUES ('3AHIT_GR', 'MEIER_USER');
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('3AHIT_GR', 'WAGNER_USER');
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('4CHIT_GR', 'WANDL_USER');
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('SCHOOL_GR', 'WANDL_USER');
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('SCHOOL_GR', 'MEIER_USER');
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('SCHOOL_GR', 'WAGNER_USER');

-- endregion

-- region 1.2) CONSTRAINTS

-- Listen Sie alle Constraints der ROLES_BT, GROUPES und USERS Tabellen auf. Welche der
-- Constraints sind dafuer verantwortlich dass die Datenbank die Relation zwischen
-- ROLES_BT und USERS als 1:1 Beziehung erkennt?


-- endregion

-- region 1.3) CONSTRAINTS

-- Fuehren Sie die folgenden INSERT Statements aus. Erklaeren Sie warum die Ausfuehrung der Befehle
-- zu einem Fehler fuehrt.

-- 1.3.1)
INSERT INTO GROUP_HAS_USERS_JT
VALUES ('SCHOOL_GR', 'HETZI_USER');

-- 1.3.1)
INSERT INTO GROUPES (ROLE_ID, DESCRIPTION)
VALUES ('3BHIT_GR', 'Group representing the student of a single class');



-- endregion


-- region release resources
-- 1) Entfernen Sie alle Tabellen.





-- endregion




-- ---------------------------------------------------------------------- -
-- 2. Beispiel) DDL Befehle
-- ---------------------------------------------------------------------- -

-- region Angabe) Spielen Sie Daten und die Struktur des project-schemas in die Datenbank ein.
--                Erstellen Sie anschliessend mit der Hilfe des CREATE TABLE SELECT
--                Befehls die Tabelle PROJECT_REPORTS.

--                Spielen Sie die Daten des project-schemas anschliessend mit dem
--                INSERT SELECT Befehls in die PROJECT_REPORTS Tabelle.

-- endregion

-- region project schema)

-- 2.1.1 Erstellen Sie die Datenbank PROJECT_FUNDING_DDL_DML
create database PROJECT_FUNDING_DDL_DML;

-- 2.1.2 Steigen Sie mittels Befehl in die neue Datenbank ein.
use PROJECT_FUNDING_DDL_DML;

-- 2.2 Fügen Sie folgendes Schema in die neue Datenbank ein.

CREATE TABLE e_legal_foundations
(
    label varchar(4) not null,
    primary key (label)
);

insert into e_legal_foundations
values ('P_26');
insert into e_legal_foundations
values ('P_27');
insert into e_legal_foundations
values ('P_28');

CREATE TABLE projects
(
    PROJECT_ID       INTEGER NOT NULL AUTO_INCREMENT,
    TITLE            VARCHAR(100)  NOT NULL UNIQUE,
    DESCRIPTION      VARCHAR(4000),
    legal_foundation varchar(4)    not null,
    primary key (PROJECT_ID),
    constraint fk_projects_project_id foreign key (legal_foundation)
        references e_legal_foundations (label)
);

SET FOREIGN_KEY_CHECKS = 0;

INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (1,
        'Finite Elemente in der Simulation. Zur Simulation der Kraftstoffverbrennung in Motoren sollen Finite Elemente Methoden eingesetzt werden.',
        'P_26', 'Finite Elemente in der Simulation');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (2,
        'Schnellhärteverfahren in der Betontechnik. Für den Einsatz unter extremen Bedingungen (Brückenbau) sollen Schnellhärteverfahren in der Betontechnik gefunden werdne.',
        'P_28', 'Schnellhärteverfahren in der Betontechnik');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (3, 'AI in der Robotertechnik. Entwickeln einer leistungsstarken AI für die Robotersteuerung im Roboterfussball',
        'P_27', 'AI in der Robotortechnik');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (4, 'Brückenbau im Meer. Es sollen Methoden zum Brückenbau zwischen Inseln erdacht und perfektioniert werden',
        'P_28', 'Brückenbau im Meer');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (5, 'Aufschüttung von künstlichen Inseln', 'P_28', 'Aufschüttung von künstlichen Inseln');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (6, 'Bau von industriellen Flughäfen auf künstlichen Inseln.', 'P_28',
        'Bau von industriellen Flughäfen auf künstlichen Inseln');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (7, 'Numerische Methoden in der Differentiellen Analysis', 'P_27',
        'Numerische Methoden in der Differentiellen Analysis');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (8, 'Numerische Methoden in der Geometrischen Algebra', 'P_27',
        'Numerische Methoden in der Geometrischen Algebra');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (9, 'Computeralgorithmen auf Graphen', 'P_27', 'Computeralgorithmen auf Graphen');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (10, 'Computeralgorithmen in der Diskreten Mathematik', 'P_27',
        'Computeralgorithmen in der Diskreten Mathmatik');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (11, 'Statistische Prognosen in der Wahlanalyse', 'P_28', 'Statistische Prognosen in der Wahlanalyse');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (12, 'Algorithmen in der Mustererkennung', 'P_26', 'Algorithmen in der Mustererkennung');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (13, 'Gesichtsmerkmale in der Mustererkennung', 'P_26', 'Gesichtmerkmale in der Mustererkennung');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (14, 'Generierung von Zufallszahlen', 'P_27', 'Generierung von Zufallszahlen');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (15, 'Gleichverteilte Zufallszahlen in statistischen Algorithmen', 'P_26',
        'Gleichverteilte Zufallszahlen in statistischen Algorithmen');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (16, 'Codierungsverfahren', 'P_26', 'Codierungsverfahren');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (17, 'Codes in der Gruppenalgebra', 'P_27', 'Codes in der Gruppenalgebra');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (18, 'Kürzeste Wege in Graphen berechnen', 'P_27', 'Kürzeste Wege in Graphen berechnen');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (19, 'Numerische Methoden für die Fourier Transformation', 'P_28',
        'Numerische Methoden für die Fourier Transformation');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (20, 'Infrastruktur im alpinen Gelände', 'P_28', 'Infrastruktur im alpinen Gelände');
INSERT INTO projects (PROJECT_ID, description, legal_foundation, title)
VALUES (21, 'Tunnelbau im alpienen Gelände', 'P_28', 'Tunnelbau im alpinen Gelände');


create table research_funding_projects
(
    project_id       INTEGER not null,
    is_eu_sponsored  boolean      not null,
    is_ffg_sponsored boolean      not null,
    is_fwf_sponsored boolean      not null,
    primary key (project_id),
    constraint fk_rfp_project_id foreign key (project_id)
        references projects (PROJECT_ID)
            on delete cascade
);

INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 0, 1);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (1, 1, 0, 3);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 1, 1, 7);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 1, 1, 8);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 1, 9);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 1, 10);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 0, 12);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 0, 13);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (1, 0, 0, 14);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 0, 15);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 0, 16);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (1, 1, 0, 17);
INSERT INTO research_funding_projects (IS_EU_SPONSORED, IS_FFG_SPONSORED, IS_FWF_SPONSORED, project_id)
VALUES (0, 0, 1, 18);

create table request_funding_projects
(
    project_id       integer not null,
    is_small_project boolean     not null,
    primary key (project_id),
    constraint fk_researchfp_project_id foreign key (project_id)
        references projects (PROJECT_ID)
            on delete cascade
);

-- REQUEST_FUNDING_PROJECT
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 2);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 4);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 5);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 6);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 11);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (1, 19);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 20);
INSERT INTO request_funding_projects (is_small_project, project_id)
VALUES (0, 21);

create table debitors
(
    debitor_id  integer not null AUTO_INCREMENT,
    description varchar(100) not null,
    name        varchar(20)   not null unique,
    primary key (debitor_id)
);


INSERT INTO debitors (debitor_id, description, name)
VALUES (1, 'Forschungsförderungsgesellschaft', 'FFG');
INSERT INTO debitors (debitor_id, description, name)
VALUES (2, 'Fonds für Wissenschaftliche Förderung', 'FWF');
INSERT INTO debitors (debitor_id, description, name)
VALUES (3, 'EU Forschungsfond', 'EUFA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (4, 'EU Wissenschaftsfond', 'EUWF');
INSERT INTO debitors (debitor_id, description, name)
VALUES (5, 'Siemens Forschungsabteilung', 'Siemens FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (6, 'ÖBB Forschungsabteilung', 'ÖBB FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (7, 'VÖST Forschungsabteilung', 'Vöst FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (8, 'Strabag', 'Strabag FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (9, 'Deutsche Bahn Forschungsabteilung', 'DB FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (10, 'SAP', 'SAP FA');
INSERT INTO debitors (debitor_id, description, name)
VALUES (11, 'Uni Regensburg', 'Uni Regensburg');
INSERT INTO debitors (debitor_id, description, name)
VALUES (12, 'Uni Berlin', 'Uni Berlin');
INSERT INTO debitors (debitor_id, description, name)
VALUES (13, 'Uni Linz', 'Uni Linz');
INSERT INTO debitors (debitor_id, description, name)
VALUES (14, 'Uni Wien', 'Uni Wien');
INSERT INTO debitors (debitor_id, description, name)
VALUES (15, 'Uni Hamburg', 'Uni Hamburg');

create table project_debitors
(
    debitor_id integer not null,
    project_id integer not null,
    amount     decimal(10, 2) not null,
    primary key (debitor_id, project_id),
    constraint fk_pd_debitor_id foreign key (debitor_id)
        references DEBITORS (debitor_id),
    constraint fk_pd_project_id foreign key (project_id)
        references projects (PROJECT_ID)
);

INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (10000.00, 12, 1);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (30000.00, 9, 1);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (15000.00, 13, 2);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (30000.00, 1, 3);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (35000.00, 13, 4);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (100000.00, 7, 4);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (150000.00, 8, 5);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (10000.00, 13, 6);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (5000.00, 5, 6);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (5000.00, 1, 7);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (10000.00, 3, 7);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (50000.00, 1, 8);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (15000.00, 2, 9);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (14000.00, 2, 10);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (12000.00, 14, 11);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (25000.00, 9, 12);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (10000.00, 9, 13);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (12000.00, 2, 14);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (50000.00, 12, 15);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (10000.00, 11, 16);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (5000.00, 3, 17);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (12000.00, 1, 18);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (23000.00, 5, 19);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (30000.00, 13, 20);
INSERT INTO project_debitors (amount, debitor_id, project_id)
VALUES (25000.00, 13, 21);

set FOREIGN_KEY_CHECKS = 1;

commit;

-- endregion

-- region 2.3) CREATE TABLE AS SELECT...

-- Verwenden Sie den CREATE TABLE AS SELECT um die PROJECT_REPORTS Tabelle anzulegen und
-- die entsprechenden Daten in die Datenbank einzuspielen.

-- PROJECT_REPORTS: PROJECT_ID, PROJECT_TYPE, TITLE

-- @PROJECT_ID: Die ID des Projekts

-- @PROJECT_TYPE: Der Typ des Projekts. Der Typ eines Projekts ist entweder 'REQUEST_FUNDING'
--                oder 'RESEARCH_FUNDING'. Der Projekttyp ist davon abhaengig ob ein
--                Projekt ein REQUEST_FUNDING_PROJECT bzw. ein RESEARCH_FUNDING_PROJECT ist.

-- @TITLE: Der Titel des Projekts

CREATE TABLE TEST AS SELECT 'JKA' AS NAME;




-- endregion

-- region 2.2) ALTER TABLE

-- Verwenden Sie den ALTER TABLE Befehl um die folgenden Aenderungen in
-- Datenbank einzupflegen.

-- 2.2.1) Definieren Sie PROJECT_ID als PRIMARY KEY. Legen Sie ebenfalls
--        einen entsprechenden FOREIGN KEY Constraint an.





-- 2.2.2) Fuegen Sie die Spalte VERSION (Integer - not null, default 1)
--        zur Tabelle hinzu.





-- 2.2.3) Stellen Sie sicher dass nur 'REQUEST_FUNDING' und 'RESEARCH_FUNDING' als
--        Werte in die PROJECT_TYPE Spalte eingetragen werden duerfen.




-- 2.2.4) Fuegen Sie die Spalte RATING (DECIMAL(2) - not null, default 0) zur
--        Tabelle hinzu. Die RATING Spalte darf nur Werte zwischen 0 und 10
--        aufnehmen.






-- endregion

-- region 2.3) UPDATE

-- 2.3.1) Erhöhen Sie das RATING der REQUEST_FUNDING_PROJECT Projekte um 2.
--        Wird ein Datensatz veraendert muss seine Versionsnummer auch um
--        1 erhoeht werden.





-- 2.3.2) Erhöhen Sie das RATING von Projekten um 1 die von der EU gefoerdert werden.
--        Veraendern Sie die Versionsnr der Projekte entsprechend

-- Hinweis: RESEARCH_FUNDING_PROJECTS -> IS_EU_SPONSORED





-- 2.3.3) Erhöhen Sie das RATING von Projekten mit einer Projektfoerderung die hoher ist als 5000 um 2.
--        Veraendern Sie die Versionsnr der Projekte entsprechend.

-- Hinweis: Die Projektfoerderung wird in der PROJECT_DEBIOTRS Tabelle verwaltet. Ein
--          PROJECT_DEBITORS Datensatz beschreibt welches Projekt von welchem Geldgeber mit
--          welchem Geldbetrag unterstuetzt wird.





-- 2.3.4 Loeschen Sie alle Projekte mit einem RATING <= 2




-- endregion

-- region 2.4) DROP TABLE

-- Loeschen Sie alle Datenbankobjekte die Sie fuer das Beispiel angelegt haben.

-- endregion