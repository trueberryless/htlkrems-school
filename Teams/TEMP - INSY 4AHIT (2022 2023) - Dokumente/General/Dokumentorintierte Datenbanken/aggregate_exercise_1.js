 // -- --------------------------------------------------------------------------------- --
// --  1.Beispiel) Aggregationsframework: $match, $project, $sort, $out (1.Punkt)
// -- --------------------------------------------------------------------------------- --
// Sammeln Sie die folgenden Eventdaten in der "eventsReport" Collection. Berücksichtigen
// Sie nur Battles. Für das Event muß zumindestens ein Review abgegeben worden sein.


// Ausgabe: eventName, battleVictor, description, maxReview

// @eventName     -> name
// @battelVictor  -> victor
// @description   -> description

// Sortieren Sie das Ergebnis nach dem Eventnamen aufsteigend.
// Übernehmen Sie nur die ersten 2 Dokumente.


// Hinweis: Prüfung ob das review Array Elemente hat:

//  reviews : {
//       $exists : true, $not : { $size : 0 }   
// }

db.events.find({});



// -- --------------------------------------------------------------------------------- --
// --  2.Beispiel) Aggregationsframework - $group, $out                     (1.Punkt)
// -- --------------------------------------------------------------------------------- --
// Geben Sie für jeden eventType folgende Werte aus. Speichern Sie Ihr Ergebnis in einer
// Collection eventReport

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

db.events.find({});



// -- --------------------------------------------------------------------------------- --
// --  3.Beispiel) Aggregationsframework - $match, $unwind, $addFields, $group, $lookup
// --                                    - $project, $out              
// --  (3.Punkte)
// -- --------------------------------------------------------------------------------- --

// Sammeln Sie für events die folgenden Daten in der eventReport collection. Berück-
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
