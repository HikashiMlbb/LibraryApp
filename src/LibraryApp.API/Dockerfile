FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /source
COPY ["src/LibraryApp.API/LibraryApp.API.csproj", "src/LibraryApp.API/"]
COPY ["src/LibraryApp.Application/LibraryApp.Application.csproj", "src/LibraryApp.Application/"]
COPY ["src/LibraryApp.Domain/LibraryApp.Domain.csproj", "src/LibraryApp.Domain/"]
COPY ["src/LibraryApp.Infrastructure/LibraryApp.Infrastructure.csproj", "src/LibraryApp.Infrastructure/"]
COPY ["src/LibraryApp.Persistence/LibraryApp.Persistence.csproj", "src/LibraryApp.Persistence/"]
RUN dotnet restore "src/LibraryApp.API/LibraryApp.API.csproj"
COPY . .
WORKDIR "/source/src/LibraryApp.API"
RUN dotnet build "LibraryApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LibraryApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApp.API.dll"]
