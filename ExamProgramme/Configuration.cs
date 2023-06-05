namespace ExamProgramme
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ExamProgramme"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("ExamServerConnection");
            }
        }
    }
}
