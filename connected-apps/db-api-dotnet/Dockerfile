#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["connected-apps/db-api-dotnet/db-api-dotnet.csproj", "connected-apps/db-api-dotnet/"]
RUN dotnet restore "connected-apps/db-api-dotnet/db-api-dotnet.csproj"
COPY . .
WORKDIR "/src/connected-apps/db-api-dotnet"
RUN dotnet build "db-api-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "db-api-dotnet.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "db-api-dotnet.dll"]