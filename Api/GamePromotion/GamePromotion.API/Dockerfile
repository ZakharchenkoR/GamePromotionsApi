#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api/GamePromotion/GamePromotion.API/GamePromotion.API.csproj", "Api/GamePromotion/GamePromotion.API/"]
COPY ["Api/GamePromotion/GamePromotion.BAL/GamePromotion.BAL.csproj", "Api/GamePromotion/GamePromotion.BAL/"]
COPY ["Api/GamePromotion/GamePromotion.DAL/GamePromotion.DAL.csproj", "Api/GamePromotion/GamePromotion.DAL/"]
RUN dotnet restore "Api/GamePromotion/GamePromotion.API/GamePromotion.API.csproj"
COPY . .
WORKDIR "/src/Api/GamePromotion/GamePromotion.API"
RUN dotnet build "GamePromotion.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamePromotion.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamePromotion.API.dll"]