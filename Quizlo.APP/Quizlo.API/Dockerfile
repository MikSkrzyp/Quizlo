# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Quizlo.API.csproj", "./"]
RUN dotnet restore "Quizlo.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Quizlo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quizlo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quizlo.API.dll"]
