public JObject ReadConfigFromFile()
{
    try
    {
        return JObject.Parse(_fileAccessor.ReadFile(_configPath));
    }
    catch
    {
        throw new BadConfigException("Einlesen der gespeicherten Konfiguration nicht moeglich.");
    }
}