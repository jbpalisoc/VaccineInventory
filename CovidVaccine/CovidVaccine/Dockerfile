#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CovidVaccine/CovidVaccine.csproj", "CovidVaccine/"]
COPY ["../CovidVaccineRepository/CovidVaccine.Repository.csproj", "../CovidVaccineRepository/"]
COPY ["CovidVaccine.Model/CovidVaccine.Model.csproj", "CovidVaccine.Model/"]
RUN dotnet restore "CovidVaccine/CovidVaccine.csproj"
COPY . .
WORKDIR "/src/CovidVaccine"
RUN dotnet build "CovidVaccine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CovidVaccine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidVaccine.dll"]