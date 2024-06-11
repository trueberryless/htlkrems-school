-- ------------------------------------------------------------------------
-- 2.1) UNION Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie für jeden Projekttyp die Anzahl der zugeordneten Projekte an.

-- Ausage: PROJECT_TYPE, PROJECT_COUNT

--         @PROJECT_TYPE: REQUEST_FUNDING_PROJECTS  -> REQUEST
--                        RESEARCH_FUNDING_PROJECTS -> RESEARCH
--                        MANAGEMENT_PROJECTS       -> MANAGEMENT

--         @PROJECT_COUNT: Anzahl der zugeordneten Projekte


-- Hinweis: Basistabelle -> PROJECTS_BT


-- Tables: PROJECTS_BT, REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECTS, MANAGEMENT_PROJECTS



-- endregion

-- ---------------------------------------------------------------------- -
-- 2.2 Union Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer jedes Projekt die folgenden Spalten aus: PROJECT_ID, TITLE
-- EVENT_TYPE, EVENT, DATE_OF_EVENT. Sortieren Sie das Ergebnis nach der
-- PROJECT_ID UND DEM DATE_OF_EVENT.

-- @EVENT: Fuer jedes Projekt sollen alle Events (PROJECT_STATE) der
--         PROJECT_HAS_STATES_JT Tabelle gemeinsam mit den Events der
--         zugeordneten Subprojekte ausgegeben werden.

-- @EVENT_TYPE: Gegen Sie 'PROJECT' fuer Projektevents und
--              'SUBPROJECT' fuer Subprojektevents aus

-- @DATE_OF_EVENT: Der Zeitpunkt an dem das Event eingetreten ist.


-- Tabellen: PROJECTS, PROJECT_HAS_STATES_JT, SUBPROJECTS,
--           SUBPROJECT_HAS_STATES_JT




-- ---------------------------------------------------------------------- -
-- 2.3 Beispiel: UNION, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer jedes Projekt die folgenden Daten aus: PROJECT_ID, TITLE
-- PROJECT_BEGIN, PROJECT_END, DAY_COUNT

-- Hinweis: Sie duerfen  zur Loesung der Aufgabe die GROUP BY Klausel nicht
--          verwenden.

-- @PROJECT_BEGIN: CREATED_AT

-- @PROJECT_END: Das Projektende entspricht dem letzten Statuswechsel
--               der Subprojekte des Projekts. Hat ein Projekt keine
--               zugeordneten Subprojekte wird das Datum des letzten
--               Statuswechsels des Projekts bestimmt.

-- Tabellen: PROJECTS, PROJECT_HAS_STATES_JT, SUBPROJECTS, SUBPROJECTS_HAS_STATES_JT




-- endregion


-- ------------------------------------------------------------------------
-- 2.4) UNION Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie für jeden Projekttyp das Projekt mit der höchsten Projekt-
-- förderung an.

-- Ausage: PROJECT_TYPE, PROJECT_ID, FUNDING_AMOUNT

--         @PROJECT_TYPE: REQUEST_FUNDING_PROJECTS  -> REQUEST
--                        RESEARCH_FUNDING_PROJECTS -> RESEARCH
--                        MANAGEMENT_PROJECTS       -> MANAGEMENT

--         @PROJECT_ID : Die PROJECT_ID des Projekts mit der höchsten
--                       Projektförderung für den entsprechenden
--                       PROJECT_TYPE

--         @FUNDING_AMOUNT: Die Projektförderung des Projekts mit der
--                          höchsten Projektförderung


-- Tables: PROJECTS_BT, REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECTS, MANAGEMENT_PROJECTS
--         PROJECT_DEBITORS



-- endregion


-- ------------------------------------------------------------------------
-- 2.5) INTERSECT Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Projekte aus die eine Forgängerprojekt haben und deren
-- Projektförderung höher ist als 50000

-- Ausage: PROJECT_ID, TITLE


-- Tables: PROJECTS_BT, PROJECT_FORERUNNERS_JT, PROJECT_FORERUNNERS_JT



-- endregion

-- ------------------------------------------------------------------------
-- 2.6) INTERSECT Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Geldgeber die ausschließlich Auftragsprojekte umsetzen und
-- insgesamt einen Umsatz von mindestens 20000 an Fördergeldern investiert
-- haben.

-- Ausgabe: DEBITOR_ID, NAME


-- Tables: DEBIORS, PROJECT_DEBITORS_JT, REQUEST_FUNDING_PROJECTS




-- endregion

-- ------------------------------------------------------------------------
-- 2.7) MINUS Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Projekte die weder Management- noch Researchfundingprojekte
-- sind.

-- Ausgabe: PROJECT_ID, TITLE


-- Tables: PROJECT_BT, MANAGEMENT_PROJECT, RESEARCH_FUNDING_PROJECTS



-- endregion
