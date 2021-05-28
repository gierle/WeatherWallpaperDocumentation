public WeatherResponse GetWeatherData(Config currentConfig)
{
    var routeAttributes = new List<string>();
    routeAttributes.Add(LocationAsRouteAttribute(currentConfig.Location));
    string attributes = BuildRouteString(routeAttributes);
    var response = _api.Get(attributes);
    response.Wait();
    var responseAsJObject = JObject.Parse(response.Result);
    return responseAsJObject.ToObject<WeatherResponse>();
}