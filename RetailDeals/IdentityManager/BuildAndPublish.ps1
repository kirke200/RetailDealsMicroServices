dotnet build
dotnet publish -c Release

docker build -t identitymanager-image -f Dockerfile .
