FROM mcr.microsoft.com/dotnet/sdk:latest as build-env
WORKDIR /app
COPY . .
RUN dotnet restore --source https://api.nuget.org/v3/index.json
RUN dotnet publish Api.WebApplication/Api.WebApplication.csproj --configuration Release --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:latest
EXPOSE 443/tcp
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "Api.WebApplication.dll"]
