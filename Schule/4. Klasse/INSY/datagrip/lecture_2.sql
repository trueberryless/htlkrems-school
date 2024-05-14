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

-- Alle Daten des RequestFundingProjects
SELECT 'REQUEST', COUNT(RFP.PROJECT_ID)
FROM PROJECTS_BT
         JOIN REQUEST_FUNDING_PROJECTS RFP ON PROJECTS_BT.PROJECT_ID = RFP.PROJECT_ID
UNION
SELECT 'RESEARCH', COUNT(RFP.PROJECT_ID)
FROM PROJECTS_BT
         JOIN RESEARCH_FUNDING_PROJECTS RFP ON PROJECTS_BT.PROJECT_ID = RFP.PROJECT_ID
UNION
SELECT 'MANAGEMENT', COUNT(MP.PROJECT_ID)
FROM PROJECTS_BT
         JOIN MANAGEMENT_PROJECTS MP ON PROJECTS_BT.PROJECT_ID = MP.PROJECT_ID;

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

select PB.PROJECT_ID, pb.TITLE, 'PROJECT' AS EVENT_TYPE, PROJECT_STATE AS EVENT, STATE_CHANGED_AT AS DATE_OF_EVENT
from PROJECT_HAS_STATES_JT
         join PROJECTS_BT PB on PROJECT_HAS_STATES_JT.PROJECT_ID = PB.PROJECT_ID
UNION
select s.PROJECT_ID, pb.TITLE, 'SUBPROJECT' AS EVENT_TYPE, SUBPROJECT_STATE AS EVENT, STATE_CHANGED_AT AS DATE_OF_EVENT
from SUBPROJECT_HAS_STATES_JT
         join SUBPROJECTS S on S.SUBPROJECT_ID = SUBPROJECT_HAS_STATES_JT.SUBPROJECT_ID
         join PROJECTS_BT PB on S.PROJECT_ID = PB.PROJECT_ID
order by PROJECT_ID, DATE_OF_EVENT;

-- endregion

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

SELECT p.PROJECT_ID,
       p.TITLE,
       p.CREATED_AT                        PROJECT_BEGIN,
       phs.STATE_CHANGED_AT                PROJECT_END,
       phs.STATE_CHANGED_AT - p.CREATED_AT DAY_COUNT
FROM PROJECTS_BT p
         join PROJECT_HAS_STATES_JT phs
              on p.PROJECT_ID = phs.PROJECT_ID
where not exists(select *
                 from PROJECT_HAS_STATES_JT phs2
                 where phs.PROJECT_ID = phs2.PROJECT_ID
                   and phs.STATE_CHANGED_AT < phs2.STATE_CHANGED_AT)
  and p.PROJECT_ID not in (select s.PROJECT_ID from SUBPROJECTS s)
UNION
SELECT pb.PROJECT_ID,
       pb.TITLE,
       pb.CREATED_AT                         PROJECT_BEGIN,
       SHSJ.STATE_CHANGED_AT                 PROJECT_END,
       SHSJ.STATE_CHANGED_AT - pb.CREATED_AT DAY_COUNT
from PROJECTS_BT pb
         join SUBPROJECTS s on pb.PROJECT_ID = s.PROJECT_ID
         join SUBPROJECT_HAS_STATES_JT SHSJ on s.SUBPROJECT_ID = SHSJ.SUBPROJECT_ID
where not EXISTS(select *
                 from SUBPROJECT_HAS_STATES_JT SHSJ2
                          join SUBPROJECTS S2 on SHSJ2.SUBPROJECT_ID = S2.SUBPROJECT_ID
                 where pb.PROJECT_ID = s2.PROJECT_ID
                   and SHSJ.STATE_CHANGED_AT < SHSJ2.STATE_CHANGED_AT);

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
--
--                          höchsten Projektförderung
--

-- Tables: PROJECTS_BT, REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECTS, MANAGEMENT_PROJECTS
--         PROJECT_DEBITORS

SELECT 'REQUEST' AS PROJECT_TYPE, P.PROJECT_ID, SUM(PDJ.AMOUNT) AS FUNDING_AMOUNT
FROM PROJECTS_BT P
         JOIN REQUEST_FUNDING_PROJECTS RFP ON P.PROJECT_ID = RFP.PROJECT_ID
         JOIN PROJECT_DEBITORS_JT PDJ ON P.PROJECT_ID = PDJ.PROJECT_ID
GROUP BY P.PROJECT_ID
HAVING SUM(PDJ.AMOUNT) =
       (SELECT MAX(SUM(PDJ.AMOUNT))
        FROM PROJECTS_BT P
                 JOIN REQUEST_FUNDING_PROJECTS RFP ON P.PROJECT_ID = RFP.PROJECT_ID
                 JOIN PROJECT_DEBITORS_JT PDJ ON P.PROJECT_ID = PDJ.PROJECT_ID
        GROUP BY P.PROJECT_ID)
UNION
SELECT 'RESEARCH' AS PROJECT_TYPE, P.PROJECT_ID, SUM(J.AMOUNT) AS FUNDING_AMOUNT
FROM PROJECTS_BT P
         JOIN RESEARCH_FUNDING_PROJECTS R ON P.PROJECT_ID = R.PROJECT_ID
         JOIN PROJECT_DEBITORS_JT J ON P.PROJECT_ID = J.PROJECT_ID
GROUP BY P.PROJECT_ID
HAVING SUM(J.AMOUNT) =
       (SELECT MAX(SUM(J.AMOUNT))
        FROM PROJECTS_BT P
                 JOIN RESEARCH_FUNDING_PROJECTS R ON P.PROJECT_ID = R.PROJECT_ID
                 JOIN PROJECT_DEBITORS_JT J ON P.PROJECT_ID = J.PROJECT_ID
        GROUP BY P.PROJECT_ID)
UNION
SELECT 'MANAGEMENT' AS PROJECT_TYPE, P.PROJECT_ID, SUM(PDJ2.AMOUNT) AS FUNDING_AMOUNT
FROM PROJECTS_BT P
         JOIN MANAGEMENT_PROJECTS MP ON P.PROJECT_ID = MP.PROJECT_ID
         JOIN PROJECT_DEBITORS_JT PDJ2 ON P.PROJECT_ID = PDJ2.PROJECT_ID
GROUP BY P.PROJECT_ID
HAVING SUM(PDJ2.AMOUNT) =
       (SELECT MAX(SUM(PDJ2.AMOUNT))
        FROM PROJECTS_BT P
                 JOIN MANAGEMENT_PROJECTS MP ON P.PROJECT_ID = MP.PROJECT_ID
                 JOIN PROJECT_DEBITORS_JT PDJ2 ON P.PROJECT_ID = PDJ2.PROJECT_ID
        GROUP BY P.PROJECT_ID);



-- endregion

-- ------------------------------------------------------------------------
-- 2.5) INTERSECT Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Projekte aus die eine Forgängerprojekt haben und deren
-- Projektförderung höher ist als 50000

-- Ausage: PROJECT_ID, TITLE


-- Tables: PROJECTS_BT, PROJECT_FORERUNNERS_JT, PROJECT_FORERUNNERS_JTin

select pb.PROJECT_ID, pb.TITLE
from PROJECTS_BT pb
         join PROJECT_FORERUNNERS_JT PFJ on pb.PROJECT_ID = PFJ.PROJECT_ID
INTERSECT
select pb.PROJECT_ID, pb.TITLE
from PROJECT_DEBITORS_JT
         join PROJECTS_BT PB on PB.PROJECT_ID = PROJECT_DEBITORS_JT.PROJECT_ID
group by pb.PROJECT_ID, pb.TITLE
having sum(AMOUNT) > 50000;



SELECT p.PROJECT_ID, p.TITLE
FROM (SELECT PROJECT_ID
      FROM PROJECT_FORERUNNERS_JT
      INTERSECT
      SELECT PD.PROJECT_ID
      FROM PROJECT_DEBITORS_JT PD
      GROUP BY PD.PROJECT_ID
      HAVING SUM(PD.AMOUNT) > 50000) SUB
         JOIN PROJECTS_BT P ON P.PROJECT_ID = SUB.PROJECT_ID;

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


select DEBITOR_ID, NAME
from DEBITORS D
where exists(select *
             from PROJECT_DEBITORS_JT PD
                      join PROJECTS_BT P on PD.PROJECT_ID = P.PROJECT_ID
                      join REQUEST_FUNDING_PROJECTS RFP on P.PROJECT_ID = RFP.PROJECT_ID
             where PD.DEBITOR_ID = D.DEBITOR_ID)
intersect
select DEBITOR_ID, NAME
from DEBITORS
where DEBITOR_ID in (select D.DEBITOR_ID
                     from DEBITORS D
                              join PROJECT_DEBITORS_JT PD on D.DEBITOR_ID = PD.DEBITOR_ID
                     group by D.DEBITOR_ID
                     having sum(AMOUNT) > 20000);

select D2.DEBITOR_ID, D2.NAME
from (select D.DEBITOR_ID
      from DEBITORS D
               join PROJECT_DEBITORS_JT PDJ on D.DEBITOR_ID = PDJ.DEBITOR_ID
               join REQUEST_FUNDING_PROJECTS RFP on PDJ.PROJECT_ID = RFP.PROJECT_ID
      group by D.DEBITOR_ID
      having sum(AMOUNT) > 20000) SELECTION
         join DEBITORS D2 on D2.DEBITOR_ID = SELECTION.DEBITOR_ID;

-- endregion

-- ------------------------------------------------------------------------
-- 2.7) MINUS Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Projekte die weder Management- noch Researchfundingprojekte
-- sind aus.

-- Ausgabe: PROJECT_ID, TITLE


-- Tables: PROJECT_BT, MANAGEMENT_PROJECT, RESEARCH_FUNDING_PROJECTS

select P.PROJECT_ID, P.TITLE
from PROJECTS_BT P
minus
(select P.PROJECT_ID, P.TITLE
 from RESEARCH_FUNDING_PROJECTS RFP
          join PROJECTS_BT P on RFP.PROJECT_ID = P.PROJECT_ID
 union
 select P.PROJECT_ID, P.TITLE
 from MANAGEMENT_PROJECTS M
          join PROJECTS_BT P on P.PROJECT_ID = M.PROJECT_ID);


-- endregion
