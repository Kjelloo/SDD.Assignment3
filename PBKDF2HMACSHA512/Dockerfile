FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PBKDF2HMACSHA512/PBKDF2HMACSHA512.csproj", "PBKDF2HMACSHA512/"]
RUN dotnet restore "PBKDF2HMACSHA512/PBKDF2HMACSHA512.csproj"
COPY . .
WORKDIR "/src/PBKDF2HMACSHA512"
RUN dotnet build "PBKDF2HMACSHA512.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PBKDF2HMACSHA512.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PBKDF2HMACSHA512.dll"]
