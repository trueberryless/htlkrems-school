// -- --------------------------------------------------------------------------------- --
// --  1.Beispiel) Aggregationsframework: $match, $project, $sort, $out (1.Punkt)
// -- --------------------------------------------------------------------------------- --
// Sammeln Sie die folgenden Eventdaten in der "eventsReport" Collection. Berücksichtigen
// Sie nur Battles. Für das Event muß zumindestens bei einem Beteiligten 3 Generäle teilgenommen haben.


// Ausgabe: eventName, battleVictor, description, sizebelligerents

// @eventName     -> name
// @battelVictor  -> victor
// @description   -> description

// Sortieren Sie das Ergebnis nach dem Eventnamen aufsteigend.
// Übernehmen Sie nur die ersten 2 Dokumente.


// Hinweis: Prüfung ob das Generals Array Elemente hat:

//  reviews : {
//       $exists : true, $not : { $size : 0 }
// }

db.events.aggregate([
    {
        $match: {
            eventType: "BATTLE",
            "belligerents.generals": { $size: 3 }
        }
    },
    {
        $project: {
            eventName: "$name",
            battleVictor: "$victor",
            description: 1,
            sizebelligerents: { $size: "$belligerents"}
        }
    },
    {
        $sort: {
            eventName: 1
        }
    },
    {
        $limit: 2
    },
    {
        $out: "eventReport"
    }
]);

db.events.find({
    "belligerents.generals": { $size: 3}
}).sort({name: 1});


// -- --------------------------------------------------------------------------------- --
// --  2.Beispiel) Aggregationsframework - $group, $out                     (1.Punkt)
// -- --------------------------------------------------------------------------------- --
// Geben Sie für jeden eventType folgende Werte aus. Speichern Sie Ihr Ergebnis in einer
// Collection eventReport2

// {
//    "_id" : "BATTLE",
//    "documentCount" : ..., @Anzahl der Dokumente für den eventType
//    "eventNames" : [
//        {
//            "name" : "Battle of ...",
//            "victor" : "..."
//        }, ...
//     ]
//  }

db.events.aggregate([
    {
        $group: {
            _id: "$eventType",
            documentCount: {
                $sum: 1
            },
            eventNames: {
                $push: {
                    name: "$name",
                    victor: "$victor"
                }
            }
        }
    },
    {
        $out: "eventReport2"
    }
]);

// -- --------------------------------------------------------------------------------- --
// --  3.Beispiel) Aggregationsframework - $match, $unwind, $addFields, $group, $lookup
// --                                    - $project, $out
// --  (3.Punkte)
// -- --------------------------------------------------------------------------------- --

// Sammeln Sie für events die folgenden Daten in der eventReport3 collection. Berück-
// sichtigen Sie nur BATTLE eventTypes.
//
// eventType, description, territorialChange, belligerents
//
// @name        -> name
// @eventType   -> eventType
// @description -> description
// @territorialChange -> territorialChange
// @belligerents : [{
//     commander : "...",
//     nation : "...",
//     troopCount : -> $sum composition.amount
//     troopTypes : ["...", "..."]
//     lossCount  : -> $sum losses.amount
// }]


// Hinweis: Zur Berechung der Werte der gegnerischen Seiten (belligerents)
//          sollte eine "$unwind" auf dem Array durchgeführt werden.

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
        $addFields: {
            troopCount: {
                $sum: "$belligerents.composition.amount"
            },
            lossCount: {
                $sum: "$belligerents.losses.amount"
            }
        }
    },
    {
        $group: {
            _id: "$_id",
            belligerents: {
                $push: {
                    commander : "$belligerents.commander",
                    nation : "$belligerents.nation",
                    troopCount: "$troopCount",
                    troopTypes: "$belligerents.composition.type",
                    lossCount: "$lossCount"
                }
            }
        }
    },
    {
        $lookup: {
            from: "events",
            localField: "_id",
            foreignField: "_id",
            as: "events"
        }
    },
    {
        $unwind: "$events"
    },
    {
        $project: {
            _id: 0,
            name: "$events.name",
            eventType: "$events.eventType",
            description: "$events.description",
            territorialChange: "$events.territorialChange",
            belligerents: 1
        }
    },
    {
        $sort: {
            name: 1
        }
    },
    {
        $out: "eventReport3"
    }
]);

db.events.find();




