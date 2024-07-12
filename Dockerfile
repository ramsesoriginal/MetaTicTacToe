# Use the official .NET 6 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy the csproj and restore as distinct layers
COPY MetaTicTacToe/*.sln ./MetaTicTacToe/
COPY MetaTicTacToe/*.csproj ./MetaTicTacToe/
RUN dotnet restore

# Copy everything else and build
COPY MetaTicTacToe/. ./MetaTicTacToe/
WORKDIR /app/MetaTicTacToe
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/MetaTicTacToe/out .

ENTRYPOINT ["dotnet", "MetaTicTacToe.dll"]
