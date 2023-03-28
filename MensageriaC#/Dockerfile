FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 
WORKDIR /usr/api_csharp
COPY . .
RUN dotnet restore --disable-parallel
RUN dotnet publish -c release -o /out --no-restore

FROM  mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /App
COPY --from=build /out /App

EXPOSE 80

ENTRYPOINT ["dotnet", "/App/MensageriaC#.dll"]