db.projects.updateMany(
	{},
	{
		$rename: { rating: "projectRating" }
	}
);
