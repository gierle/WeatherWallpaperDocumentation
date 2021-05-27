// ConfigValidator
public bool ValidateInputs(Config conf)
{
	foreach (var aspect in _validationAspects)
	{
		aspect.Validate(conf);
	}
	return true;
}

// Implementation of IValidationAspect
public class IsCorrectCity : IValidationAspect
{
    public void Validate(Config conf)
    {
        if (!Regex.IsMatch(conf.Location.City, @"^[a-zA-Z -']+$"))
        {
            throw new BadConfigException("Stadtname beinhaltet unbekannte 
                Zeichen.");
        }
    }
}