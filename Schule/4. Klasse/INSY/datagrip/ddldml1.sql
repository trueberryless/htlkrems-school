-- Legen Sie die Datenbank restaurant_insy
create database restaurant_insy;


-- ----------------------------------------------------------- --
--  1. Beispiel) Constraints, DDL Statements
-- ----------------------------------------------------------- --
-- Legen Sie die Tabelle PRODUCER mit folgenden Spalten an:
--    PRODUCER_LABEL TEXT 100 Zeichen
--    Die Spalte sollte auch der Primary Key sein

create table PRODUCER
(
    PRODUCER_LABEL varchar(100) PRIMARY KEY
);

create table PRODUCER
(
    PRODUCER_LABEL varchar(100),
    PRIMARY KEY (PRODUCER_LABEL)
);

-- region 1.1) ALTER TABLE
-- Benennen Sie die Tabelle PRODUCER in PRODUCERS um:

alter table PRODUCER RENAME TO PRODUCERS;

-- Fügen Sie die folgende Spalte zur Tabelle hinzu:
-- CODE VARCHAR(5) NOT NULL UNIQUE
-- DEFAULT Wert sollte 'LOGOS' sein

alter table PRODUCERS
    ADD COLUMN Code varchar(5) DEFAULT 'LOGOS' NOT NULL UNIQUE;

-- endregion


-- region 1.3) INSERT INTO

-- Fügen Sie 3 Datensatze in die Tabelle ein:

-- Label                    Code
-- 'COCA COLA COMPANY'      'COCE'
-- 'Radlberger Inc.'        'RADL'
-- 'Zwettler Brauerei Inc.' 'MONK'

INSERT INTO PRODUCERS
VALUES ('COCA COLA COMPANY', 'COCE');

INSERT INTO PRODUCERS (PRODUCER_LABEL, Code)
VALUES ('Radlberger Inc.', 'RADL');

INSERT INTO PRODUCERS (PRODUCER_LABEL, Code)
VALUES ('Zwettler Brauerei Inc.', 'MONK'),
       ('Zwettler Brauerei2 Inc.', 'MONK2');

INSERT INTO PRODUCERS (PRODUCER_LABEL, Code)
select *
from xyz;

INSERT INTO PRODUCERS (PRODUCER_LABEL)
VALUES ('Test without Code');

select *
from PRODUCERS;



-- endregion
-- ----------------------------------------------------------- --
--  2. Beispiel) DDL Statements
-- ----------------------------------------------------------- --
-- Legen Sie die folgende Tabelle BEVERAGES an.
--    BEVERAGE_ID NUMMER NOT NULL automatische ID;Primary Key
--    LABEL TEXT NOT NULL

CREATE TABLE BEVERAGES
(
    BEVERAGE_ID INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    LABEL       VARCHAR(50)                    NOT NULL
);


-- region 2.1) ALTER TABLE

-- Fügen Sie einen UNIQUE Constraint auf die LABEL Spalte hinzu:

ALTER TABLE BEVERAGES
    ADD CONSTRAINT UQ_LABEL UNIQUE (LABEL);

DESCRIBE BEVERAGES;

ALTER TABLE BEVERAGES
    DROP CONSTRAINT UQ_LABEL;

ALTER TABLE BEVERAGES
    MODIFY COLUMN LABEL VARCHAR(50) NOT NULL UNIQUE;

-- Fügen Sie eine Spalte Producer_LABELS der Tabelle BEVERAGES hinzu.
ALTER TABLE BEVERAGES
    ADD COLUMN PRODUCER_LABEL VARCHAR(100);

-- Fügen Sie einen Fremdschlüssel auf die PRODUCERS Tabelle ein:
ALTER TABLE BEVERAGES
    ADD CONSTRAINT FK_BEVERAGE_PRODUCER_LABEL
        FOREIGN KEY (PRODUCER_LABEL)
            REFERENCES PRODUCERS (PRODUCER_LABEL);

DESCRIBE BEVERAGES;

-- Schalten Sie den referentiellen Constraint ab, damit wir neue Records erstellen können.
-- Fügen Sie die Zeilen ein.

SELECT *
FROM PRODUCERS;

INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (1, 'Coca Cola', 'COCA COLA COMPANY');
INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (2, 'Coca Cola Classic', 'COCA COLA COMPANY');
INSERT INTO BEVERAGES (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
VALUES (3, 'Coca Cola Vanille', 'COCA COLA COMPANY');

select *
from BEVERAGES;


-- Probieren Sie diesen Record einzufügen

SET FOREIGN_KEY_CHECKS = 0;

INSERT INTO BEVERAGES (LABEL, PRODUCER_LABEL)
VALUES ('Product 2', 'TestNotExistingProducer');

select *
from BEVERAGES;

-- Schalten Sie die Referentielle Integrität wieder ein.

SET FOREIGN_KEY_CHECKS = 1;


-- Löschen Sie den falschen Record, damit wir wieder korrekt unterwegs sind.

delete
from BEVERAGES
where BEVERAGE_ID = 5;

select *
from BEVERAGES;

-- endregion


-- ----------------------------------------------------------- --
--  3. Beispiel) BEVERAGES
-- ----------------------------------------------------------- --

-- region 3.1) ALTER TABLE

-- Benennen Sie die BEVERAGES Tabelle in BEVERAGES_BT um.

ALTER TABLE BEVERAGES RENAME BEVERAGES_BT;

-- endregion

-- region 3.2) ALTER TABLE

-- Legen Sie die folgenden Tabellen in SOFT_DRINKS an:
--    BEVERAGE_ID   INT NOT NULL PK
--    SUGAR_CONTENT INT

CREATE TABLE SOFT_DRINKS
(
    BEVERAGE_ID   INT NOT NULL PRIMARY KEY,
    SUGAR_CONTENT INT
);

-- Verändern Sie die Spalte SUGAR_CONTENT wie folgt.
-- Spalte: SUGAR_CONTENT DECIMAL(3) NOT NULL
--    DEFAULT sollte 0 sein

ALTER TABLE SOFT_DRINKS
    MODIFY COLUMN SUGAR_CONTENT DECIMAL(3) NOT NULL DEFAULT 0;

-- Definieren Sie eine referentiellen Constraint auf die BEVERAGES_BT
-- Tabelle


-- endregion

ALTER TABLE SOFT_DRINKS
    ADD CONSTRAINT FK_SOFTDRINKS_BEVERAGE_ID FOREIGN KEY BEVERAGES_BT (BEVERAGE_ID)
        REFERENCES BEVERAGES_BT (BEVERAGE_ID);


-- region 3.3 ALTER TABLE

-- Verändern Sie die folgenden Werte in die Tabelle ein:

-- Einfügen
insert into BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (5, 'Ice Tea Zitron', 'Radlberger Inc.');
insert into BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (6, 'Hirter Bier', 'Radlberger Inc.');

SELECT *
FROM BEVERAGES_BT;

INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (2, 2);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (3, 2);
-- INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
-- values (4, 0);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (5, 130);
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (6, 100);

-- Sie sind drauf gekommen, dass das Hirter Bier nicht in Softdrink Tabelle gehört.
-- Entfernen Sie den Eintrag.

delete
from SOFT_DRINKS
where BEVERAGE_ID = 6;

-- endregion

-- region 3.3) ALTER TABLE

-- SUGAR_CONTENT Werte muessen zwischen 0 und 100 liegen.
-- Wir sollten die falschen Records verändern.

UPDATE SOFT_DRINKS
SET SUGAR_CONTENT = 100
WHERE SUGAR_CONTENT > 100;

select *
from SOFT_DRINKS;

-- Erstellen Sie einen Constraint der dies in Zukunft verhindert.

ALTER TABLE SOFT_DRINKS
    ADD CONSTRAINT CK_SOFTDRINKS_SUGAR_CONTENT CHECK ( SUGAR_CONTENT >= 0 and SUGAR_CONTENT <= 100 );

-- Probieren Sie folgenden Record einzufügen.
INSERT INTO SOFT_DRINKS (BEVERAGE_ID, SUGAR_CONTENT)
values (6, 200);

-- endregion

-- ----------------------------------------------------------- --
--  4. Beispiel) BEER
-- ----------------------------------------------------------- --

-- region 4.1) CREATE TABLE, ALTER TABLE

-- BEVERAGE_ID       integer NOT NULL,
-- ALCOHOLIC_CONTENT INTEGER       NOT NULL FK

-- Wird ein beverage Datensatz geloescht soll der entsprechende
-- BEER Datensatz automatisch geloescht werden.


-- ALCOHOLIC_CONTENT Werte muessen zwischen 0 und 15 liegen. Erstelle einen Constraint


-- endregion

-- region 4.2)
-- Fuegen Sie folgende Werte ein:


INSERT INTO BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (9, 'Zwettler Bier', 'Zwettler Brauerei Inc. ');
INSERT INTO BEER (BEVERAGE_ID, ALCOHOLIC_CONTENT)
VALUES (9, 12);
INSERT INTO BEVERAGES_BT (BEVERAGE_ID, LABEL, PRODUCER_LABEL)
values (8, 'Zwettler Bier Geisterbräu', 'Zwettler Brauerei Inc. ');
INSERT INTO BEER (BEVERAGE_ID, ALCOHOLIC_CONTENT)
VALUES (8, 14);



-- endregion

-- region 4.3) TRUNCATE TABLE, DELETE
-- Loeschen Sie alle Bier Datensaetze.

TRUNCATE TABLE SOFT_DRINKS;

select * from SOFT_DRINKS;

-- endregion

-- ----------------------------------------------------------- --
--  5. Beispiel) CUSTOMERS
-- ----------------------------------------------------------- --

-- region 5.1) CREATE TABLE

-- Legen Sie die folgende Tabelle an
--  CUSTOMER_ID INTEGER NOT NULL; automatische ID
--  FIRST_NAME  VARCHAR(50)   NOT NULL,
--  LAST_NAME   VARCHAR(50)   NOT NULL


-- Spielen Sie die EMPLOYEES Datensatze in die CUSTOMERS Tabelle.
insert into CUSTOMERS (FIRST_NAME, LAST_NAME)
VALUES ('Hans', 'Huber'),
       ('Sissi', 'Mayer');


-- Fügen Sie eine Spalte Abteilung dazu


-- Kunde mit der ID 1 sollte die Abteilung IT haben.
-- Kunde mit der ID 2 sollte die Abteilung SALES haben.

-- Fügen Sie den folgenden Kunden ein.
insert into CUSTOMERS (FIRST_NAME, LAST_NAME,DEPARTMENT)
    values ('Michael','Beier','IT');




-- region 5.2) DML Statements

-- Loeschen Sie alle Customer die in der IT Abteilung arbeiten.



-- Fuegen Sie der Tabelle die folgende Spalte mit Standardwert Current_Timestamp hinzu:
-- JOINED_AT DATETIME not null



-- Loeschen Sie alle Datensaetze



-- endregion

-- ----------------------------------------------------------- --
--  6. Beispiel) ORDERS
-- ----------------------------------------------------------- --

-- region 6.1) DDL Statements
-- Legen Sie die folgenden Datenbankobjekte an:
--    order_id   INTEGER not null; automatisches Erhöhen;
--    order_date date not null


insert into orders (order_id, order_date)
values (1, '2022-11-20');
insert into orders (order_id, order_date)
values (2, '2022-11-21');
insert into orders (order_id, order_date)
values (3, '2022-11-22');
insert into orders (order_id, order_date)
values (4, '2022-11-23');
insert into orders (order_id, order_date)
values (5, '2022-11-24');
insert into orders (order_id, order_date)
values (6, '2022-11-25');
insert into orders (order_id, order_date)
values (7, '2022-11-26');
insert into orders (order_id, order_date)
values (8, '2022-11-27');


-- Legen Sie die Tabelle  customer_has_orders
-- customer_id INTEGER not null (FK)
-- orders_id   INTEGER not null (FK)
-- beverage_id INTEGER not null (FK)
-- price       INTEGER not null


--Beispieldatensätze
insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (2, 1, 1, 1.25);
insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (2, 1, 2, 1.30);
insert into customer_has_orders (customer_id, orders_id, beverage_id, price)
values (2, 1, 3, 1.30);

-- endregion

