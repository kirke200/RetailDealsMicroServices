
db = db.getSiblingDB("RetailDealsDb")

db.createUser(
	{
		user: "DockerUser",
		pwd: "DockerPass",
		roles: [
			{
				role: "readWrite",
				db: "RetailDealsDb"
			}
		]
	}
);

//Create collections
db.createCollection("Users");
db.createCollection("RetailGroups")
