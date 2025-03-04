# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY shelly-recorder/*.csproj ./shelly-recorder/
COPY shelly-connector/*.csproj ./shelly-connector/
RUN dotnet new sln && dotnet sln add shelly-recorder/shelly-recorder.csproj && dotnet sln add shelly-connector/shelly-connector.csproj
RUN dotnet restore

# Copy the remaining files and build the application
COPY shelly-recorder/. ./shelly-recorder/
COPY shelly-connector/. ./shelly-connector/
RUN dotnet publish -c Release -o out shelly-recorder/shelly-recorder.csproj

# Use the official .NET runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "shelly-recorder.dll"]