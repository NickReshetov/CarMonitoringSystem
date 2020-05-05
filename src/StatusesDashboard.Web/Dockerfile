#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["StatusesDashboard.Web/StatusesDashboard.Web.csproj", "StatusesDashboard.Web/"]
COPY ["StatusesDashboard.Web.DataAccess/StatusesDashboard.Web.DataAccess.csproj", "StatusesDashboard.Web.DataAccess/"]
COPY ["DataStorage.Dtos/DataStorage.Dtos.csproj", "DataStorage.Dtos/"]
RUN dotnet restore "StatusesDashboard.Web/StatusesDashboard.Web.csproj"
COPY . .
WORKDIR "/src/StatusesDashboard.Web"
RUN dotnet build "StatusesDashboard.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StatusesDashboard.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StatusesDashboard.Web.dll"]