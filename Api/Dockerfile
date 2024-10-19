#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Api/Raffle.Api.csproj", "Raffle.Api/"]
COPY ["Application/Raffle.Application.csproj", "Raffle.Application/"]
COPY ["Domain/Raffle.Domain.csproj", "Raffle.Domain/"]
COPY ["Infrastructure/Raffle.Infrastructure.csproj", "Raffle.Infrastructure/"]
RUN dotnet restore "./Api/Raffle.Api.csproj"

COPY . .
WORKDIR "/src/Raffle.Api"
RUN dotnet build "Raffle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Raffle.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Raffle.Api.dll"]