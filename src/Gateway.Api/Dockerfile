#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Gateway.Api/Gateway.Api.csproj", "Gateway.Api/"]
COPY ["Gateway.Services/Gateway.Services.csproj", "Gateway.Services/"]
COPY ["Gateway.Dtos/Gateway.Dtos.csproj", "Gateway.Dtos/"]
COPY ["Gateway.DataAccess/Gateway.DataAccess.csproj", "Gateway.DataAccess/"]
COPY ["CarsStatusesGenerator.Dtos/CarsStatusesGenerator.Dtos.csproj", "CarsStatusesGenerator.Dtos/"]
RUN dotnet restore "Gateway.Api/Gateway.Api.csproj"
COPY . .
WORKDIR "/src/Gateway.Api"
RUN dotnet build "Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]