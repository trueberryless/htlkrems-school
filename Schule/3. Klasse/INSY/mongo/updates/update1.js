db.projects.updateMany(
	{},
	{
		$set: {
			projectEnd: new Date('Jan 01, 2020'),
			rating: 5,
			partners: [ { name: "TU Wien" } ]
		}
	}
);
