#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["standalone-apps/odata-api-dotnet/odata-api-dotnet.csproj", "standalone-apps/odata-api-dotnet/"]
RUN dotnet restore "standalone-apps/odata-api-dotnet/odata-api-dotnet.csproj"
COPY . .
WORKDIR "/src/standalone-apps/odata-api-dotnet"
RUN dotnet build "odata-api-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "odata-api-dotnet.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "odata-api-dotnet.dll"]