dotnet build
dotnet publish -c Release

docker build -t locationmanager-image -f Dockerfile .
