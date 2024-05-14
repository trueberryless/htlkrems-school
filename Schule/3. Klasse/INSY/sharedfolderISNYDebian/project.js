//-------------------------------------------------------------------------------------------
//      schema
//-------------------------------------------------------------------------------------------

db.createCollection("projects", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                    "title",
                    "projectType",
                    "projectState",
                    "description",
                    "projectBegin",
                    "isFWFSponsered",
                    "isFFGSponsered",
                    "isEUSponsered",
                    "isSmallProject",                   
                    "subprojects",
                    "fundings"
                ],
                additionalProperties : true,
                properties : {
                     title : {
                         bsonType  : "string",
                         minLength : 3,
                         maxLength : 100,
                         description : "the title of the project"
                     },
                     projectType : {
                        enum : [
                            "REQUEST_FUNDING_PROJECT",
                            "RESEARCH_FUNDING_PROJECT",
                            "MANAGEMENT_PROJECT"
                        ],
                        description : "enum to describe projecttypes"
                     },
                     projectState : {
                         enum : [
                             "CREATED",
                             "IN_APPROVEMENT",
                             "APPROVED"
                         ],
                         description : "enum to describe the project state"
                     },
                     description : {
                         bsonType  : "string",
                         minLength : 0,
                         maxLength : 4000,
                         description : "a short description of the project"          
                     },
                     projectBegin : {
                        bsonType : "date"
                     },
                     isFWFSponsered : {
                        bsonType : "bool",
                        description : "indicates if the project is sponsered by the fwf"   
                     },
                     isFFGSponsered : {
                        bsonType : "bool",
                        description : "indicates if the project is sponsered by the ffg"   
                     },
                     isEUSponsered : {
                        bsonType : "bool",
                        description : "indicates if the project is sponsered by the eu"   
                     },
                     isSmallProject : {
                        bsonType : "bool",
                        description : "indicates that the funding of the project don't exceeds 5000 Euro"
                     },
                     subprojects : {
                         bsonType : "array",
                         items : {
                            bsonType : "object",
                            required : ["_id","title"],
                            additionalProperties : false,
                            properties : {
                               _id : {
                                  bsonType : "objectId"    
                               },
                               title : {
                                  bsonType  : "string",
                                  minLength : 3,
                                  maxLength : 100,
                                  description : "the description of the subproject"
                               }
                            }    
                         }    
                     },
                     fundings : {
                        bsonType : "array",
                        items : {
                           bsonType : "object",
                           required : ["_id", "debitorName", "amount"],
                           additionalProperties : false,
                           properties : {
                              _id : {
                                 bsonType : "objectId"    
                              },
                              debitorName : {
                                 bsonType  : "string",
                                 minLength : 5,
                                 maxLength : 100 
                              },
                              amount : {
                                 bsonType : "long",
                                 minimum : 0
                              }
                           }    
                        }
                     }
                }                       
           }
     }
});


//-------------------------------------------------------------------------------------------
//       insert statements
//-------------------------------------------------------------------------------------------

db.projects.insertMany([
//1. Project
{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9a"),
  title :        "Produktionsplanungssysteme",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329324"),
      title: "ERP Sap"   
  },{
      _id  : ObjectId("874632936283294250329325"),
      title: "ERP Dynamics"   
  }
  ],
  fundings    : [{
      _id  : ObjectId("874632936283294250329326"),
      debitorName : "SAP Microsystems inc.",
      amount : NumberLong(100000)
  }]
},
//2.Project
{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9b"),  
  title :        "Generische Programmierung",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Erforschung der Prinzipien der generischen Programmierung",
  projectBegin : new Date ('Mar 07, 2010'),
  isFWFSponsered : false,
  isFFGSponsered : false,
  isEUSponsered  : true,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329001"),
      title: "Prinzipien der Programmierung im generischen Bereich"   
  },{
      _id  : ObjectId("874632936283294250329002"),
      title: "Vorteilte und Nachteile der generischen Programmierung"   
  }
  ],
  fundings    : [{
      _id  : ObjectId("874632936283294250329111"),
      debitorName : "Oracle Microsystems inc.",
      amount : NumberLong(300000)
  }]
},
//3.Project
{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9c"),
  title :        "Transaktionsverfahren in NoSQL Datenbanken",
  projectType  : "RESEARCH_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Erforschung des Transaktionsverfahrens von NoSQL Datenbanken",
  projectBegin : new Date ('Sep 10, 2017'),
  isFWFSponsered : true,
  isFFGSponsered : true,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329003"),
      title: "Transaktionsverfahren - MVCC"   
  }
  ],
  fundings    : [{
      _id  : ObjectId("874632936283294250329111"),
      debitorName : "Oracle Microsystems inc.",
      amount : NumberLong(300000)
  }]
},
//4.Project
{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
  title :        "Finite Elemente",
  projectType  : "RESEARCH_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Erforschung der Methoden der Finiten Elemente in der Computersimulation",
  projectBegin : new Date ('Sep 10, 2017'),
  isFWFSponsered : false,
  isFFGSponsered : false,
  isEUSponsered  : true,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329004"),
      title: "Finite Elemente - Mathematische Simulation"   
  },{
      _id  : ObjectId("874632936283294250329005"),
      title: "Finite Elemente - Numerische Algorithmen"   
  },{
      _id  : ObjectId("874632936283294250329006"),
      title: "Finite Elemente - Computersimulation"   
  }
  ],
  fundings    : [{
      _id  : ObjectId("874632936283294250329114"),
      debitorName : "Sun Microsystems inc.",
      amount : NumberLong(500000)
  },{
      _id  : ObjectId("874632936283294250329115"),
      debitorName : "Simens Microsystems inc.",
      amount : NumberLong(400000)
  },{
      _id  : ObjectId("874632936283294250329116"),
      debitorName : "TU Wien",
      amount : NumberLong(150000)
  }]
},
//5.Project
{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9e"),
  title :        "Motorensimulation",
  projectType  : "MANAGEMENT_PROJECT",
  projectState : "CREATED",
  description  : "Projekt zur Erforschung der Methoden der Motorensimulation",
  projectBegin : new Date ('Oct 24, 2018'),
  isFWFSponsered : true,
  isFFGSponsered : true,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329007"),
      title: "Motorsimulation - Mathematische Methoden"   
  },{
      _id  : ObjectId("874632936283294250329008"),
      title: "Motorsimulation - Numerische Algorithmen"   
  }
  ],
  fundings    : [{
      _id  : ObjectId("874632936283294250329114"),
      debitorName : "Sun Microsystems inc.",
      amount : NumberLong(30000)
  },{
      _id  : ObjectId("874632936283294250329115"),
      debitorName : "Simens Microsystems inc.",
      amount : NumberLong(3000)
  }
  ]
}
]
);



