public class ImageHandler : IImageHandler
{
    public ImageResponse GetImageData(WeatherInterpretation weatherInterpretation)
    {
        var queryString = BuildRouteString(weatherInterpretation);
        var response = _api.Get(queryString);
        response.Wait();
        return response.Result.ToObject<ImageResponse>();
    }

    public string BuildRouteString(WeatherInterpretation weatherInterpretation)
    {
        return $"?query={weatherInterpretation.Weather} 
            {weatherInterpretation.Daytime} {weatherInterpretation.Feeling}";
    }
}