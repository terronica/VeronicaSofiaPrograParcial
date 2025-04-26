# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VeronicaSofiaPrograParcial.csproj", "."]
RUN dotnet restore "VeronicaSofiaPrograParcial.csproj"
COPY . .
RUN dotnet build "VeronicaSofiaPrograParcial.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "VeronicaSofiaPrograParcial.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "VeronicaSofiaPrograParcial.dll"]