FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5010

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["./Login-Backend/YoutubeToMP3-Login-Backend/YoutubeToMP3-Login-Backend.csproj", "./"]
RUN dotnet restore "YoutubeToMP3-Login-Backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Login-Backend/YoutubeToMP3-Login-Backend/YoutubeToMP3-Login-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Login-Backend/YoutubeToMP3-Login-Backend/YoutubeToMP3-Login-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YoutubeToMP3-Login-Backend.dll"]
