db.projects.updateMany(
	{
		projectType : "REQUEST_FUNDING_PROJECT"
	},
	{
		$set: { isEUSponsered: true }
	}
);
