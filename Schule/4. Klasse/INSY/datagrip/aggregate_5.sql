// -- ----------------------------------------------------------------------------------------- --
// --  1.Beispiel) aggregate Framework
// -- ----------------------------------------------------------------------------------------- --
// Zur Abgleichung der Inflationsrate wird die Förderung für Projekte
// folgendermassen angepaßt werden. Für Managementprojekte (MANAGEMENT_PROJECT)
// soll keine Abgleichung erfolgen. Managementprojekte erhalten eine
// zusätzliche Förderung von der TU Wien in der Höhe von 15000.

// FundingAmount       Increase
// 0       -  5.000        5%
// 5.001   -  20.000      10%
// 20.001  -  100.000     12%
// 100.001 +              15%

//    var project = {
//         _id : "...", // Project ID
//         description : "...",
//         projectType : "...",
//         fundings_original : [
//              {
//                  "_id": {"$oid": "874632936283294250329114"},
//                  "debitorName": "Sun Microsystems inc.",
//                  "amount": 300000
//              },..
//         ],
//         fundings : [
//              {
//                  "_id": {"$oid": "874632936283294250329114"},
//                  "debitorName": "Sun Microsystems inc.",
//                  "amount": 345000
//              },..
//         ],
//    }


// Hinweis:

// $switch : {
//     branches : [
//        {case : <exp>, then: <exp>},
//        {case : <exp>, then: <exp>},
//         ...
//     ],
//     default : <exp>
//  }

// $cond : {
//      if : <boolean-expression>,
//      then : <true-case>,
//      else : <false-case>
//  }

//  $map: {
//     input: <expression>,
//     as: <string>,
//     in: <expression>
//  }

// $concatArrays : [ <array1> , <array2> ]

db.projects.find();

//  1. Projekt Type Check
//      2. if not Management Project --> Prozentrechnung
//      3. else Eintrag hinzufügen (15.000 €)

db.projects.aggregate([
    {
        $project: {
            _id: 1,
            description: 1,
            projectType: 1,
            fundings_original: "$fundings",
            fundings: {
                $cond: {
                    if: {
                        $ne: [ "$projectType", "MANAGEMENT_PROJECT" ]
                    },
                    then: {
                        $map: {
                            input: "$fundings",
                            as: "funding",
                            in: {
                                _id: "$$funding._id",
                                debitorName: "$$funding.debitorName",
                                amount: {
                                    $switch: {
                                        branches: [
                                            {
                                                case: {
                                                    $and: [
                                                        { $gt: [ "$$funding.amount", 0 ] },
                                                        { $lte: [ "$$funding.amount", 5000 ] }
                                                    ]
                                                },
                                                then: {
                                                    $multiply: [
                                                        "$$funding.amount", 1.05
                                                    ]
                                                }
                                            },
                                            {
                                                case: {
                                                    $and: [
                                                        { $gt: [ "$$funding.amount", 5000 ] },
                                                        { $lte: [ "$$funding.amount", 20000 ] }
                                                    ]
                                                },
                                                then: {
                                                    $multiply: [
                                                        "$$funding.amount", 1.10
                                                    ]
                                                }
                                            },
                                            {
                                                case: {
                                                    $and: [
                                                        { $gt: [ "$$funding.amount", 20000 ] },
                                                        { $lte: [ "$$funding.amount", 100000 ] }
                                                    ]
                                                },
                                                then: {
                                                    $multiply: [
                                                        "$$funding.amount", 1.12
                                                    ]
                                                }
                                            },
                                            {
                                                case: {
                                                    $gt: [ "$$funding.amount", 100000 ]
                                                },
                                                then: {
                                                    $multiply: [
                                                        "$$funding.amount", 1.15
                                                    ]
                                                }
                                            }
                                        ],
                                        default: "$$funding.amount"
                                    }
                                }
                            }
                        }
                    },
                    else: {
                        $concatArrays: [
                            "$fundings",
                            [
                                {
                                    _id: ObjectId(),
                                    debitorName: "TU Wien",
                                    amount: 15000
                                }
                            ]
                        ]
                    }
                }
            }
        }
    },
    {
        $out: "projectReport"
    }
]);