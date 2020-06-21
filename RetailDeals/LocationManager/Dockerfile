FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY bin/Release/netcoreapp3.1/publish/ LocationManager/
WORKDIR /LocationManager
ENTRYPOINT ["dotnet", "LocationManager.dll"]