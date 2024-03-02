FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AssignmentDel2/AssignmentDel2.csproj", "AssignmentDel2/"]
RUN dotnet restore "AssignmentDel2/AssignmentDel2.csproj"
COPY . .
WORKDIR "/src/AssignmentDel2"
RUN dotnet build "AssignmentDel2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AssignmentDel2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssignmentDel2.dll"]
