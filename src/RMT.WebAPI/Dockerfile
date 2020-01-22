#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/RMT.WebAPI/RMT.WebAPI.csproj", "src/RMT.WebAPI/"]
COPY ["src/RMT.ApplicationCore/RMT.ApplicationCore.csproj", "src/RMT.ApplicationCore/"]
COPY ["src/RMT.Infrastructure/RMT.Infrastructure.csproj", "src/RMT.Infrastructure/"]
RUN dotnet restore "src/RMT.WebAPI/RMT.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/RMT.WebAPI"
RUN dotnet build "RMT.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RMT.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RMT.WebAPI.dll"]