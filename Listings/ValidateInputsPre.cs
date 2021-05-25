public static bool ValidateInputs(Config conf)
{
    if (conf.Interval < 10 || conf.Interval > 300)// check for right interval range
    {
        throw new BadConfigException("Intervall im falschen Wertebereich." +
                                     " Intervall muss zwischen 10 und 300 liegen.");
    }
    // check if city contains only letters
    if (!Regex.IsMatch(conf.Location.City, @"^[a-zA-Z -']+$"))
    {
        throw new BadConfigException("Stadtname beinhaltet unbekannte Zeichen.");
    }
    return true;
}