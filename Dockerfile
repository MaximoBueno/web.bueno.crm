FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5555

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["web.bueno.crm.lia/web.bueno.crm.lia.csproj", "web.bueno.crm.lia/"]
RUN dotnet restore "./web.bueno.crm.lia/web.bueno.crm.lia.csproj"
COPY . .
WORKDIR "/src/web.bueno.crm.lia"
RUN dotnet build "./web.bueno.crm.lia.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./web.bueno.crm.lia.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web.bueno.crm.lia.dll"]

