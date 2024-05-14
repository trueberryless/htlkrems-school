//-------------------------------------------------------------------------------------------
//      schema
//-------------------------------------------------------------------------------------------

db.createCollection("debitors", {
     validationLevel  : "strict",
     validationAction : "error",
     validator : {
           $jsonSchema : {
                bsonType : "object",
                required : [
                    "name",
                    "description",
		    "fundings"
                ],
                additionalProperties : true,
                properties : {
                     name : {
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
                     fundings : {
                        bsonType : "array",
                        items : {
                           bsonType : "object",
                           required : ["_id", "title", "amount", "date"],
                           additionalProperties : false,
                           properties : {
                              _id : {
                                 bsonType : "objectId"    
                              },
			      title : {
			   	 bsonType : "string",
				 minLength : 3,
				 maxLength : 50
			      },
                              amount : {
                                 bsonType : "long",
				 minimum  : 0
                              },
                              date : {
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
	//1. Debitor
	{
		_id: ObjectId("974632936283294250329326"),
		name: "Debitor 1",
		description: "some debitor",
		fundings: [
			{
				_id: ObjectId("5c2dfad77d1c229482d0dd9b"),
				title: "Project 2",
				amount: NumberLong(120000),
				date: new Date('Oct 26, 2012')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9c"),
				title: "Project 3",
				amount: NumberLong(67000),
				date: new Date('Sep 9, 2017')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9e"),
				title: "Project 5",
				amount: NumberLong(300000),
				date: new Date('Aug 17, 2018')
			}
		]
	},
	//2. Debitor
	{
		_id: ObjectId("974632936283294250329327"),
		name: "Debitor 2",
		description: "some other debitor",
		fundings: [
			{
				_id: ObjectId("5c2dfad77d1c229482d0dd9d"),
				title: "Project 4",
				amount: NumberLong(12000),
				date: new Date('Sep 4, 2010')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9e"),
				title: "Project 5",
				amount: NumberLong(10000),
				date: new Date('Jan 09, 2019')
			}
		]
	},
	//3. Debitor
	{
		_id: ObjectId("974632936283294250329328"),
		name: "Debitor 3",
		description: "this debitor",
		fundings: [
			{
				_id: ObjectId("5c2dfad77d1c229482d0dd9a"),
				title: "Project 1",
				amount: NumberLong(600000),
				date: new Date('Oct 5, 2015')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9c"),
				title: "Project 3",
				amount: NumberLong(300000),
				date: new Date('Feb 20, 2005')
			}
		]
	},
	//4. Debitor
	{
		_id: ObjectId("974632936283294250329329"),
		name: "Debitor 4",
		description: "that other debitor",
		fundings: [
			{
				_id: ObjectId("5c2dfad77d1c229482d0dd9b"),
				title: "Project 2",
				amount: NumberLong(150000),
				date: new Date('Feb 6, 2019')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9e"),
				title: "Project 5",
				amount: NumberLong(90000),
				date: new Date('Jan 13, 2013')
			}
		]
	},
	//5. Debitor
	{
		_id: ObjectId("974632936283294250329330"),
		name: "Debitor 5",
		description: "one debitor",
		fundings: [
			{
				_id: ObjectId("5c2dfad77d1c229482d0dd9a"),
				title: "Project 1",
				amount: NumberLong(30000),
				date: new Date('Jul 04, 2022')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9c"),
				title: "Project 3",
				amount: NumberLong(350000),
				date: new Date('Sep 29, 2021')
			},{
				_id: ObjectId("5c2dfad77d1c229482d0dd9d"),
				title: "Project 4",
				amount: NumberLong(1000000),
				date: new Date('Oct 2, 2019')
			}
		]
	}
]);
