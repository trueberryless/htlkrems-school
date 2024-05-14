db.projects.updateMany(
	{},
	{
		$push: {
			partners: {
				$each: [
					{ name: "HTL Krems" },
					{ name: "TU Graz" }
				]
			}
		}
	}
);
db.projects.updateMany(
	{},
	{
		$pull: {
			partners: {
				name: "HTL Krems"
			}
		}
	}
);

