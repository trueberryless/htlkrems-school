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

db.personalities.aggregate([
    {
        $unwind: "$keywords"
    },
    {
        $group: {
            _id: "$keywords",
            personCount: {
                $sum: 1
            },
            personalities: {
                $push: {
                    name: "$name",
                    fullName: "$fullName"
                }
            }
        }
    },
    {
        $out: "keywords"
    }
])

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

db.personalities.find({});

db.personalities.aggregate([
    {
        $unwind: "$keywords"
    },
    {
        $group: {
            _id: "$keywords",
            personCount: {
                $sum: 1
            }
        }
    },
    {
        $group: {
            _id: null,
            maxPersonCount: {
                $max: "$personCount"
            },
            keywords: {
                $push: "$$CURRENT"
            }
        }
    },
    {
        $addFields: {
            keywords: {
                $filter: {
                    input: "$keywords",
                    as: "keyword",
                    cond: {
                        $eq: [ "$maxPersonCount", "$$keyword.personCount" ]
                    }
                }
            }
        }
    },
    {
        $unwind: "$keywords"
    },
    {
        $replaceRoot: {
            newRoot: "$keywords"
        }
    }
]);

// -- ----------------------------------------------------------------------------------------- --
// --  3.Beispiel) aggregate Framework
// -- ----------------------------------------------------------------------------------------- --
// Berechnen Sie bei welcher Schlacht prozentuell gesehen die meisten Truppen gefallen sind.

db.events.find({});

db.events.aggregate([
    {
        $addFields: {
            compositionAmount: {
                $reduce: {
                    input: "$belligerents",
                    initialValue: 0,
                    in: {
                        $add: [
                            "$$value",
                            {
                                $reduce: {
                                    input: "$$this.composition",
                                    initialValue: 0,
                                    in: {
                                        $add: [
                                            "$$value",
                                            "$$this.amount"
                                        ]
                                    }
                                }
                            }
                        ]
                    }
                }
            },
            lossAmount: {
                $reduce: {
                    input: "$belligerents.losses",
                    initialValue: 0,
                    in: {
                        $add: [
                            "$$value",
                            {
                                $reduce: {
                                    input: "$$this.amount",
                                    initialValue: 0,
                                    in: {
                                        $add: [
                                            "$$value",
                                            "$$this"
                                        ]
                                    }
                                }
                            }
                        ]
                    }
                }
            }
        }
    },
    {
        $addFields: {
            relativeLosses: {
                $concat: [
                    {
                        $substr: [
                            {
                                $round: [
                                    {
                                        $multiply: [
                                            {
                                                $divide: [
                                                    "$lossAmount",
                                                    "$compositionAmount"
                                                ]
                                            },
                                            100
                                        ]
                                    },
                                    2
                                ]
                            },
                            0,
                            -1
                        ]
                    },
                    "%"
                ]
            }
        }
    },
    {
        $project: {
            _id: 0,
            name: 1,
            relativeLosses: 1
        }
    },
    {
        $sort: {
            relativeLosses: -1
        }
    }
]);

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

