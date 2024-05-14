db.createCollection("debitors", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                     "_id", 
                     "name", 
                     "description",
                     "fundings"
                ],
                properties : {
                     _id   : {
                         bsonType : "objectId"    
                     },
                     name  : {
                         bsonType  : "string",
                         minLength : 2,
                         maxLength : 100             
                     },                     
                     description : {
                         bsonType  : "string",
                         minLength : 0,
                         maxLength : 4000
                     },
                     fundings : {
                        bsonType : "array",
                        items : {
                           bsonType : "object",
                           required : [
                                "project_id",
                                "projectName",
                                "amount", 
                                "transferredAt"
                           ],
                           properties : {
                              project_id : {
                                 bsonType : "objectId"    
                              },
                              projectName : {
                                 bsonType  : "string",
                                 minLength : 3,
                                 maxLength : 100                                   
                              },
                              amount : {
                                 bsonType : "long",
                                 minimum  : 0
                              },
                              transferredAt : {
                                 bsonType : "date"    
                              }
                           }    
                        }
                     }
                }                       
           }
     }
});


db.debitors.insertMany([
{
     _id  : ObjectId("874632936283294250329326"), 
     name : "SAP Microsystems inc.", 
     description : "SAP Microsystems best System ever",
     fundings : [ {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9a"),
          projectName   : "Produktionsplanungssysteme",
          amount        : NumberLong(100000), 
          transferredAt : new Date ('Jun 30, 2012')
         
     }  
     ]
},
{
     _id  : ObjectId("874632936283294250329111"), 
     name : "Oracle Microsystems inc.", 
     description : "Oracle Microsystems inc.",
     fundings : [ {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9b"),
          projectName   : "Generische Programmierung",
          amount        : NumberLong(300000), 
          transferredAt : new Date ('Mar 30, 2012')
         
     }  
     ]
},{
     _id  : ObjectId("874632936283294250329114"), 
     name : "Sun Microsystems inc.", 
     description : "Sun Microsystems inc.",
     fundings : [ {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9d"),
          projectName   : "Finite Elemente",
          amount        : NumberLong(500000), 
          transferredAt : new Date ('Sep 13, 2017')  
     }, {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9e"),
          projectName   : "Motorensimulation",
          amount        : NumberLong(300000), 
          transferredAt : new Date ('Nov 01, 2018')  
     }  
     ]
},{
     _id  : ObjectId("874632936283294250329115"), 
     name : "Simens Microsystems inc.", 
     description : "Simens Microsystems inc.",
     fundings : [ {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9d"),
          projectName   : "Finite Elemente",
          amount        : NumberLong(400000), 
          transferredAt : new Date ('Sep 13, 2017')  
     }, {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9e"),
          projectName   : "Motorensimulation",
          amount        : NumberLong(3000), 
          transferredAt : new Date ('Nov 01, 2018')  
     }   
     ]
},{
     _id  : ObjectId("874632936283294250329116"), 
     name : "TU Wien", 
     description : "TU Wien",
     fundings : [ {
          project_id    : ObjectId("5c2dfad77d1c229482d0dd9d"),
          projectName   : "Finite Elemente",
          amount        : NumberLong(150000), 
          transferredAt : new Date ('Sep 13, 2017')  
     }  
     ]
}
]);
