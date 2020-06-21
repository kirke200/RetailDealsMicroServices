dotnet build
dotnet publish -c Release

docker build -t dataminer-image -f Dockerfile .
