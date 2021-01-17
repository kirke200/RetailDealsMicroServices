docker image prune -f

Push-Location APIGateway 
.\BuildAndPublish.ps1
Pop-Location

Push-Location RetailItemUpdater
.\BuildAndPublish.ps1
Pop-Location

docker stop apigateway-container retailitemupdater-container
docker rm apigateway-container retailitemupdater-container
docker-compose up -d