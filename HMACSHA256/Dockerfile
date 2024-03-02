FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HMACSHA256/HMACSHA256.csproj", "HMACSHA256/"]
RUN dotnet restore "HMACSHA256/HMACSHA256.csproj"
COPY . .
WORKDIR "/src/HMACSHA256"
RUN dotnet build "HMACSHA256.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HMACSHA256.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HMACSHA256.dll"]
