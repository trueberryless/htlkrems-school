-- ---------------------------------------------------------------------- -
-- 1.1) Beispiel: Stored Procedures (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Schreiben Sie eine Funktion die für ein gegebenen Betrag
-- die Einkommensstuer berechnet.

-- Steurstufen:

--        LOWER        UPPER       PERCENTAGE
--        0            13.000      0%
--        13.001       21.000      20%
--        21.001       35.000      30%
--        35.001       67.000      40%
--        67.001       100.000     48%
--        100.001      1.000.000   50%
--        1.000.001    -           55%

-- endregion
-- 1) Legen Sie die folgende Tabelle TAX_LEVELS

-- TAX_LEVEL INT AUTO INCREMENT PK
-- LOWER  INT  NOT NULL
-- UPPER  INT
-- PERCENTAGE DEC(2,2) NOT NULL
-- TAX_AMOUNT DEC(14,2) NOT NULL

-- endregion

CREATE DATABASE INSY;
USE INSY;

CREATE TABLE TAX_LEVELS (
    TAX_LEVEL INT AUTO_INCREMENT,
    LOWER INT NOT NULL,
    UPPER INT NOT NULL,
    PERCENTAGE DEC(3,2) NOT NULL,
    TAX_AMOUNT DEC(14,2) GENERATED ALWAYS AS ((UPPER - LOWER + 1) * PERCENTAGE),
    PRIMARY KEY (TAX_LEVEL),
    CONSTRAINT CK_TAX_LEVEL_LOWER CHECK ( UPPER > LOWER )
);
drop table TAX_LEVELS;

INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (0,13000, 0);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (13001,21000, 0.2);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (21001,35000, 0.3);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (35001,67000, 0.4);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (67001,100000, 0.48);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (100001,1000000, 0.5);
INSERT INTO TAX_LEVELS (LOWER, UPPER, PERCENTAGE) VALUES (1000001,2147483647, 0.55);

select *
from TAX_LEVELS;

-- 2) Schreiben Sie eine Stored Function zum Berechnen der Einkommenssteuer.

drop function if exists get_tax_amount;

create function get_tax_amount(money int)
    returns int
    deterministic
begin
    declare taxes_lower dec(14,2);
    declare taxes_current dec(14,2);
    declare taxes dec(14,2);

    select sum(TAX_AMOUNT)
    into taxes_lower
    from TAX_LEVELS
    where UPPER < money;

    select PERCENTAGE * (money - LOWER)
    into taxes_current
    from TAX_LEVELS
    where LOWER <= money and UPPER >= money;

    set taxes = ifnull(taxes_lower + taxes_current, 0);

    return taxes;
end;

select get_tax_amount(67001);

show variables like 'max_error_count';
