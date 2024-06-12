drop database race;

create database race;

use race;

drop table if exists races_bt;

create table races_bt
(
    race_id   int,
    race_name varchar(45)  not null,
    race_data date,
    address   varchar(100) not null,

    constraint pk_races_race_id primary key (race_id)
);

drop table if exists rally_races;

create table rally_races
(
    race_id int,
    weather varchar(45) not null,
    surface varchar(45) not null,

    constraint pk_rally_race_id primary key (race_id),
    constraint fk_rally_race_id foreign key (race_id) references races_bt (race_id) on delete cascade
);

drop table if exists lap_races;

create table lap_races
(
    race_id        int,
    number_of_laps int not null,

    constraint pk_lap_race_id primary key (race_id),
    constraint fk_lap_race_id foreign key (race_id) references races_bt (race_id) on delete cascade
);

drop table if exists teams;

create table teams
(
    team_id   int,
    team_name varchar(45) not null,

    constraint pk_teams_team_id primary key (team_id)
);

drop table if exists drivers;

create table drivers
(
    driver_id  int,
    first_name varchar(45) not null,
    last_name  varchar(45) not null,
    birth_date date,
    team_id    int,

    constraint pk_drivers_driver_id primary key (driver_id),
    constraint fk_drivers_team_id foreign key (team_id) references teams (team_id)
);

drop table if exists results_jt;

create table results_jt
(
    driver_id int,
    race_id   int,
    place     int,
    race_time float,

    constraint pk_results_id primary key (driver_id, race_id),
    constraint fk_results_driver_id foreign key (driver_id) references drivers (driver_id),
    constraint fk_results_race_id foreign key (race_id) references races_bt (race_id)
);

drop table if exists prices;

create table prices
(
    race_id int,
    place   int   not null,
    amount  float not null,

    constraint pk_prices_id primary key (race_id, place),
    constraint fk_prices_race_id foreign key (race_id) references races_bt (race_id)
);