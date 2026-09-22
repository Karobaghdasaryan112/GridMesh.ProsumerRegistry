FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GridMesh.ProsumerRegistery/GridMesh.ProsumerRegistery.csproj", "GridMesh.ProsumerRegistery/"]
RUN dotnet restore "GridMesh.ProsumerRegistry/GridMesh.ProsumerRegistry.csproj"
COPY . .
WORKDIR "/src/GridMesh.ProsumerRegistery"
RUN dotnetbuild "./GridMesh.Pr osumerRegistry.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GridMesh.ProsumerRegistry.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GridMesh.ProsumerRegistery.dll"]
