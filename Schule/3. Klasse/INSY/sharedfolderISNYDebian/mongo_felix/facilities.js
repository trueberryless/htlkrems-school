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
     name : "Institut für Angewandte Mathematik",
     code : "123.456.231",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9c"),
        title : "Project 3" 
     }]
}, {
     _id  : ObjectId("874632936283294250329001"),
     name : "Institut für Wirtschaftsinformatik",
     code : "123.456.789",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9a"),
        title : "Project 1" 
     },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
         title : "Project 4" 
     },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9e"),
         title : "Project 5" 
     }]
}, {
     _id  : ObjectId("874632936283294250329003"),
     name : "Institut für Softwareentwicklung",
     code : "123.456.789",
     projects  : [{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9a"),
        title : "Project 1" 
     },{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9b"),
        title : "Project 2" 
     },{
        project_id   : ObjectId("5c2dfad77d1c229482d0dd9c"),
        title : "Project 3" 
     }]
}, {
      _id  : ObjectId("874632936283294250329004"),
      name : "Institut für Analysis",
      code : "123.321.789",
      projects  : [{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9b"),
         title : "Project 2" 
      },{
         project_id   : ObjectId("5c2dfad77d1c229482d0dd9d"),
         title : "Project 4" 
      },{
	 project_id   : ObjectId("5c2dfad77d1c229482d0dd9e");
	 title : "Project 5";
      }]
}
]);


