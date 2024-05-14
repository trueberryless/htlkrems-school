use insy;

// -- ----------------------------------------------------------------- --
// --  1.) Beispiel
// -- ----------------------------------------------------------------- --
// Für die Teilnehmer (Belligerents) an Schlachten soll ein Report ver-
// faßt werden.

// I) Geben Sie für alle Belligerents die folgenden Werte aus:

//    var belligerent = {
//         commander : "...",
//         nation : "...",
//         battles : [  // Kurzbeschreibung einer Schlacht
//             { name : "...", troopCount : ..., losses : ... },
//               // troopCount und losses beziehen sich auf die
//               // eigenen Truppen
//             { ... }
//         ],
//         victoryCount : ...  // Anzahl der Siege des Generals
//    }


// II) Speichern Sie das Ergebnis in einer Collection: commander

// Hinweis: Wenn nach mehreren Werten gruppiert werden soll, wird für
//          die $group Stufe die folgende Syntax verwendet:

// $group : {_id : { field1 : value1, field2: value2 } }


db.events.find({});

db.events.aggregate([
    {
        $match: {
            eventType: "BATTLE"
        }
    },
    {
        $unwind: "$belligerents"
    },
    {
        $group: {
            _id: {
                commander: "$belligerents.commander",
                nation: "$belligerents.nation"
            },
            battles: {
                $push: {
                    name: "$name",
                    troopCount: {
                        $sum: "$belligerents.composition.amount"
                    },
                    losses: {
                        $sum: "$belligerents.losses.amount"
                    }
                }
            },
            victoryCount: {
                $sum: {
                    $cond: {
                        if: {
                            $eq: [ "$victor", "$belligerents.commander"]
                        },
                        then: 1,
                        else: 0
                    }
                }
            }
        }
    },
    {
        $project: {
            _id: 0,
            commander: "$_id.commander",
            nation: "$_id.nation",
            victoryCount: 1,
            battles: 1
        }
    },
    {
        $sort: {
            "victoryCount": -1
        }
    },
    {
        $out: "commander"
    }
]);



// -- ----------------------------------------------------------------- --
// --  2.) Beispiel
// -- ----------------------------------------------------------------- --
// Für Commander (collection commander) soll ein Report verfaßt werden.
// Einem Commander werden dabei für bestimmte Aspekte Punkte zugeordnet.

// I) Berechnen Sie für jeden Commander einen influenceCount. Der Wert
//    für influenceCount setzt sich dabei aus folgenden Posten zusammen:

//    * victories -> $victoryCount * 50
//    * battleParticipation -> $(battle count) * 2
//    * troopCount -> ($(overall Troopcount) / $(battle count))/1000

// II) Geben Sie für jeden Commander die folgenden Felder aus. Speichern
//     Sie Ihr Ergebnis in einer collection commanderReport.

//     var commander = {
//          name : "",
//          nation : "",
//          influenceCount : ...
//     }

db.events.find();

db.events.aggregate([
    {
        $unwind: "$belligerents"
    },
    {
        $group: {
            _id: {
                name: "$belligerents.commander",
                nation: "$belligerents.nation"
            },
            victories: {
                $sum: {
                    $cond: {
                        if: {
                            $eq: [ "$belligerents.commander", "$victor" ]
                        },
                        then: 1,
                        else: 0
                    }
                }
            },
            battleParticipation: {
                $sum: 1
            },
            troopCount: {
                $sum: {
                    $reduce: {
                        input: "$belligerents.composition",
                        initialValue: 0,
                        in: {
                            $add: [
                                "$$value", "$$this.amount"
                            ]
                        }
                    }
                }
            }
        }
    },
    {
        $project: {
            _id: 0,
            commander: "$_id.name",
            nation: "$_id.nation",
            influenceCount: {
                $add: [
                    {
                        $multiply: [
                            "$victories",
                            50
                        ]
                    },
                    {
                        $multiply: [
                            "$battleParticipation",
                            2
                        ]
                    },
                    {
                        $divide: [
                            {
                                $divide: [
                                    "$troopCount",
                                    "$battleParticipation"
                                ]
                            },
                            1000
                        ]
                    }
                ]
            }
        }
    },
    {
        $sort: {
            influenceCount: -1
        }
    },
    {
        $out: "commander2"
    }
]);

db.commander.find();













db.commander.aggregate([
    {
        $addFields: {
            victories: {
                $multiply: [ "$victoryCount", 50 ]
            },
            battleParticipation: {
                $multiply: [ { $size: "$battles" }, 2 ]
            },
            troopCount: {
                $divide: [ {
                    $divide: [ { $sum: "$battles.troopCount" } , { $size: "$battles" } ]
                }, 1000 ]
            }
        }
    },
    {
        $addFields: {
            influenceCount: {
                $add: [ "$victories", "$battleParticipation", "$troopCount" ]
            }
        }
    },
    {
        $project: {
            _id: 0,
            name: "$commander",
            nation: "$nation",
            influenceCount: 1
        }
    },
    {
        $sort: {
            "influenceCount": -1
        }
    },
    {
        $out: "commander2"
    }
]);

