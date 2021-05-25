// ConfigValidator
private List<IValidationAspect> _validationAspects;

public void Register(IValidationAspect aspect)
{
    _validationAspects.Add(aspect);
}
public bool ValidateInputs(Config conf)
{
    foreach (var aspect in _validationAspects)
    {
        aspect.Validate(conf);
    }
    return true;
}
// Validation for City-Name
public class IsCorrectCity : IValidationAspect
{
    public void Validate(Config conf)
    {
        // check if city contains only letters
        if (!Regex.IsMatch(conf.Location.City, @"^[a-zA-Z -']+$"))
        {
            throw new BadConfigException("Stadtname beinhaltet unbekannte Zeichen.");
        }
    }
}