db.createCollection("subprojects", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                    "title",
                    "description",
                    "project_id",

                    "appliedResearch", 
                    "theoreticalResearch", 
                    "focusResearch",
                    "facility"
                ],
                additionalProperties : true,
                properties : {
                     title : {
                         bsonType  : "string",
                         minLength : 3,
                         maxLength : 100    
                     },
                     description : {
                         bsonType  : "string",
                         minLength : 0,
                         maxLength : 4000                                                 
                     },
                     project_id : {
                         bsonType : "objectId"  
                     },
                     appliedResearch : {
                         bsonType : "int",
                         minimum  : 0,
                         maximum  : 100
                     },
                     theoreticalResearch : {
                         bsonType : "int",
                         minimum  : 0,
                         maximum  : 100
                     },
                     focusResearch : {
                         bsonType : "int",
                         minimum  : 0,
                         maximum  : 100
                     },
                     facility : {
                         bsonType   : "object",
                         required   : [
                             "_id",
                             "name",
                             "code"
                         ],
                         additionalProperties : false,
                         properties : {
                             _id  : {
                                 bsonType : "objectId"  
                             },
                             name : {
                                 bsonType : "string"    
                             },
                             code : {
                                bsonType : "string"
                             }
                         }
                     }
                }                       
           }
     }
});

db.subprojects.insertMany([
//1.Projekt - 1 Subproject
{
    _id   : ObjectId("874632936283294250329324"), 
    title : "ERP Sap",
    description : "Subproject zur Bestimmung von ERP Sap",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9a"),
    appliedResearch     : NumberInt(10), 
    theoreticalResearch : NumberInt(80), 
    focusResearch       : NumberInt(10),
    facility : {
        _id  : ObjectId("874632936283294250329002"),
        name : "Institut für Wirtschaftsinformatik",
        code : "123.456.231"
    }
},
//1.Projekt - 2 Subproject
{
    _id   : ObjectId("874632936283294250329325"), 
    title : "ERP Dynamics",
    description : "Subproject zur Bestimmung von ERP Dynamics",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9a"),
    appliedResearch     : NumberInt(20), 
    theoreticalResearch : NumberInt(20), 
    focusResearch       : NumberInt(60),
    facility : {
        _id  : ObjectId("874632936283294250329001"),
        name : "Institut für Angewandte Mathematik",
        code : "123.456.789"
    }
},
//2.Projekt - 1 Subproject
{
    _id   : ObjectId("874632936283294250329001"), 
    title : "Prinzipien der Programmierung im generischen Bereich",
    description : "Subprojekt zum Bestimmung der Programmierung im generischen Bereich",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9b"),
    appliedResearch     : NumberInt(20), 
    theoreticalResearch : NumberInt(20), 
    focusResearch       : NumberInt(60),
    facility : {
        _id  : ObjectId("874632936283294250329003"),
        name : "Institut für Softwareentwicklung",
        code : "123.456.789"
    }
},
//2.Projekt - 2 Subproject
{
    _id   : ObjectId("874632936283294250329002"), 
    title : "Vorteilte und Nachteile der generischen Programmierung",
    description : "Subprojekt zum Bestimmung der Programmierung im generischen Bereich",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9b"),
    appliedResearch     : NumberInt(0), 
    theoreticalResearch : NumberInt(0), 
    focusResearch       : NumberInt(100),
    facility : {
        _id  : ObjectId("874632936283294250329003"),
        name : "Institut für Softwareentwicklung",
        code : "123.456.789"
    }
},
//3.Projekt - 1.Subprojekt
{
    _id   : ObjectId("874632936283294250329003"), 
    title : "Transaktionsverfahren - MVCC",
    description : "Erforschen von Transaktionsverfahren",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9c"),
    appliedResearch     : NumberInt(50), 
    theoreticalResearch : NumberInt(50), 
    focusResearch       : NumberInt(0),
    facility : {
        _id  : ObjectId("874632936283294250329003"),
        name : "Institut für Softwareentwicklung",
        code : "123.456.789"
    }
},
//4.Project - 1.Subprojekt
{
    _id   : ObjectId("874632936283294250329004"), 
    title : "Finite Elemente - Mathematische Simulation",
    description : "Erforschen von Transaktionsverfahren",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9d"),
    appliedResearch     : NumberInt(50), 
    theoreticalResearch : NumberInt(0), 
    focusResearch       : NumberInt(50),
    facility : {
        _id  : ObjectId("874632936283294250329007"),
        name : "Institut für Analysis",
        code : "123.321.789"
    }
},
//4.Project - 2.Subprojekt
{
    _id   : ObjectId("874632936283294250329005"), 
    title : "Finite Elemente - Numerische Algorithmen",
    description : "Finite Elemente - Numerische Algorithmen",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9d"),
    appliedResearch     : NumberInt(20), 
    theoreticalResearch : NumberInt(60), 
    focusResearch       : NumberInt(20),
    facility : {
        _id  : ObjectId("874632936283294250329007"),
        name : "Institut für Analysis",
        code : "123.321.789"
    }
},
//4.Project - 3.Subprojekt
{
    _id   : ObjectId("874632936283294250329006"), 
    title : "Finite Elemente - Computersimulation",
    description : "Finite Elemente - Computersimulation",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9d"),
    appliedResearch     : NumberInt(0), 
    theoreticalResearch : NumberInt(0), 
    focusResearch       : NumberInt(100),
    facility : {
        _id  : ObjectId("874632936283294250329001"),
        name : "Institut für Angewandte Mathematik",
        code : "123.456.789"
    }
},
//5.Project - 1.Subprojekt
{
    _id   : ObjectId("874632936283294250329007"), 
    title : "Motorsimulation - Mathematische Methoden",
    description : "Motorsimulation - Mathematische Methoden",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9e"),
    appliedResearch     : NumberInt(35), 
    theoreticalResearch : NumberInt(25), 
    focusResearch       : NumberInt(40),
    facility : {
        _id  : ObjectId("874632936283294250329001"),
        name : "Institut für Angewandte Mathematik",
        code : "123.456.789"
    }
},
//5.Project - 2.Subprojekt
{
    _id   : ObjectId("874632936283294250329008"), 
    title : "Motorsimulation - Numerische Algorithmen",
    description : "Motorsimulation - Numerische Algorithmen",
    project_id  :  ObjectId("5c2dfad77d1c229482d0dd9e"),
    appliedResearch     : NumberInt(0), 
    theoreticalResearch : NumberInt(90), 
    focusResearch       : NumberInt(10),
    facility : {
        _id  : ObjectId("874632936283294250329001"),
        name : "Institut für Angewandte Mathematik",
        code : "123.456.789"
    }
}
]
);
