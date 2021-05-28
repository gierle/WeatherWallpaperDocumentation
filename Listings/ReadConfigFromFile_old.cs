public JObject ReadConfigFromFile()
{
    string jsonString = null;

    try
    {
        jsonString = _fileAccessor.ReadFile(_configPath);
    }
    catch (Exception e)
    {
        System.Diagnostics.Trace.WriteLine("Couldnt read config file");
        System.Diagnostics.Trace.WriteLine(e.Message);
    }

    JObject conf = string.IsNullOrEmpty(jsonString) ? null : JObject.Parse(jsonString);

    return conf;
}