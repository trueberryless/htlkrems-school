-- ------------------------------------------------------------------------
-- 1.1) SQL Klauseln
-- ------------------------------------------------------------------------
-- region

-- Geben Sie für Kreuzfahrten folgende Werte an:
-- LABEL, NAME, DISTANCE.

-- @LABEL -> CRUISES.LABEL
-- @NAME  -> SHIP.NAME
-- @ROUTE_NAME -> ROUTES_JT.NAME
-- @DISTANCE   -> ROUTES_JT.DISTANCE

-- Tables: CRUISES, CRUISE_HAS_ROUTES_JT, ROUTES_JT


-- endregion

-- ------------------------------------------------------------------------
-- 1.2) SQL Klauseln
-- ------------------------------------------------------------------------
-- region

-- Geben Sie für Kreuzfahrten folgende Werte an:
-- LABEL, DISTANCE, DISTANCE_CLASSIFICATION

-- @LABEL -> CRUISES.LABEL
-- @DISTANCE -> Die während der Kreuzfahrt zurückgelegte Länge der Summe
--              der Strecken

-- @DISTANCE_CLASSFICATION -> Entsprechend der zurückgelegten Strecke soll
--                            eine Klassifizierung angegeben werden:

--     0    < DISTANCE <= 1000     "SHORT_CRUISE"
--     1000 < DISTANCE <= 2000     "MEDIUM_CRUISE"
--     2000 < DISTANCE <= ....     "LONG_CRUISE"






-- endregion

-- ------------------------------------------------------------------------
-- 1.3) Subselect
-- ------------------------------------------------------------------------
-- region

-- Ermitteln Sie die Angestelltengruppe in der zur Zeit die meisten
-- Angestellten beschaeftigt sind.

-- Ausgabe: EMPLOYEE_TYPE, EMPLOYEE_COUNT

-- Tabellen: EMPLOYEE_ST




-- endregion

-- ------------------------------------------------------------------------
-- 1.4) Subselect
-- ------------------------------------------------------------------------
-- region

-- Fuer welches Land werden die meisten Haefen gespeichert. Geben Sie die
-- folgenden Spalten aus:

-- Ausgabe: COUNTRY, HARBOR_COUNT

-- Tabellen: HARBORS




-- endregion

-- ------------------------------------------------------------------------
-- 1.5) Subselect
-- ------------------------------------------------------------------------
-- region

-- Geben Sie die umsatzhoechste Buchung aus. Beruecksichtigen Sie nur
-- Buchungen die zwischen 2007 und 2020 abgeschlossen wurden.

-- Ausgabe: BOOKING_ID, TURNOVER

-- @TURNOVER: Beschreibt den gesamten Umsatz fuer eine Buchung.

-- Hinweis: Jeder CRUISE_HAS_BOOKINGS_JT Datensatz beschreibt welcher
--          Reisende, welche Kabine fuer welche Kreuzfahrt zu welchem
--          Preis erstanden im Rahmen welcher Buchung erstanden hat.

--          Eine Buchung kann aus mehreren CRUISE_HAS_BOOKING_JT
--          Datensaetzen bestehen!

-- Tabellen: CRUISE_HAS_BOOKINGS_JT, BOOKINGS


-- endregion

-- ------------------------------------------------------------------------
-- 1.6) Subselect
-- ------------------------------------------------------------------------
-- region

-- In welcher Rolle arbeiten die meisten Mitarbeiter auf der Kreuzfahrt mit
-- den meisten Mitarbeitern?

-- Geben Sie folgenden Spaltenwerte aus: CRUISE_id, EMPLOYEE_ROLE, EMPLOYEE_COUNT

-- @EMPLOYEE_COUNT: Anzahl der Angestellten die in der entsprechenden Rolle
--                  beschaeftigt sind.

-- Tabellen: CRUISE_HAS_EMPLOYEES



-- endregion

-- ------------------------------------------------------------------------
-- 2.1) Subselect: WITH Klausel
-- ------------------------------------------------------------------------
-- region

--  Zur Erstellung der jaehrlichen Bilanz soll fuer die gespeicherten Kreuz-
--  fahrten ein Report erstellt werden

-- Ermitteln Sie fuer jede Kreuzfahrt die folgenden Werte:

-- Ausgabe: CRUISE_ID, LABEL, DATE_OF_DEPARTUER, DURATION, EMPLOYEE_COUNT,
--          BOOKING_COUNT, SALES, BOOKED_CABINS

-- @DURATION: Anzahl der Tage
-- @EMPLOYEE_COUNT: Anzahl der Angestellten
-- @BOOKING_COUNT: Anzahl der Buchungen
-- @SALES: Durch Buchungen generierter Umsatz
-- @BOOKED_CABINS: Die Anzahl der gebuchten Kabinen
-- @DISTANCE:

-- Sortieren Sie das Ergebnis nach der Bezeichnung der Kreuzfahrten

-- Tabellen: CRUISES, CRUISE_HAS_EMPLOYEES_JT, CRUISE_HAS_BOOKINGS_JT






-- endregion

-- ------------------------------------------------------------------------
-- 2.2) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Schiffstypen an, die zumindestens einem Kreuzfahrschiff
-- zugeordnet sind.

-- Hinweis: Als Kreuzfahrtschiffe werden Schiffe bezeichnet die bei
--          Kreuzfahrten eingesetzt werden

-- Ausgabe: TYPE


-- Tables: E_SHIP_CLASSIFICATION, SHIPS, CRUISES



-- endregion

-- ------------------------------------------------------------------------
-- 2.3) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Häfen die zumindestens auf einer Route liegen.

-- Ausgabe: HARBOR_ID, NAME, COUNTRY


-- Tables: HARBORS, ROUTES_JT



-- endregion

-- ------------------------------------------------------------------------
-- 2.4) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Häfen die auf keiner Route liegen.

-- Ausgabe: HARBOR_ID, NAME, COUNTRY
-- Hinweis: Es gibt keine Route für die der DEPARTURE_HARBOR oder ARRIVAL_HARBOR
--          mit dem Hafen übereinstimmen


-- Tables: HARBORS, ROUTES_JT



-- endregion

-- ------------------------------------------------------------------------
-- 2.5) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Cruises, die zumindestens einmal gebucht worden sind.

-- Ausgabe: CRUISE_ID, LABEL

-- Tables: CRUISES, CRUISE_HAS_BOOKINGS_JT


-- endregion

-- ------------------------------------------------------------------------
-- 2.6) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Cruises, für die keine Buchungen vorliegen.

-- Ausgabe: CRUISE_ID, LABEL

-- Tables: CRUISES, CRUISE_HAS_BOOKINGS_JT



-- endregion

-- ------------------------------------------------------------------------
-- 2.7) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Geben Sie alle Schiffe aus, die keiner Cruise zugeordnet sind.

-- Ausgabe: SHIP_ID, NAME
--
-- @SHIP_ID -> SHIPS.SHIP_ID
-- @NAME    -> SHIPS.NAME

-- Tabellen: SHIPS, CRUISES



-- endregion

-- ------------------------------------------------------------------------
-- 2.8) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Kreuzfahrten die unterschiedliche Kontinente anfahren

-- Ausgabe: CRUISE_ID, LABEL

-- Tabellen: CRUISES, CRUISES_HAS_ROUTES_JT, ROUTES, HARBORS


-- Hinweis: Es existiert mindestens eine Teilstrecke der Kreuzfahrt deren
--          Abfahrts- und AnkunftsHafen auf unterschiedlichen Continenten liegt





-- endregion

-- ------------------------------------------------------------------------
-- 2.8) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Bestimmen Sie die Route mit dem höchsten Wert für die Streckenlänge
-- (DISTANCE).

-- Ausgabe: NAME, DISTANCE

-- Tabellen: ROUTES_JT


-- Hinweis: Es gibt keine Route mit einem höheren Wert der Streckenlänge (DISTANCE)



-- endregion

-- ------------------------------------------------------------------------
-- 2.9) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Finden Sie alle Kreuzfahrten, die auf jeder zugeordneten Teilstrecke mehr
-- als 500 km zurücklegt.

-- Ausgabe: CRUISE_ID, LABEL

-- Tabellen: CRUISES, ROUTES_JT, CRUISE_HAS_ROUTES_JT


-- Hinweis: Keine, der der Kreuzfahrt zugeordnete Teilstrecke ist kürzer als 500 km.



-- endregion

-- ------------------------------------------------------------------------
-- 2.10) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Gesucht sind Länder deren Häfen nicht alle auf Reiserouten liegen.

-- Ausgabe: NAME

-- Tabellen: E_COUNTRIES, HARBORS, ROUTES_JT





-- endregion


-- ------------------------------------------------------------------------
-- 2.11) EXISTS Klausel
-- ------------------------------------------------------------------------
-- region

-- Welches Schiff wird bei den meisten Kreuzfahrten eingesetzt?

-- Ausgabe: SHIP_ID, NAME

-- Tabellen: CRUISE, SHIP

-- region query1: GROUP BY


-- Hinweis: Es gibt kein Schiff das auf mehr Kreuzfahrten eingesetzt
--          worden ist



-- endregion
