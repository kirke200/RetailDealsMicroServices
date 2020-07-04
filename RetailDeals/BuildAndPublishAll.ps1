docker image prune -f

Push-Location APIGateway 
.\BuildAndPublish.ps1
Pop-Location

Push-Location Dataminer 
.\BuildAndPublish.ps1
Pop-Location

Push-Location IdentityManager 
.\BuildAndPublish.ps1
Pop-Location

Push-Location LocationManager 
.\BuildAndPublish.ps1
Pop-Location

Push-Location OfferManager 
.\BuildAndPublish.ps1
Pop-Location

Push-Location RecipeManager 
.\BuildAndPublish.ps1
Pop-Location

Push-Location RetailItemUpdater 
.\BuildAndPublish.ps1
Pop-Location

docker stop apigateway-container dataminer-container identitymanager-container locationmanager-container offermanager-container recipemanager-container retailitemupdater-container
docker rm apigateway-container dataminer-container identitymanager-container locationmanager-container offermanager-container recipemanager-container retailitemupdater-container
docker-compose up -d