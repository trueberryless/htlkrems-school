db.createCollection("facilities", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                   "_id",
                   "name",
                   "code",
                   "projects"
                ],
                properties : {
                     _id   : {
                         bsonType : "objectId"    
                     },
                     name : {
                         bsonType  : "string",
                         minLength : 3,
                         maxLength : 100   
                     }, 
                     code : {
                         bsonType  : "string",                      
                     },                    
                     projects : {
                        bsonType : "array",
                        items : {
                           bsonType : "object",
                           required : ["project_id", "title"],
                           properties : {
                              project_id : {
                                 bsonType : "objectId"    
                              },   
                              title : {
                                 bsonType : "string"
                              }
                           }    
                        }
                     }
                }                       
           }
     }
});


db.facilities.insertMany([{
     _id  : ObjectId("874632936283294250329002"),
     name : "Institut für Wirtschaftsinformatik",
     code : "123.456.231",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9a"),
        title : "Produktionsplanungssysteme" 
     }]
}, {
     _id  : ObjectId("874632936283294250329001"),
     name : "Institut für Angewandte Mathematik",
     code : "123.456.789",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9a"),
        title : "Produktionsplanungssysteme" 
     },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
         title : "Finite Elemente c" 
     },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9e"),
         title : "Motorensimulation a" 
     },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9e"),
         title : "Motorensimulation b" 
     }]
}, {
     _id  : ObjectId("874632936283294250329003"),
     name : "Institut für Softwareentwicklung",
     code : "123.456.789",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9b"),
        title : "Generische Programmierung a" 
     },{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9b"),
        title : "Generische Programmierung b" 
     },{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9c"),
        title : "Transaktionsverfahren in NoSQL Datenbanken" 
     }]
}, {
      _id  : ObjectId("874632936283294250329007"),
      name : "Institut für Analysis",
      code : "123.321.789",
      projects  : [{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
         title : "Finite Elemente a" 
      },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
         title : "Finite Elemente b" 
      }]
}
]);


