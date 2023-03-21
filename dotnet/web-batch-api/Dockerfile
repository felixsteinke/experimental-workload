#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web-batch-api/web-batch-api.csproj", "web-batch-api/"]
RUN dotnet restore "web-batch-api/web-batch-api.csproj"
COPY . .
WORKDIR "/src/web-batch-api"
RUN dotnet build "web-batch-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "web-batch-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web-batch-api.dll"]