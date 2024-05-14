// -- ---------------------------------------------------------------------- --
// --  1.Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// Finden Sie den Spieler der die meisten Tore geschossen hat.

//  var player = {
//     name : "M.Salah"
//  }

db.matches.find({});

db.matches.aggregate([
    {
        $unwind: "$teams"
    },
    {
        $unwind: "$teams.events"
    },
    {
        $match: {
            "teams.events.eventType": "GOAL"
        }
    },
    {
        $group: {
            _id: "$teams.events.player",
            goalCount: {
                $sum: 1
            }
        }
    },
    {
        $group: {
            _id: null,
            players: {
                $push: {
                    name: "$_id",
                    goalCount: "$goalCount"
                }
            },
            maxGoalCount: {
                $max: "$goalCount"
            }
        }
    },
    {
        $project: {
            proPlayers: {
                $filter: {
                    input: "$players",
                    as: "player",
                    cond: {
                        $eq: [
                            "$$player.goalCount",
                            "$maxGoalCount"
                        ]
                    }
                }
            }
        }
    },
    {
        $unwind: "$proPlayers"
    },
    {
        $replaceRoot: {
            newRoot: "$proPlayers"
        }
    },
    {
        $out: "proPlayers"
    }
]);



// -- -------------------------------------------------------------- --
// --  2.Beispiel) aggregate - Pipelinestufen, Expressions
// -- -------------------------------------------------------------- --
// Bei welchem Match hat es die meisten Gelben Karten gegeben? Geben
// Sie folgende Daten aus:

/*
   var match = {
       competition : "Premier League",
       matchStart : "2020-09-12 15:30:00",
       yellowCardCount : 4,
       teams : [
          "FC Fulham", "Arsenal London"
       ]
   }
*/

db.matches.find({});

db.matches.aggregate([
    {
        $addFields: {
            yellowCardCount: {
                $sum: {
                    $map: {
                        input: "$teams",
                        as: "team",
                        in: {
                            $size: {
                                $filter: {
                                    input: "$$team.events",
                                    as: "event",
                                    cond: {
                                        $eq: [ "$$event.eventType", "YELLOW_CARD" ]
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
        $group: {
            _id: null,
            matches: {
                $push: {
                    competition : "$competition",
                    matchStart : "$matchStart",
                    yellowCardCount : "$yellowCardCount",
                    teams : "$teams.name"
                }
            },
            maxYellowCardCount: {
                $max: "$yellowCardCount"
            }
        }
    },
    {
        $addFields: {
            matches: {
                $filter: {
                    input: "$matches",
                    as: "match",
                    cond: {
                        $eq: [ "$$match.yellowCardCount", "$maxYellowCardCount" ]
                    }
                }
            }
        }
    },
    {
        $unwind: "$matches"
    },
    {
        $replaceRoot: {
            newRoot: "$matches"
        }
    }
]);




// -- -------------------------------------------------------------- --
// --  3.Beispiel) aggregate - Pipelinestufen, Expressions
// -- -------------------------------------------------------------- --
// Erstellen Sie für jedes Match den folgenden Report:

/*
var match = {
   competition : "Premier League",
   matchStart  : "2020-09-12 15:30:00",
   homeTeam : "FC Fulham",
   awayTeam : "Arsenal London",
   winner : "Arsenal London",
   venue : "Craven Cottage",
   teams : [
      {
         name : "FC Fulham",
         ballPossesion : 45,
         goals : 0,
         fouls : 12,
         yellowCard : 2,
         redCard : 0
      },
      {
         name : "Arsenal London",
         ballPossesion : 45,
         goals : 3,
         fouls : 12,
         yellowCard : 2,
         redCard : 0
      }
   ]
}

*/

db.matches.find();

db.matches.aggregate([
    {
        $project: {
            competition : 1,
            matchStart  : 1,
            homeTeam : {
                $let: {
                    vars: {
                        homeTeamObject: {
                            $first: {
                                $filter: {
                                    input: "$teams",
                                    as: "team",
                                    cond: {
                                        $eq: [ "$$team.teamType", "HOME_TEAM" ]
                                    }
                                }
                            }
                        }
                    },
                    in: "$$homeTeamObject.name"
                }
            },
            awayTeam : {
                $let: {
                    vars: {
                        homeTeamObject: {
                            $first: {
                                $filter: {
                                    input: "$teams",
                                    as: "team",
                                    cond: {
                                        $eq: [ "$$team.teamType", "AWAY_TEAM" ]
                                    }
                                }
                            }
                        }
                    },
                    in: "$$homeTeamObject.name"
                }
            },
            winner : {
                $let: {
                    vars: {
                        winnerTeam: {
                            $first: {
                                $map: {
                                    input: "$teams",
                                    as: "team",
                                    in: {
                                        $let: {
                                            vars: {
                                                goalCount: {
                                                    $size: {
                                                        $filter: {
                                                            input: "$$team.events",
                                                            as: "event",
                                                            cond: {
                                                                $eq: [ "$$event.eventType", "GOAL" ]
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            in: {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    in: "$$winnerTeam.name"
                }
            },
            venue : "Craven Cottage",
            teams : [
                {
                    name : "FC Fulham",
                    ballPossesion : 45,
                    goals : 0,
                    fouls : 12,
                    yellowCard : 2,
                    redCard : 0
                },
                {
                    name : "Arsenal London",
                    ballPossesion : 45,
                    goals : 3,
                    fouls : 12,
                    yellowCard : 2,
                    redCard : 0
                }
            ]
        }
    }
])