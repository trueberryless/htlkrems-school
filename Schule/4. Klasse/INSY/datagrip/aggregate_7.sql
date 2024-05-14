// -- ----------------------------------------------------------------------------- --
// --  1.Beispiel) aggregate: Pipelinestufen, Expressions
// -- ----------------------------------------------------------------------------- --
// Generieren Sie für die bestehenden Matches eine Rangliste für die spielenden
// Mannschaften.

// var team = {
//    "name" : "FC Liverpool"
//    "points" : 14.0,
//    "victories" : 4.0,
//    "draws" : 2.0,
//    "defeats" : 1.0,
// }


// ------------------------------------------------------------- --
// Hinweis: Expression Syntax - $map, $reduce, $filter, $let
// ------------------------------------------------------------- --

/*
   $map: {
      input: <expression>,
      as: <string>,
      in: <expression>
   }


   $reduce: {
       input: <array>,
       initialValue: <expression>,
       in: <expression>
    }

    $filter : {
         input : <array>,
         as : <string>,
        cond : <expression>
     }


    $let : {
       vars : {
           <var1> : <expression>,
           <var2> : <expression>,
           ...
        },
        in : <expression>
    }
*/

db.matches.find({});

// GOALs matchen -> zusammenzählen pro Team
// $map jedes Team, goalCount ausrechnen
// herausfinden des Gewinners

db.matches.aggregate([
    {
        $addFields: {
            teamGoals: {
                $map: {
                    input: "$teams",
                    as: "team",
                    in: {
                        name: "$$team.name",
                        goalCount: {
                            $reduce: {
                                input: "$$team.events",
                                initialValue: 0,
                                in: {
                                    $cond: {
                                        if: {
                                            $eq: [ "$$this.eventType", "GOAL" ]
                                        },
                                        then: {
                                            $add: [ "$$value", 1 ]
                                        },
                                        else: "$$value"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    },
    {
        $addFields: {
            matchResult: {
                $let: {
                    vars: {
                        t1: { $arrayElemAt: [ "$teamGoals", 0 ] },
                        t2: { $arrayElemAt: [ "$teamGoals", 1 ] }
                    },
                    in: {
                        $cmp: [ "$$t1.goalCount", "$$t2.goalCount" ]
                    }
                }
            }
        }
    },
    {
        $addFields: {
            teams: {
                $let: {
                    vars: {
                        t1: { $arrayElemAt: [ "$teams", 0 ] },
                        t2: { $arrayElemAt: [ "$teams", 1 ] }
                    },
                    in: {
                        $switch: {
                            branches: [
                                {
                                    case: {
                                        $eq: [ "$matchResult", -1 ]
                                    },
                                    then: {
                                        $concatArrays: [
                                            [
                                                {
                                                    name: "$$t1.name",
                                                    points : 0,
                                                    victories : 0,
                                                    draws : 0,
                                                    defeats : 1,
                                                }
                                            ],
                                            [
                                                {
                                                    name: "$$t2.name",
                                                    points : 3,
                                                    victories : 1,
                                                    draws : 0,
                                                    defeats : 0,
                                                }
                                            ]
                                        ]
                                    }
                                },
                                {
                                    case: {
                                        $eq: [ "$matchResult", 0 ]
                                    },
                                    then: {
                                        $concatArrays: [
                                            [
                                                {
                                                    name: "$$t1.name",
                                                    points : 1,
                                                    victories : 0,
                                                    draws : 1,
                                                    defeats : 0,
                                                }
                                            ],
                                            [
                                                {
                                                    name: "$$t2.name",
                                                    points : 1,
                                                    victories : 0,
                                                    draws : 1,
                                                    defeats : 0,
                                                }
                                            ]
                                        ]
                                    }
                                },
                                {
                                    case: {
                                        $eq: [ "$matchResult", 1 ]
                                    },
                                    then: {
                                        $concatArrays: [
                                            [
                                                {
                                                    name: "$$t1.name",
                                                    points : 3,
                                                    victories : 1,
                                                    draws : 0,
                                                    defeats : 0,
                                                }
                                            ],
                                            [
                                                {
                                                    name: "$$t2.name",
                                                    points : 0,
                                                    victories : 0,
                                                    draws : 0,
                                                    defeats : 1,
                                                }
                                            ]
                                        ]
                                    }
                                }
                            ],
                            default: []
                        }
                    }
                }
            }
        }
    },
    {
        $unwind: "$teams"
    },
    {
        $group: {
            _id: "$teams.name",
            points : {
                $sum: "$teams.points"
            },
            victories : {
                $sum: "$teams.victories"
            },
            draws : {
                $sum: "$teams.draws"
            },
            defeats : {
                $sum: "$teams.defeats"
            },
        }
    },
    {
        $sort: {
            points: -1
        }
    },
    {
        $out: "teamPoints"
    }
]);