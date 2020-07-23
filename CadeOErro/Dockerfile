#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CadeOErro.Server/CadeOErro.Server.csproj", "CadeOErro.Server/"]
COPY ["CadeOErro.Data/CadeOErro.Data.csproj", "CadeOErro.Data/"]
COPY ["CadeOErro.Domain/CadeOErro.Domain.csproj", "CadeOErro.Domain/"]
RUN dotnet restore "CadeOErro.Server/CadeOErro.Server.csproj"
COPY . .
WORKDIR "/src/CadeOErro.Server"
RUN dotnet build "./CadeOErro.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./CadeOErro.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet CadeOErro.Server.dll