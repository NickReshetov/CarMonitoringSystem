#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DataStorage.Api/DataStorage.Api.csproj", "DataStorage.Api/"]
COPY ["DataStorage.Services/DataStorage.Services.csproj", "DataStorage.Services/"]
COPY ["DataStorage.DataAccess/DataStorage.DataAccess.csproj", "DataStorage.DataAccess/"]
COPY ["DataStorage.Dtos/DataStorage.Dtos.csproj", "DataStorage.Dtos/"]
RUN dotnet restore "DataStorage.Api/DataStorage.Api.csproj"
COPY . .
WORKDIR "/src/DataStorage.Api"
RUN dotnet build "DataStorage.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataStorage.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataStorage.Api.dll"]