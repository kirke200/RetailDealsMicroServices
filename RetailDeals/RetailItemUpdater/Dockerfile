FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_ENVIRONMENT Docker
ENV ASPNETCORE_URLS http://*:5001
COPY bin/Release/netcoreapp3.1/publish/ RetailItemUpdater/
WORKDIR /RetailItemUpdater
ENTRYPOINT ["dotnet", "RetailItemUpdater.dll"]