# Use the official .NET 6 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the solution file and project files
COPY MetaTicTacToe.sln ./
COPY *.csproj ./

# Set the working directory for subsequent commands
WORKDIR /app/

# Restore dependencies
RUN dotnet restore MetaTicTacToe.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish MetaTicTacToe.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "MetaTicTacToe.dll"]
