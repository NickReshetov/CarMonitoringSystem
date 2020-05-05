#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarsStatusesGenerator/CarsStatusesGenerator.csproj", "CarsStatusesGenerator/"]
COPY ["CarsStatusesGenerator.Services/CarsStatusesGenerator.Services.csproj", "CarsStatusesGenerator.Services/"]
COPY ["CarsStatusesGenerator.DataAccess/CarsStatusesGenerator.DataAccess.csproj", "CarsStatusesGenerator.DataAccess/"]
COPY ["CarsStatusesGenerator.Dtos/CarsStatusesGenerator.Dtos.csproj", "CarsStatusesGenerator.Dtos/"]
RUN dotnet restore "CarsStatusesGenerator/CarsStatusesGenerator.csproj"
COPY . .
WORKDIR "/src/CarsStatusesGenerator"
RUN dotnet build "CarsStatusesGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarsStatusesGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsStatusesGenerator.dll"]