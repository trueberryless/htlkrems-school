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
                         maxLength : 50,
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
  title :        "Project 1",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [
  {
      _id  : ObjectId("874632936283294250329326"),
      title: "Subproject 3"   
  },{
      _id  : ObjectId("874632936283294250329327"),
      title: "Subproject 4"   
  }
  ],
  fundings    : [
	{
      		_id  :  ObjectId("974632936283294250329328"),	
      		debitorName : "Debitor 3",
      		amount : NumberLong(600000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329330"),	
      		debitorName : "Debitor 5",
      		amount : NumberLong(30000)
  	}
  ]
}
//2. Project
,{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9b"),
  title :        "Project 2",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [
  {
      _id  : ObjectId("874632936283294250329328"),
      title: "Subproject 5"   
  },{
      _id  : ObjectId("874632936283294250329332"),
      title: "Subproject 9"   
  }
  ],
  fundings    : [
	{
      		_id  :  ObjectId("974632936283294250329329"),	
      		debitorName : "Debitor 4",
      		amount : NumberLong(150000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329326"),	
      		debitorName : "Debitor 1",
      		amount : NumberLong(120000)
  	}
  ]
}
//3. Project
,{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9c"),
  title :        "Project 3",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [
  {
      _id  : ObjectId("874632936283294250329324"),
      title: "Subproject 1"   
  },{
      _id  : ObjectId("874632936283294250329331"),
      title: "Subproject 8"   
  }
  ],
  fundings    : [
	{
      		_id  :  ObjectId("974632936283294250329326"),	
      		debitorName : "Debitor 1",
      		amount : NumberLong(67000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329328"),	
      		debitorName : "Debitor 3",
      		amount : NumberLong(300000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329330"),	
      		debitorName : "Debitor 5",
      		amount : NumberLong(350000)
  	}
  ]
}
//4. Project
,{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
  title :        "Project 4",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329330"),
      title: "Subproject 7"   
  },{
      _id  : ObjectId("874632936283294250329333"),
      title: "Subproject 10"   
  }
  ],
  fundings    : [
	{
      		_id  :  ObjectId("974632936283294250329327"),	
      		debitorName : "Debitor 2",
      		amount : NumberLong(12000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329330"),	
      		debitorName : "Debitor 5",
      		amount : NumberLong(1000000)
  	}
  ]
}
//5. Project
,{
  _id   : ObjectId("5c2dfad77d1c229482d0dd9e"),
  title :        "Project 5",
  projectType  : "REQUEST_FUNDING_PROJECT",
  projectState : "APPROVED",
  description  : "Projekt zur Planung von Produktionsplanungssystemen",
  projectBegin : new Date ('Jun 23, 2012'),
  isFWFSponsered : true,
  isFFGSponsered : false,
  isEUSponsered  : false,
  isSmallProject : false,                   
  subprojects : [{
      _id  : ObjectId("874632936283294250329325"),
      title: "Subproject 2"   
  },{
      _id  : ObjectId("874632936283294250329329"),
      title: "Subproject 6"   
  }
  ],
  fundings    : [
	{
      		_id  :  ObjectId("974632936283294250329326"),	
      		debitorName : "Debitor 1",
      		amount : NumberLong(300000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329327"),	
      		debitorName : "Debitor 2",
      		amount : NumberLong(10000)
  	},
	{
      		_id  :  ObjectId("974632936283294250329329"),	
      		debitorName : "Debitor 4",
      		amount : NumberLong(90000)
  	}
  ]
},
]);
