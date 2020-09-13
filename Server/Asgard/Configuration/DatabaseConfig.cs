namespace Asgard.Configuration
{
    public static class DatabaseConfig
    {
        private const string Server = "infusos.com";
        private const string Database = "asgard";
        private const string Username = "asgard";
        private const string Password = "46365210Q";

        public static readonly string Url = $"server={Server};userid={Username};password={Password};database={Database}";
    }
}