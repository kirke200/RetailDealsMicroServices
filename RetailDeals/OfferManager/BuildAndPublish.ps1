dotnet build
dotnet publish -c Release

docker build -t offermanager-image -f Dockerfile .
