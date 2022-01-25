docker pull mcr.microsoft.com/dotnet/sdk:latest
docker pull mcr.microsoft.com/dotnet/aspnet:latest

docker build --file .\WeatherForecast\Dockerfile --tag eassbhhtgu/weatherforecast:latest .\WeatherForecast\

docker stack deploy --compose-file .\docker-compose.yml spike
