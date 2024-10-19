FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5005
EXPOSE 5006

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SpeedSolverAPI/SpeedSolverAPI.csproj", "SpeedSolverAPI/"]
COPY ["SpeedSolverCore/SpeedSolverCore.csproj", "SpeedSolverCore/"]
COPY ["SpeedSolverDatabaseAccess/SpeedSolverDatabaseAccess.csproj", "SpeedSolverDatabaseAccess/"]
COPY ["SpeedSolverDatabase/SpeedSolverDatabase.csproj", "SpeedSolverDatabase/"]
RUN dotnet restore "./SpeedSolverAPI/SpeedSolverAPI.csproj"
COPY . .
WORKDIR "/src/SpeedSolverAPI"
RUN dotnet build "./SpeedSolverAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SpeedSolverAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpeedSolverAPI.dll"]