FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SDD.Assignment3.CRNG/SDD.Assignment3.CRNG.csproj", "SDD.Assignment3.CRNG/"]
RUN dotnet restore "SDD.Assignment3.CRNG/SDD.Assignment3.CRNG.csproj"
COPY . .
WORKDIR "/src/SDD.Assignment3.CRNG"
RUN dotnet build "SDD.Assignment3.CRNG.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SDD.Assignment3.CRNG.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SDD.Assignment3.CRNG.dll"]
