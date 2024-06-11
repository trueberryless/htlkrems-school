-- ----------------------------------------------------------- --
--  1. Beispiel) Constraints, DDL Statements
-- ----------------------------------------------------------- --
-- Legen Sie die Tabelle PRODUCER AN:

CREATE TABLE PRODUCER
(
    PRODUCER_LABEL VARCHAR(100),
    PRIMARY KEY (PRODUCER_LABEL)
);

-- region 1.1) ALTER TABLE

-- Bennen Sie die Tabelle in PRODUCERS um:



-- FÜgen Sie folgende Spalte zur Tabelle hinzu:
-- CODE VARCHAR(5) NOT NULL UNIQUE



-- endregion

-- region 1.2) USER_CONSTRAINTS

-- Fragen Sie die Constraints der PRODUCERS Tabelle ab:

-- C    Check on a table           Column
-- O    Read Only on a view        Object
-- P    Primary Key                Object
-- R    Referential (Foreign Key)  Column
-- U    Unique Key                 Column
-- V    Check Option on a view     Object



-- der PRODUCER_LABEL soll einen NOT NULL Constraint bekommen:


-- endregion

-- region 1.3) INSERT INTO

-- FÜgen Sie 3 Datensatze in die Tablle ein:

INSERT INTO PRODUCERS (PRODUCER_LABEL, CODE)
VALUES ('COCA COLA COMPANY', 'COCE');
INSERT INTO PRODUCERS (PRODUCER_LABEL, CODE)
VALUES ('Radlberger Inc.', 'RADL');
INSERT INTO PRODUCERS (PRODUCER_LABEL, CODE)
VALUES ('Zwettler Brauerei Inc. ', 'MONK');

-- endregion
-- ----------------------------------------------------------- --
--  2. Beispiel) DDL Statements
-- ----------------------------------------------------------- --
-- Legen Sie die folgende Tabelle an.

CREATE TABLE BEVERAGES
(
    BEVERAGE_ID NUMBER(19, 0) NOT NULL,
    LABEL       VARCHAR(50)   NOT NULL,
    PRIMARY KEY (BEVERAGE_ID)
);

-- region 2.1) ALTER TABLE

-- Fügen Sie einen UNIQUE Constraint auf die LABEL Spalte hinzu:


-- Fügen Sie eine Fremdschlüssel auf die PRODUCERS Tabelle ein:



-- Schalten Sie den referentiellen Constraint  ab:


-- Pruefen Sie den Status der Constraints fuer die Tabelle:


-- endregion

-- region 2.2) DDL Statements

-- Legen Sie eine Sequenz und einen Trigger fuer die ID an.



-- Schalten Sie den Trigger aus und schreiben Sie die folgende Daten in
-- die Tabelle:


SELECT *
FROM PRODUCERS;

INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (1, 'Coca Cola', 'COCA COLA COMPANY');
INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (2, 'Coca Cola Classic', 'COCA COLA COMPANY');
INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (3, 'Coca Cola Vanille', 'COCA COLA COMPANY');

COMMIT;

-- Erhohen Sie sequenz entsprechend:

INSERT INTO BEVERAGES (LABEL, BEVERAGES.PRODUCER_LABEL)
values ('Coca Cola Zero', 'COCA COLA COMPANY');
COMMIT;
-- endregion

SELECT *
FROM BEVERAGES;
-- ----------------------------------------------------------- --
--  3. Beispiel) SOFT_DRINKS
-- ----------------------------------------------------------- --

-- region 3.1) ALTER TABLE

-- Benennen Sie die BEVERAGES Tabelle in BEVERAGES_BT um.


-- endregion

-- region 3.2) ALTER TABLE

-- Legen Sie die folgenden Tabllen an:

CREATE TABLE SOFT_DRINKS
(
    BEVERAGE_ID   NUMBER(19, 0) NOT NULL,
    SUGAR_CONTENT INTEGER,
    PRIMARY KEY (BEVERAGE_ID)
);

-- Definieren Sie folgenden Constraint fÜr die SUGAR_CONTENT
-- Spalte: SUGAR_CONTENT NUMBER(3) NOT NULL


-- Definieren Sie eine referentiellen Constraint auf die BEVERAGES_BT
-- Tabelle



-- endregion

-- region 3.3 ALTER TABLE

-- Fuegen Sie die folgenden Werte in die Tablle ein:


insert into BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (5, 'Ice Tea Zitron', 'Radlberger Inc.');
insert into BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (6, 'Ice Tea Pfirsich', 'Radlberger Inc.');

SELECT *
FROM BEVERAGES_BT;

INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (2, 2);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (3, 2);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (4, 0);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (5, 30);

COMMIT;
-- endregion

-- region 3.3) ALTER TABLE

-- SUGAR_CONTENT Werte muessen zwischen 0 und 100 liegen



INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (6, 200);

-- endregion

-- ----------------------------------------------------------- --
--  4. Beispiel) BEER
-- ----------------------------------------------------------- --

-- region 4.1) CREATE TABLE, ALTER TABLE

CREATE TABLE BEER
(
    BEVERAGE_ID       NUMBER(19, 0) NOT NULL,
    ALCOHOLIC_CONTENT INTEGER       NOT NULL,
    PRIMARY KEY (BEVERAGE_ID),
    CONSTRAINT FK_BEER_BEVERAGE_ID FOREIGN KEY (BEVERAGE_ID)
        REFERENCES BEVERAGES_BT (BEVERAGE_ID)
            ON DELETE CASCADE
);

-- ALCOHOLIC_CONTENT Werte muessen zwischen 0 und 15 liegen


-- Wird ein beverage Datensatz geloescht soll der entsprechende
-- BEER Datensatz automatisch geloescht werden.


-- endregion

-- region 4.2)
-- Fuegen Sie folgende Werte ein:

ALTER TRIGGER TR_BEVERAGES_BEVERAGE_ID DISABLE;
select * from BEVERAGES_BT;

INSERT INTO BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (9, 'Zwettler Bier', 'Zwettler Brauerei Inc. ');
INSERT INTO BEER (BEVERAGE_ID, ALCOHOLIC_CONTENT)
VALUES (9, 12);
INSERT INTO BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (8, 'Zwettler Bier Geisterbräu', 'Zwettler Brauerei Inc. ');
INSERT INTO BEER (BEVERAGE_ID, ALCOHOLIC_CONTENT)
VALUES (8, 14);

alter trigger TR_BEVERAGES_BEVERAGE_ID enable;
alter sequence SEQ_BEVERAGES_BEVERAGES_ID increment by 1;

-- endregion

-- region 4.3) TRUNCATE TABLE, DELETE
-- Loeschen Sie die Bier Datensaetze.


-- endregion

-- ----------------------------------------------------------- --
--  5. Beispiel) CUSTOMERS
-- ----------------------------------------------------------- --

-- region 5.1) CREATE TABLE

-- Legen Sie die folgende Tabelle an

CREATE TABLE CUSTOMERS
(
    CUSTOMER_ID NUMBER(19, 0) NOT NULL,
    FIRST_NAME  VARCHAR(50)   NOT NULL,
    LAST_NAME   VARCHAR(50)   NOT NULL,
    PRIMARY KEY (CUSTOMER_ID)
);

-- Spielen Sie die EMPLOYEES Datensatze in die CUSTOMERS Tabelle.



-- Aktivieren Sie das AUTO_INCREMENT

-- endregion

-- region 5.2) DML Statements

-- Loeschen Sie alle Customer die in der IT Abteilung arbeiten.


-- Fuegen Sie der Tabelle die folgende Spalte hinzu:
-- JOINED_AT DATE not null


-- Loeschen Sie alle Datensaetze


-- endregion

-- ----------------------------------------------------------- --
--  6. Beispiel) ORDERS
-- ----------------------------------------------------------- --

-- region 6.1) DDL Statements
-- Legen Sie die folgenden Datenbankobjkete an:

create table orders
(
    order_id   number(19, 0) not null,
    order_date date          not null,
    primary key (order_id)
);

insert into orders (order_id, order_date)
values (1, to_date('21.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (2, to_date('22.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (3, to_date('23.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (4, to_date('24.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (5, to_date('25.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (6, to_date('26.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (7, to_date('27.12.2020', 'dd.mm.yyyy'));
insert into orders (order_id, order_date)
values (8, to_date('28.12.2020', 'dd.mm.yyyy'));



create table customer_has_orders
(
   ...
);

insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (100, 1, 1, 1.25);
insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (100, 1, 2, 1.30);
insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (100, 1, 3, 1.30);

-- endregion

-- ----------------------------------------------------------- --
--  DELETE OBJECTS
-- ----------------------------------------------------------- --
drop table customer_has_orders;
drop table orders;
drop sequence seq_orders_order_id;
drop table CUSTOMERS;
drop sequence seq_customers_customer_id;
drop table BEER;
drop table SOFT_DRINKS;
drop table BEVERAGES_BT;
drop sequence SEQ_BEVERAGES_BEVERAGES_ID;
drop table PRODUCERS;
