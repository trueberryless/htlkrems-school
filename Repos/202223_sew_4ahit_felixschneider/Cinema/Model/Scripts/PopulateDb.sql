INSERT INTO E_COUNTRIES (NAME) VALUES ('Austria');
INSERT INTO E_COUNTRIES (NAME) VALUES ('France');
INSERT INTO E_COUNTRIES (NAME) VALUES ('Germany');

INSERT INTO E_STATES (NAME) VALUES ('Burgenland');
INSERT INTO E_STATES (NAME) VALUES ('Kärnten');
INSERT INTO E_STATES (NAME) VALUES ('Niederösterreich');
INSERT INTO E_STATES (NAME) VALUES ('Oberösterreich');
INSERT INTO E_STATES (NAME) VALUES ('Salzburg');
INSERT INTO E_STATES (NAME) VALUES ('Steiermark');
INSERT INTO E_STATES (NAME) VALUES ('Tirol');
INSERT INTO E_STATES (NAME) VALUES ('Vorarlberg');
INSERT INTO E_STATES (NAME) VALUES ('Wien');

INSERT INTO ADDRESSES (ADDRESS_ID, POSTAL_CODE, LOCATION, STREET, STATE, COUNTRY) VALUES (1, '3500', 'Krems a.d. Donau', 'Gewerbestrasse 21', 'Niederösterreich', 'Austria');
INSERT INTO ADDRESSES (ADDRESS_ID, POSTAL_CODE, LOCATION, STREET, STATE, COUNTRY) VALUES (3, '3500', 'Krems a.d. Donau', 'Dr Karl Dorrek Strasse 30', 'Niederösterreich', 'Austria');

INSERT INTO CINEMAS (CINEMA_ID, LABEL, ADDRESS_ID) VALUES (1, 'Cinemaplexx Krems', 1);
INSERT INTO CINEMAS (CINEMA_ID, LABEL, ADDRESS_ID) VALUES (3, 'Kino im Kesselhaus', 3);

INSERT INTO HALLS (HALL_ID, CAPACITY, NAME, CODE, CINEMA_ID) VALUES (1, 50, 'Saal A', 'krems_A', 1);
INSERT INTO HALLS (HALL_ID, CAPACITY, NAME, CODE, CINEMA_ID) VALUES (2, 120, 'Saal B', 'krems_b', 1);
INSERT INTO HALLS (HALL_ID, CAPACITY, NAME, CODE, CINEMA_ID) VALUES (3, 40, 'Kesselsaal', 'KL-34', 3);

INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (1, 'Russel', 'Crowe');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (2, 'Joaquin ', 'Phoenix');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (3, 'Connie', 'Nielsen');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (4, 'Oliver', 'Reed');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (5, 'Ridley', 'Scott');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (6, 'David', 'Franzoni');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (7, 'Mel', 'Gibson');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (8, 'Sophie', 'Marceau');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (9, 'Patrick', 'McGoohan');
INSERT INTO MOVIE_CREWS (PERSON_ID, FIRST_NAME, LAST_NAME) VALUES (10, 'Angus', 'Macfadyen');

INSERT INTO cinema.MOVIES (MOVIE_ID, NAME, DURATION, DESCRIPTION, SHORT_DESCRIPTION) VALUES (1, 'Braveheart', 180, 'William Wallace is a Scottish rebel who leads an uprising against the cruel English ruler Edward the Longshanks, who wishes to inherit the crown of Scotland for himself. When he was a young boy, William Wallace''s father and brother, along with many others, lost their lives trying to free Scotland. Once he loses another of his loved ones, William Wallace begins his long quest to make Scotland free once and for all, along with the assistance of Robert the Bruce.', 'Scottish warrior William Wallace leads his countrymen in a rebellion to free his homeland from the tyranny of King Edward I of England.');
INSERT INTO cinema.MOVIES (MOVIE_ID, NAME, DURATION, DESCRIPTION, SHORT_DESCRIPTION) VALUES (2, 'Gladiator', 155, 'Maximus is a powerful Roman general, loved by the people and the aging Emperor, Marcus Aurelius. Before his death, the Emperor chooses Maximus to be his heir over his own son, Commodus, and a power struggle leaves Maximus and his family condemned to death. The powerful general is unable to save his family, and his loss of will allows him to get captured and put into the Gladiator games until he dies. The only desire that fuels him now is the chance to rise to the top so that he will be able to look into the eyes of the man who will feel his revenge. ', 'A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.');
INSERT INTO cinema.MOVIES (MOVIE_ID, NAME, DURATION, DESCRIPTION, SHORT_DESCRIPTION) VALUES (3, 'The Admiral: Roaring Currents', 128, 'The film mainly follows the famous 1597 Battle of Myeongryang during the Japanese invasion of Korea (1592-1598), where the iconic Joseon admiral Yi Sun-sin managed to destroy a total of 31 of 133 Japanese warships with only 13 ships remaining in his command. The battle, which took place in the Myeongryang Strait off the southwest coast of the Korean Peninsula, is considered one of the greatest victories of Yi.', 'Admiral Yi Sun-sin faces a tough challenge when he is forced to defend his nation with just 13 battleships against 300 Japanese enemy ships in the Battle of Myeongryang.');


INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 7, 'ACTOR', '1993-10-09 19:19:13', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 7, 'DIRECTOR', '1993-10-19 19:17:32', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 7, 'PRODUCER', '1993-10-09 19:18:30', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 8, 'ACTOR', '1993-10-09 19:19:55', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 9, 'ACTOR', '1998-10-09 19:22:29', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (1, 10, 'ACTOR', '1998-10-09 19:23:09', '1995-10-09 19:17:50');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 1, 'ACTOR', '1998-10-09 18:58:18', '1999-10-25 18:59:08');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 2, 'ACTOR', '1998-10-09 18:59:53', '1999-10-25 18:59:08');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 3, 'ACTOR', '1998-10-09 19:04:44', '1999-10-25 18:59:08');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 4, 'ACTOR', '1998-10-09 19:12:46', '1999-10-25 18:59:08');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 5, 'DIRECTOR', '1998-10-09 19:14:23', '1999-10-25 18:59:08');
INSERT INTO OCCUPATIONS_JT (MOVIE_ID, PERSON_ID, ROLE, OCCUPATION_BEGIN, OCCUPATION_END) VALUES (2, 6, 'SCREENWRITER', '1998-10-09 19:15:34', '1999-10-25 18:59:08');

INSERT INTO SCREENINGS_JT (MOVIE_ID, HALL_ID, STARTS_AT, ENDS_AT) VALUES (1, 1, '2022-10-09 16:00:29', '2022-10-09 19:00:55');
INSERT INTO SCREENINGS_JT (MOVIE_ID, HALL_ID, STARTS_AT, ENDS_AT) VALUES (1, 1, '2022-10-09 19:25:51', '2022-10-09 22:40:02');
INSERT INTO SCREENINGS_JT (MOVIE_ID, HALL_ID, STARTS_AT, ENDS_AT) VALUES (1, 3, '2022-10-09 14:00:57', '2022-10-09 15:15:21');
INSERT INTO SCREENINGS_JT (MOVIE_ID, HALL_ID, STARTS_AT, ENDS_AT) VALUES (1, 3, '2022-10-09 16:30:23', '2022-10-09 19:45:46');
INSERT INTO SCREENINGS_JT (MOVIE_ID, HALL_ID, STARTS_AT, ENDS_AT) VALUES (2, 2, '2022-10-09 15:00:39', '2022-10-09 18:00:05');

commit;