dotnet build
dotnet publish -c Release

docker build -t recipemanager-image -f Dockerfile .
