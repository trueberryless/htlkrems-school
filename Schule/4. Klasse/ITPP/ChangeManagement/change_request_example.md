# Change request

-   ID: 2023_0203_TrainIT_0412
-   customer ID: J.Hauptmann
-   priority: high
-   deadline: 03.05.2023
-   required
-   change type: new feature

## Change abstract

In the project **2023_0203_TrainIT** there needs to be a hugh change of the database MySQL schema. Currently, the schema consist of the tables: Activities, Exercises, Workouts, Users and Workout_has_Exercises_JT. In order for the additional functionalities, which are:

-   There should be predefined exercises that the user can choose from. Therefore, they do not need to think about a name, description, machine, standard weight, repetition and sets,

there needs to be the additional tables which handle these "library" datas.

## Current state

Tables:

-   Exercises
-   Activities
-   Worktouts
-   Workout_has_Exercises_JT

## Vision Future State

Tables:

-   Exercises
-   Activities
-   Worktouts
-   Workout_has_Exercises_JT
-   ExericseLibrary
-   WorktoutsLibrary
-   Workout_Library_has_Exercises_Library_JT

## Price

little

## Time

medium
