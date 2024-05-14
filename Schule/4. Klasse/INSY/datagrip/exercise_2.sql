-- ---------------------------------------------------------------------- -
-- 1. Beispiel: Subselect, WITH Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Es wird eine Aufstellung der Legal Foundations benötigt.

-- Geben Sie fuer jedes Projekt die folgenden Daten aus:
-- Ausgabe: LEGAL FOUNDATION LABEL, LEGAL FOUNDATION DESCRIPTION,
--          AVG_APPLIED_RESEARCH,COUNT_FACULTIES, SPENT_BUDGET,
--          PERCENT_OF_TOTAL_BUDGET

-- @AVG_APPLIED_RESEARCH: Durchschnittlicher Applied Reseach Anteil pro Legal Foundation

-- @COUNT_FACULTIES: Anzahl an eindeutig involvierten Facultäten pro Legal Foundation

-- @SPENT_BUDGET: Budget das für diese Legal Foundation investiert wurde

-- @PERCENT_OF_TOTAL_BUDGET: % Anteil aus dem Gesamt Budget

-- Sortieren Sie das Ergebnis nach der dem PERCENT_OF_TOTAL_BUDGET absteigend

select *
from E_LEGAL_FOUNDATIONS;
select *
from PROJECTS_BT;

-- endregion

-- ---------------------------------------------------------------------- -
-- 2. Beispiel: Subselect, WITH
-- ---------------------------------------------------------------------- -
-- region
-- Erweitern Sie Beispiel 1 um folgende Bedingung.
-- Nur alle Projekte berücksichtigen, welche mehr als 1 Subprojekt haben.


-- endregion

-- ---------------------------------------------------------------------- -
-- 3. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Finden Sie alle Projekte denen zumindestens 1 Subprojekt zugeordnet ist.
-- Geben Sie für Projekt Datensätze folgende Werte aus: PROJECT_ID, TITLE


-- Table: PROJECTS_BT, SUBPROJECTS

select pb.PROJECT_ID, pb.TITLE
from PROJECTS_BT PB
where EXISTS(select * from SUBPROJECTS S where S.PROJECT_ID = PB.PROJECT_ID);

-- endregion

-- ---------------------------------------------------------------------- -
-- 4. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Finden Sie alle Geldgeber die zumindestens ein Projekt finanziell unter-
-- stützen und im Namen FA haben.

-- Geben Sie für Debitor Datensätze folgende Werte aus: DEBITOR_ID, NAME


-- Table: DEBITORS, PROJECT_DEBITORS_JT

select d.DEBITOR_ID, d.name
from DEBITORS d
where exists(select * from PROJECT_DEBITORS_JT pd where pd.DEBITOR_ID = d.DEBITOR_ID)
  and d.name LIKE '%FA%';

-- endregion

-- ---------------------------------------------------------------------- -
-- 5. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie alle gesetzlichen Paragraphen (E_LEGAL_FOUNDATIONS) an, denen
-- zumindestens 1 Projekt zugeordnet ist.

-- Geben Sie für E_LEGAL_FOUNDATIONS Datensätze folgende Spalten aus: LABEL


-- Tables: E_LEGAL_FOUNDATIONS, PROJECTS_BT

select LABEL
from E_LEGAL_FOUNDATIONS lf
where exists(select * from PROJECTS_BT p where lf.LABEL = p.LEGAL_FOUNDATION);

select *
from PROJECTS_BT;

-- endregion

-- ---------------------------------------------------------------------- -
-- 6. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Finden Sie alle Projekte die keine finanzielle Unterstützung haben.
-- Geben Sie folgende Spalten aus: PROJECT_ID, TITLE


-- Table: PROJECTS_BT, PROJECT_DEBITORS_JT

select PROJECT_ID, TITLE
from PROJECTS_BT p
where not exists(select * from PROJECT_DEBITORS_JT pd where pd.PROJECT_ID = p.PROJECT_ID)

-- endregion

-- ---------------------------------------------------------------------- -
-- 7. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Finden Sie alle Institue (FACILITIES_ST.FACILITY_TYPE -> INSTITUTE) die
-- keine Subprojekte umgesetzt haben.

-- Geben Sie für Institute folgende Spalten aus:


-- Table: FACILITIES_ST, SUBPROJECTS

select *
from FACILITIES_ST f
where FACILITY_TYPE = 'INSTITUTE'
and not exists(select * from SUBPROJECTS s where s.INSTITUTE_ID = f.FACILITY_ID);

-- endregion

-- ---------------------------------------------------------------------- -
-- 8. Beispiel: Subselect, EXISTS Klausel
-- ---------------------------------------------------------------------- -
-- region

-- Finden Sie alle Projekte die nicht Vorgängeprojekte anderer Projekte sind.
-- Geben Sie für Projekte folgende Spalten aus: PROJECT_ID, TITLE


-- Table: PROJECTS_BT, PROJECT_FORERUNNERS_JT

select PROJECT_ID, TITLE from PROJECTS_BT p
where not exists(select * from PROJECT_FORERUNNERS_JT pf where pf.PARENT_ID = p.PROJECT_ID);

select * from PROJECT_FORERUNNERS_JT;

-- endregion


-- ---------------------------------------------------------------------- -
-- 9. Beispiel: Subselect
-- ---------------------------------------------------------------------- -
-- region

-- Wir würden gerne unsere Marketing Abteilung eine Abfrage erstellen.
-- Wir wollen alle Debitoren zu den NICHT von ihnen unterstützten Projekten anschreiben.
-- Dazu benötigen wir eine Liste mit den Debitoren und allen Projekten die sie momentan nicht unterstützen.

-- Spalten: PROJECT_ID,TITLE,DEBITOR_ID,NAME

-- Table: PROJECTS_BT, PROJECT_DEBITORS_JT, DEBITORS

select p.PROJECT_ID, p.TITLE, d.DEBITOR_ID, d.NAME from PROJECTS_BT p
    cross join DEBITORS D
where not exists(select * from PROJECT_DEBITORS_JT pd where p.PROJECT_ID = pd.PROJECT_ID and d.DEBITOR_ID = pd.DEBITOR_ID);


-- endregion

-- ---------------------------------------------------------------------- -
-- 10. Beispiel: Subselect
-- ---------------------------------------------------------------------- -

-- Finden Sie das Subprojekt mit dem hoechsten Wert fuer den FOCUS_RESEARCH.
-- Geben Sie fuer das Subprojekt die folgenden Spalten aus:
-- DESCRIPTION, PROJECT_ID, FOCUS_RESEARCH

-- Hinweis: Beachten Sie dass es mehrere Subprojekte mit einem maximalen
--          FOCUS_RESEARCH Wert geben kann.

-- Formulieren Sie die Abfrage einmal als INNERE VIEW und einmal als
-- konditionale Unterabfrage.

-- Tabellen: SUBPROJECTS

