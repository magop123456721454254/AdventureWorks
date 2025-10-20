# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY AdventureWorksAPI/*.csproj ./AdventureWorksAPI/
RUN dotnet restore AdventureWorksAPI/AdventureWorksAPI.csproj

# Copy the rest of the source and publish
COPY AdventureWorksAPI/. ./AdventureWorksAPI/
WORKDIR /src/AdventureWorksAPI
RUN dotnet publish AdventureWorksAPI.csproj -c Release -o /app

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "AdventureWorksAPI.dll"]
