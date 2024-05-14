-- Delete all data

delete
from users
where true;

delete
from presets
where true;

delete
from exercises
where true;

delete
from sub_exercises
where true;

delete
from preset_has_exercises_jt
where true;


-- Insert data

insert into users (USER_ID,NAME, EMAIL, PASSWORD_HASHED)
VALUES (1,'Yanik', 'yanik.latzka@gmx.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (2,'Felix', 'felix@schneider.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (3,'Jürgen', 'j.hauptmann@htlkrems.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (4,'Paul', 'p.panhofer@htlkrems.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW');

insert into presets (PRESET_ID, NAME)
VALUES (1, 'Push'),
       (2, 'Pull'),
       (3, 'Leg'),
       (4, 'Push');


insert into exercises (EXERCISE_ID,NAME, MACHINE, DESCRIPTION, USER_ID)
VALUES (1,'Bench press', 'Bench', 'arms at 45° and aim for the lower chest', 1),
       (2,'Dips', 'Dip-Machine', 'slightly lean forth', 1),
       (3,'Bench press', 'Bench', 'arms at 45° and aim for the lower chest', 2),
       (4,'Dips', 'Dip-Machine', 'slightly lean forth', 2),
       (5,'Leg-Press', 'Leg-Press', 'slowly and correct', 3),
       (6,'Leg extension', 'Leg-extension-Machine', 'go as high as possible', 3),
       (7,'Bulgarian split squad', 'Smith-Machine', 'go max down', 3),
       (8,'Cola', 'Beverage-Machine', 'cheapest in BSH', 4);

insert into sub_exercises (SUB_EXERCISE_ID,EXERCISE_ID, DATE, WEIGHT, REPETITION, `SET`)
VALUES (1,1, '2022-11-21', 60, 10, 3),
       (2,1, '2022-11-14', 60, 8, 3),
       (3,1, '2022-11-07', 57.5, 10, 3),
       (4,1, '2022-10-31', 0, 13, 3),
       (5,2, '2022-11-21', 5, 10, 3),
       (6,2, '2022-11-14', 5, 8, 3),
       (7,2, '2022-11-07', 5, 9, 3),
       (8,2, '2022-10-31', 5, 11, 3),
       (9,3, '2022-11-21', 30, 10, 3),
       (10,3, '2022-11-14', 35, 10, 3),
       (11,3, '2022-11-07', 35, 10, 3),
       (12,3, '2022-10-31', 35, 10, 3);
insert into preset_has_exercises_jt (PRESET_ID, EXERCISE_ID)
VALUES (1, 1),
       (1, 2),
       (4, 3),
       (4, 4),
       (3, 5),
       (3, 6);