-- -------------------------------------------------------------------------------- --
-- 1.Beispiel - Migrationproject
-- -------------------------------------------------------------------------------- --
-- Schreiben Sie eine Stored Procedure zur Migration der Projektdaten in die
-- PROJECT_FUNDINGS_JT Tabelle.

-- Arbeiten Sie die folgendne Punkte ab:
--

-- 1) Legen Sie die folgende Tabelle an falls sie noch nicht existiert. Existiert
-- die Tabelle löschen Sie alle vorhandenen Datensätze.

-- 2) Definieren Sie einen Kursor. Durchlaufen Sie dazu eine SQL Abfrage die folgende
-- Daten erhebt. Der Kursor soll durchläuft dazu alle vorhandenen Projekte der
-- ursprünglichen Tabellenstruktur.

-- Tragen Sie für jedes Projekt Daten in die PROJECT_FUNDINGS_JT Tabelle ein.
-- Beachten Sie dass für Projekte mit mehreren Subprojekten mehrere Datensätze ein.

-- @PROJECT_ID: Die PROJECT_ID der Projekte
-- @DEBITOR_ID: Die ID des Geldgebers
-- @FACILITY_ID: SUBPROJECTS.FACILITY_ID
-- @FUNDING_AMOUNT: Erheben Sie gesamte Projektförderung des Projekts. Dividieren
-- Sie den Wert dann durch die Anzahl der Projekte.
-- @FUNDED_AT: Ermitteln Sie für das Projekt den aktuellsten APPROVED Zustand
-- aus der PROJECT_HAS_STATES_JT Tabelle. Übernehmen Sie den STATE_CHANGED_AT
-- Wert. Gibt es für ein Projekt keinen APPROVED Zustand tragen Sie den
-- CREATED_AT des Projekts ein.

-- 3) Konnte der Projekt/Subprojekt Datensatz erfolgreich migriert werden
-- soll ein entsprechender Datensatz in die MIGRATION_REPORTS Tabelle erfolgen.

-- @MIGRATION_REPORT: SUCCESSFUL

-- 4) Projekte die kein Projektfunding haben sollen nicht migriert werden.

-- a) Deklarieren Sie dazu eine eigene CONDITION SQLSTATE '45000'
-- b) Schreiben Sie einen eigenen CONDITION HANDLER der verhindert das Projekte
-- ohne Förderung migriert werden.
-- c) Löschen Sie alle Projektdaten die das entsprechende Projekt beschreiben.
-- Hinweis: Daten die auch von anderen Projekten genutzt werden dürfen nicht
-- gelöscht werden.


drop procedure if exists migrate_fundings;

create procedure migrate_fundings()
begin
    DECLARE l_project_id int;
    DECLARE l_debitor_id int;
    DECLARE done bool default false;
    DECLARE funding_amount int;
    DECLARE funded_at date;

    DECLARE no_funding_amount CONDITION FOR SQLSTATE '45000';

    DECLARE cur CURSOR FOR SELECT PROJECT_ID from migrationproject.PROJECTS_ST;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = true;

    DECLARE CONTINUE HANDLER FOR no_funding_amount
        BEGIN
            select 'hello';
            insert into MIGRATION_REPORTS (PROJECT_ID, SUBPROJECT_ID, MIGRATION_REPORT, MESSAGE_TYPE)
            select l_project_id, 0, 'no funding amount', 'ERROR'
            from projects.PROJECTS_BT P
            where P.PROJECT_ID = l_project_id;

            delete
                from PROJECTS_ST S
                    where S.PROJECT_ID = l_project_id;
        END;


    CREATE TABLE IF NOT EXISTS MIGRATION_REPORTS
    (
        MIGRATION_ID     INT         NOT NULL AUTO_INCREMENT,
        PROJECT_ID       INT         NOT NULL,
        SUBPROJECT_ID    INT         NOT NULL,
        MIGRATION_REPORT TEXT        NOT NULL,
        MESSAGE_TYPE     VARCHAR(20) NOT NULL,
        CREATED_AT       DATETIME    NOT NULL DEFAULT CURRENT_TIMESTAMP,
        PRIMARY KEY (MIGRATION_ID),
        CONSTRAINT CK_MIGRATION_REPORTS_MESSAGE_TYPE CHECK
            (MESSAGE_TYPE IN ('INFO', 'WARNING', 'ERROR'))
    );

    TRUNCATE MIGRATION_REPORTS;
    TRUNCATE migrationproject.PROJECT_FUNDINGS_JT;

    OPEN cur;
    process_project:
    LOOP
        FETCH cur INTO l_project_id;

        if done = true then
            LEAVE process_project;
        end if;

        select sum(AMOUNT) /
               (IF(count(DEBITOR_ID) = 0, 1, count(DEBITOR_ID)) *
                (IF((SELECT COUNT(SUBPROJECT_ID)
                     from projects.SUBPROJECTS
                     where projects.SUBPROJECTS.PROJECT_ID = l_project_id) =
                    0, 1, (SELECT COUNT(SUBPROJECT_ID)
                           from projects.SUBPROJECTS
                           where projects.SUBPROJECTS.PROJECT_ID = l_project_id))))
        into funding_amount
        from projects.PROJECT_DEBITORS_JT
        where PROJECT_ID = l_project_id;

        if funding_amount = 0 || funding_amount is null then
            SIGNAL SQLSTATE '45000';
        else
            select if(PHSJ.STATE_CHANGED_AT is not null, PHSJ.STATE_CHANGED_AT, p.CREATED_AT)
            into funded_at
            from projects.PROJECTS_BT p
                     left join (select p.PROJECT_ID,
                                       PHSJ.STATE_CHANGED_AT
                                from projects.PROJECTS_BT p
                                         left join projects.PROJECT_HAS_STATES_JT PHSJ on p.PROJECT_ID = PHSJ.PROJECT_ID
                                where PHSJ.PROJECT_STATE = 'APPROVED') PHSJ on p.PROJECT_ID = PHSJ.PROJECT_ID
            where p.PROJECT_ID = l_project_id;

            insert into migrationproject.PROJECT_FUNDINGS_JT (PROJECT_ID, DEBITOR_ID, FACILITY_ID, FUNDING_AMOUNT, FUNDED_AT)
            select d.PROJECT_ID,
                   d.DEBITOR_ID,
                   FS.FACILITY_ID,
                   funding_amount,
                   funded_at
            from projects.PROJECT_DEBITORS_JT d
                     inner join projects.PROJECTS_BT PB on d.PROJECT_ID = PB.PROJECT_ID
                     inner join projects.SUBPROJECTS s on s.PROJECT_ID = l_project_id
                     inner join projects.FACILITIES_ST FS on s.INSTITUTE_ID = FS.FACILITY_ID
            where d.PROJECT_ID = l_project_id;

            insert into MIGRATION_REPORTS (PROJECT_ID, SUBPROJECT_ID, MIGRATION_REPORT, MESSAGE_TYPE)
            select l_project_id, S.SUBPROJECT_ID, 'successful', 'INFO'
            from projects.SUBPROJECTS S
            where S.PROJECT_ID = l_project_id;
        end if;
    end LOOP;
    CLOSE cur;
end;

call migrate_fundings();

select *
from migrationproject.PROJECT_FUNDINGS_JT;

select *
from MIGRATION_REPORTS;
select *
from PROJECTS_ST;