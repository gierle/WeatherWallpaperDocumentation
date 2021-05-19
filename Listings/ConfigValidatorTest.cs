public ConfigValidatorTest()
{ 
    // ConfigValidator is needed in every unit test, so we initialize it here
    _configValidator = new ConfigValidator();
    _configValidator.Register(new IsCorrectCity());
    _configValidator.Register(new IsCorrectInterval());
}

[Fact]
public void ValidateInputsFalseCity()
{
    // Arrange
    const string city = "F4k3 ci7y";
    const string country = "DE";
    const int interval = 10;
    Config conf = new Config()
    {
        Interval = interval,
        Location = new Location()
        {
            City = city,
            CountryAbrv = country
        }
    };
    const string actualExceptionMessage 
        = "Stadtname beinhaltet unbekannte Zeichen.";
    // Act, Assert
    var ex = Assert.Throws<BadConfigException>(
        () => _configValidator.ValidateInputs(conf));
    Assert.Equal(actualExceptionMessage, ex.Message);
}