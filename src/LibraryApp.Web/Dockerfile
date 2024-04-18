FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["*.csproj", ".", "./"]
RUN dotnet restore && dotnet build -c $BUILD_CONFIGURATION && dotnet publish -c $BUILD_CONFIGURATION -o /app/ --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8000
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "LibraryApp.Web.dll" ]
