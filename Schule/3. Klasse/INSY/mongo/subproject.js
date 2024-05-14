//-------------------------------------------------------------------------------------------
//      schema
//-------------------------------------------------------------------------------------------

db.createCollection("subprojects", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                    "title",
                    "description",
		    "appliedResearch",
		    "theoreticalResearch",
		    "focusResearch",
                    "project",
		    "facilities"
                ],
                additionalProperties : true,
                properties : {
                     title : {
                         bsonType  : "string",
                         minLength : 3,
                         maxLength : 100,
                         description : "the title of the subproject"
                     },
                     description : {
                         bsonType  : "string",
                         minLength : 0,
                         maxLength : 4000,
                         description : "a short description of the subproject"          
                     },
                     appliedResearch : {
                        bsonType   : "int",
			minimum    : 0,
			maximum    : 100
		     },
                     theoreticalResearch : {
                        bsonType   : "int",
			minimum    : 0,
			maximum    : 100
		     },
                     focusResearch : {
                        bsonType   : "int",
			minimum    : 0,
			maximum    : 100
		     },
		     project : {
			bsonType   : "object",
			required   : [ "_id", "title" ],
			additionalProperties: false,

			properties: {
			    _id: {
				bsonType: "objectId"
			    },
			    title: {
				bsonType: "string",
				minLength: 3,
				maxLength: 100
			    }
			}
		     },
		     facilities	: {
			bsonType   : "object",
			required   : [ "_id", "name" ],
			additionalProperties: false,

			properties: {
			    _id: {
				bsonType: "objectId"
			    },
			    name: {
				bsonType: "string",
				minLength: 3,
			 	maxLength: 100
			    }
			}
		     }
                }                       
           }
     }
});


// InsertMany
db.subprojects.insertMany([
	{
		_id:		ObjectId("874632936283294250329324"),	
		title:		"Subproject 1",
		description:	"Once upon a time some dude thought he should make this subproject...",
		appliedResearch:	92,
		theoreticalResearch:	82,
		focusResearch:		58,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9c"),
			title:	"Project 3"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329002"),
			name: 	"Institut für Angewandte Mathematik"
		}
	},
	{
		_id:		ObjectId("874632936283294250329325"),	
		title:		"Subproject 2",
		description:	"Once upon a time some guy thought he should make this subproject...",
		appliedResearch:	19,
		theoreticalResearch:	93,
		focusResearch:		28,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9e"),
			title:	"Project 5"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329001"),
			name: 	"Institut für Wirtschaftsinformatik"
		}
	},
	{
		_id:		ObjectId("874632936283294250329326"),	
		title:		"Subproject 3",
		description:	"Once upon a time some person thought he should make this subproject...",
		appliedResearch:	14,
		theoreticalResearch:	8,
		focusResearch:		38,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9a"),
			title:	"Project 1"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329001"),
			name: 	"Institut für Wirtschaftsinformatik"
		}
	},
	{
		_id:		ObjectId("874632936283294250329327"),	
		title:		"Subproject 4",
		description:	"Once upon a time some schurke thought he should make this subproject...",
		appliedResearch:	28,
		theoreticalResearch:	40,
		focusResearch:		29,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9a"),
			title:	"Project 1"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329003"),
			name: 	"Institut für Softwareentwicklung"
		}
	},
	{
		_id:		ObjectId("874632936283294250329328"),	
		title:		"Subproject 5",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	93,
		theoreticalResearch:	82,
		focusResearch:		83,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9b"),
			title:	"Project 2"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329003"),
			name: 	"Institut für Softwareentwicklung"
		}
	},
	{
		_id:		ObjectId("874632936283294250329329"),	
		title:		"Subproject 6",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	45,
		theoreticalResearch:	56,
		focusResearch:		87,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9e"),
			title:	"Project 5"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329004"),
			name: 	"Institut für Analysis"
		}
	},
	{
		_id:		ObjectId("874632936283294250329330"),	
		title:		"Subproject 7",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	15,
		theoreticalResearch:	94,
		focusResearch:		54,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9d"),
			title:	"Project 4"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329004"),
			name: 	"Institut für Analysis"
		}
	},
	{
		_id:		ObjectId("874632936283294250329331"),	
		title:		"Subproject 8",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	37,
		theoreticalResearch:	72,
		focusResearch:		82,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9c"),
			title:	"Project 3"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329003"),
			name: 	"Institut für Softwareentwicklung"
		}
	},
	{
		_id:		ObjectId("874632936283294250329332"),	
		title:		"Subproject 9",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	15,
		theoreticalResearch:	22,
		focusResearch:		11,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9b"),
			title:	"Project 2"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329004"),
			name: 	"Institut für Analysis"
		}
	},
	{
		_id:		ObjectId("874632936283294250329333"),	
		title:		"Subproject 10",
		description:	"Once upon a time some monte thought he should make this subproject...",
		appliedResearch:	19,
		theoreticalResearch:	75,
		focusResearch:		38,
		project: {
			_id:	ObjectId("5c2dfad77d1c229482d0dd9d"),
			title:	"Project 4"
		},
		facilities: {
			_id:	ObjectId("874632936283294250329001"),
			name: 	"Institut für Wirtschaftsinformatik"
		}
	}
]);
