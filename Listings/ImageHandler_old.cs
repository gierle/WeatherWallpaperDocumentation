public class ImageHandler : IImageHandler
{	
	public ImageResponse GetImageData(String QueryString)
    {
        var response = _api.Get(QueryString);
        response.Wait();
        return response.Result.ToObject<ImageResponse>();
    }

    public string BuildRouteString(WeatherInterpretation weatherInterpretation)
    {
        return $"?query={weatherInterpretation.Weather} 
            weatherInterpretation.Daytime} {weatherInterpretation.Feeling}";
    }
}