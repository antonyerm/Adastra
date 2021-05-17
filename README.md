# Adastra
This is a training project used in EPAM Internal Lab.

The project is a Visual Studio soulition and consists of 2 projects: 
- Adastra.WebAPI - this is a part for requesting the info from external API;
- Adastra.MVC - this is a UI part.

WebAPI part uses the following techniques to read info from https://openweathermap.org/api:
- API key storage using user secrets feature of Visual Studio (configuration file stored in AppData folder). The model is registered in Startup.cs file. The API key string is then read through IOptions<OpenWeather>.Values in OpenWeatherService.cs;
- Service for retrieveing data from external API - OpenWeatherService using HttpClient object created by HttpClientFactory.
- Model class for deserializing the response from external API, see class OpenWeatherResponse;
- Model class for serializing the output data, see class WeatherForecast.

MVC part ues the following techniques:
- Views and controllers for the user to submit the city name in which the forecast is requested;
- Model class for deserializing the response form WebAPI part, see class OpenWeatherForecast.
- Model for storing the request parameters (e.g. city name) submitted my the user.
