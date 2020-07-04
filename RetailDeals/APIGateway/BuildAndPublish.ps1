dotnet build
dotnet publish -c Release

docker build -t apigateway-image -f Dockerfile .
