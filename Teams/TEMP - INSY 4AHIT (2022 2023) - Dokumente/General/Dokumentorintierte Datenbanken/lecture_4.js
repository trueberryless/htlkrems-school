// -- ----------------------------------------------------------------------------------------- --
// --  1.Beispiel) aggregate Framework
// -- ----------------------------------------------------------------------------------------- --
// Transformieren Sie Dokumente der personalities Collection in folgende Struktur. Speichern Sie
// das Ergebnis in einer Collection "keywords"

// var keyword = {
//    keyword : "King",
//    personCount : 1,
//    personalities : [
//        {
//            name : "Alexander the Great",
//            fullName : "Alexander III of Macedon"
//        }
//    ]
// }

db.personalities.find({});

// Syntax: $map : {
//             input : <array>,
//             as : <item>,
//             in : { $op : [....] }
//          }



// -- ----------------------------------------------------------------------------------------- --
// --  2.Beispiel) aggregate Framework
// -- ----------------------------------------------------------------------------------------- --
// Finden Sie das Schlüsselwort mit den höchsten "personCount".

// Hinweis: Verwenden Sie eine Subpipeline

db.keywords.find({});



// -- ----------------------------------------------------------------------------------------- --
// --  3.Beispiel) aggregate Framework
// -- ----------------------------------------------------------------------------------------- --
// Berechnen Sie bei welcher Schlacht prozentuell gesehen die meisten Truppen gefallen sind.

db.events.find({});


// -- ----------------------------------------------------------------------------------------- --
// --  4.Beispiel) aggregate Framework - array Operatoren
// -- ----------------------------------------------------------------------------------------- --
// Auswertungen haben ergeben dass für die Schlacht von Gaugamela falsche Angaben für die
// Truppenzusammensetzung angegeben wurden. In der Armee von Alexander dem Großen
// war die Zahl der schweren Infantrie (HEAVY_INFANTRY) 35000 und die Zahl der
// leichten Infantrie (LIGHT_INFANTRY) 9000. Führen Sie die entsprechendne Änderungen
// durch.

// Hinweis:

// Auswertungen haben ergeben dass für die Schlacht von Gaugamela falsche Angaben für die
// Truppenzusammensetzung angegeben wurden. In der Armee von Alexander dem Großen
// war die Zahl der schweren Infantrie (HEAVY_INFANTRY) 35000 und die Zahl der
// leichten Infantrie (LIGHT_INFANTRY) 9000. Führen Sie die entsprechendne Änderungen
// durch.

// Hinweis:

// $switch : {
//     branches : [
//        {case : <exp>, then: <exp>},
//        {case : <exp>, then: <exp>},
//         ...
//     ],
//     default : <exp>
//  }

//  $map: {
//     input: <expression>,
//     as: <string>,
//     in: <expression>
//  }

db.events.find({});

