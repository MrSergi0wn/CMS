FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/CMS/CMS.csproj", "Src/CMS/"]
COPY ["Src/CMS.AppSettings/CMS.AppSettings.csproj", "Src/CMS.AppSettings/"]
COPY ["Src/CMS.Models/CMS.Models.csproj", "Src/CMS.Models/"]
COPY ["Src/CMS.Domain/CMS.Domain.csproj", "Src/CMS.Domain/"]
COPY ["Src/CMS.Repository/CMS.Repository.csproj", "Src/CMS.Repository/"]
COPY ["Src/CMS.Context/CMS.Context.csproj", "Src/CMS.Context/"]
COPY ["Src/CMS.ServicesManager/CMS.ServicesManager.csproj", "Src/CMS.ServicesManager/"]
COPY ["Src/CMS.Services/CMS.Services.csproj", "Src/CMS.Services/"]
RUN dotnet restore "./Src/CMS/CMS.csproj"
COPY . .
WORKDIR "/src/Src/CMS"
RUN dotnet build "./CMS.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CMS.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMS.dll"]
