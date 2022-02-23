#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompa
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CustomerContactInformationService.csproj", "."]
RUN dotnet restore "./CustomerContactInformationService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CustomerContactInformationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerContactInformationService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY . .
WORKDIR /App
ENTRYPOINT ["dotnet", "CustomerContactInformationService.dll"]