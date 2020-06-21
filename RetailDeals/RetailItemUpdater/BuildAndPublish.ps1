dotnet build
dotnet publish -c Release

docker build -t retailitemupdater-image -f Dockerfile .
