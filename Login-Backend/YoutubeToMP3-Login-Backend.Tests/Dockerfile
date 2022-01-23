#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /app
COPY . .
RUN dotnet test

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["YoutubeToMP3-Login-Backend.Tests/YoutubeToMP3-Login-Backend.Tests.csproj", "YoutubeToMP3-Login-Backend.Tests/"]
COPY ["YoutubeToMP3-Login-Backend/YoutubeToMP3-Login-Backend.csproj", "YoutubeToMP3-Login-Backend/"]
RUN dotnet restore "YoutubeToMP3-Login-Backend.Tests/YoutubeToMP3-Login-Backend.Tests.csproj"
COPY . .
WORKDIR "/src/YoutubeToMP3-Login-Backend.Tests"
RUN dotnet build "YoutubeToMP3-Login-Backend.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YoutubeToMP3-Login-Backend.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YoutubeToMP3-Login-Backend.Tests.dll"]