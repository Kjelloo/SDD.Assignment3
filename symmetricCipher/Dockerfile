FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["symmetricCipher/symmetricCipher.csproj", "symmetricCipher/"]
RUN dotnet restore "symmetricCipher/symmetricCipher.csproj"
COPY . .
WORKDIR "/src/symmetricCipher"
RUN dotnet build "symmetricCipher.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "symmetricCipher.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "symmetricCipher.dll"]
