-- Clear existing records
DELETE FROM prices where true;
DELETE FROM results_jt where true;
DELETE FROM drivers where true;
DELETE FROM teams where true;
DELETE FROM lap_races where true;
DELETE FROM rally_races where true;
DELETE FROM races_bt where true;

-- Insert statements for 'races' table
INSERT INTO races_bt (race_id, race_name, race_data, address) VALUES
(1, 'Grand Prix 1', '2023-01-01', 'Race Address 1'),
(2, 'Grand Prix 2', '2023-02-01', 'Race Address 2'),
(3, 'Grand Prix 3', '2023-03-01', 'Race Address 3'),
(4, 'Grand Prix 4', '2023-04-01', 'Race Address 4'),
(5, 'Grand Prix 5', '2023-05-01', 'Race Address 5'),
(6, 'Grand Prix 6', '2023-06-01', 'Race Address 6'),
(7, 'Grand Prix 7', '2023-07-01', 'Race Address 7'),
(8, 'Grand Prix 8', '2023-08-01', 'Race Address 8'),
(9, 'Grand Prix 9', '2023-09-01', 'Race Address 9'),
(10, 'Grand Prix 10', '2023-10-01', 'Race Address 10');

-- Insert statements for 'rally_races' table
INSERT INTO rally_races (race_id, weather, surface) VALUES
(1, 'Sunny', 'Asphalt'),
(2, 'Rainy', 'Gravel'),
(3, 'Cloudy', 'Dirt'),
(4, 'Sunny', 'Snow'),
(5, 'Rainy', 'Gravel'),
(6, 'Clear', 'Asphalt'),
(7, 'Windy', 'Sand'),
(8, 'Foggy', 'Mud'),
(9, 'Thunderstorm', 'Rocky'),
(10, 'Partly Cloudy', 'Ice');

-- Insert statements for 'lap_races' table
INSERT INTO lap_races (race_id, number_of_laps) VALUES
(1, 50),
(2, 40),
(3, 35),
(4, 45),
(5, 60),
(6, 25),
(7, 40),
(8, 55),
(9, 30),
(10, 50);

-- Insert statements for 'teams' table
INSERT INTO teams (team_id, team_name) VALUES
(1, 'Team A'),
(2, 'Team B'),
(3, 'Team C'),
(4, 'Team D'),
(5, 'Team E'),
(6, 'Team F'),
(7, 'Team G'),
(8, 'Team H'),
(9, 'Team I'),
(10, 'Team J');

-- Insert statements for 'drivers' table
INSERT INTO drivers (driver_id, first_name, last_name, birth_date, team_id) VALUES
(1, 'John', 'Doe', '1990-01-01', 1),
(2, 'Jane', 'Smith', '1985-05-15', 2),
(3, 'Bob', 'Johnson', '1992-09-20', 1),
(4, 'Alice', 'Williams', '1988-03-12', 2),
(5, 'Charlie', 'Davis', '1995-07-08', 1),
(6, 'Eva', 'Brown', '1993-12-05', 2),
(7, 'Michael', 'Miller', '1987-06-30', 1),
(8, 'Olivia', 'Taylor', '1991-11-18', 2),
(9, 'David', 'Anderson', '1986-04-25', 1),
(10, 'Sophia', 'Moore', '1994-02-15', 2);

-- Insert statements for 'results' table
INSERT INTO results_jt (driver_id, race_id, place, race_time) VALUES
(1, 1, 1, 120.5),
(2, 1, 2, 125.3),
(3, 1, 3, 130.2),
(4, 2, 1, 118.8),
(5, 2, 2, 126.0),
(6, 2, 3, 132.5),
(7, 1, 1, 119.7),
(8, 1, 2, 127.1),
(9, 1, 3, 133.9),
(10, 2, 1, 121.4);

-- Insert statements for 'prices' table
INSERT INTO prices (race_id, place, amount) VALUES
(1, 1, 10000.00),
(1, 2, 7500.00),
(1, 3, 5000.00),
(2, 1, 11000.00),
(2, 2, 8000.00),
(2, 3, 5500.00),
(1, 4, 3000.00),
(2, 4, 3200.00),
(1, 5, 2000.00),
(2, 5, 1800.00);




-- Update statements for 'races' table
UPDATE races_bt SET race_name = 'Updated Grand Prix 1', race_data = '2023-01-15' WHERE race_id = 1;
UPDATE races_bt SET address = 'Updated Race Address 2' WHERE race_id = 2;
-- Add more update statements as needed

-- Update statements for 'teams' table
UPDATE teams SET team_name = 'Updated Team A' WHERE team_id = 1;
UPDATE teams SET team_name = 'Updated Team B' WHERE team_id = 2;
-- Add more update statements as needed



-- Delete statements for 'results' table
DELETE FROM results_jt WHERE driver_id = 7 AND race_id = 1;
DELETE FROM results_jt WHERE driver_id = 8 AND race_id = 1;
-- Add more delete statements as needed

-- Delete statements for 'drivers' table
DELETE FROM drivers WHERE driver_id = 7;
DELETE FROM drivers WHERE driver_id = 8;
-- Add more delete statements as needed