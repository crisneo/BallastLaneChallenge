#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BallastLane.WebAPI/BallastLane.WebAPI.csproj", "BallastLane.WebAPI/"]
COPY ["BallastLane.Application/BallastLane.Application.csproj", "BallastLane.Application/"]
COPY ["BallastLane.Domain/BallastLane.Domain.csproj", "BallastLane.Domain/"]
COPY ["BallastLane.DataAccess/BallastLane.DataAccess.csproj", "BallastLane.DataAccess/"]
COPY ["BallastLane.Infrastructure/BallastLane.Infrastructure.csproj", "BallastLane.Infrastructure/"]
RUN dotnet restore "BallastLane.WebAPI/BallastLane.WebAPI.csproj"
COPY . .
WORKDIR "/src/BallastLane.WebAPI"
RUN dotnet build "BallastLane.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BallastLane.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BallastLane.WebAPI.dll"]