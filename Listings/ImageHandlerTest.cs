[Fact]
public void GetImageDataSuccessful()
{
    // Capture
    var correctApiResponse = new ImageResponse()
    {
        Results = new List<Images>{
            new Images { Links = new Links
            {
                Download = "https://unsplash.com/photos/XxElwSAH0AA/download"
            }}}
    };
    var responseJson = JObject.FromObject(correctApiResponse);
    var responseJsonString = responseJson.ToString();
    var api = new Mock<IAPICaller>();
    api.Setup(caller => caller.Get(It.IsAny<string>())).Returns(Task.FromResult(responseJsonString)).Verifiable();
    // Arrange
    var handler = new ImageHandler(api.Object);
    string queryString = "?query=doesnt matter";
    // Act
    var result = handler.GetImageData(queryString);
    // Assert
    Assert.Equal(result.Results.First().Links.Download, correctApiResponse.Results.First().Links.Download);
    // Verify
    api.Verify();
}