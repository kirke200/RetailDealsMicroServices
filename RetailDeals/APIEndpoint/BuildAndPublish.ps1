dotnet build
dotnet publish -c Release

docker build -t apiendpoint-image -f Dockerfile .
