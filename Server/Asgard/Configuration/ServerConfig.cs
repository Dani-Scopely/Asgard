using System;
using System.Linq;

namespace Asgard.Configuration
{
    public static class ServerConfig
    {
        private static string Server = "infusos.com";
        private static string ServerWS = "ws://infusos.com:9000";
        private static string Database = "asgard";
        private static string Username = "asgard";
        private static string Password = "46365210Q";

        public static readonly string Url = $"server={Server};userid={Username};password={Password};database={Database}";

        public static void Build(string[] parameters)
        {
            if (parameters.Length != 0)
            {
                Server = parameters[0];
                ServerWS = parameters[1];
                Database = parameters[2];
                Username = parameters[3];
                Password = parameters[4];
            }
        }
    }
}