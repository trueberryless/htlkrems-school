update prices join race.lap_races lr on prices.race_id = lr.race_id
set amount = amount * 1.05;

SET @disqualified_place := 2;
update results_jt
set place = case when place < @disqualified_place then place when place = @disqualified_place then null else place - 1 end
where race_id = 1;

update rally_races join race.races_bt rb on rally_races.race_id = rb.race_id
set weather = 'Snow'
where month(race_data) not between 03 and 09;

create table lap_race_has_lap_results_jt (
    race_id int not null,
    driver_id int not null,
    round_id int not null,
    lap_time float,

    constraint pk_lap_race_has_lap_results_jt primary key (race_id, driver_id, round_id),
    constraint fk_lap_race_has_lap_results_jt_race_id foreign key (race_id) references lap_races(race_id),
    constraint fk_lap_race_has_lap_results_jt_driver_id foreign key (driver_id) references drivers(driver_id)
);

alter table results_jt
drop column race_time;

alter table results_jt
add column start_position int;

alter table results_jt
add column result_id int;

alter table results_jt
drop constraint `PRIMARY`;