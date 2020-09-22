using System;
using Asgard.Configuration;
using Asgard.Server;

namespace Asgard
{
    internal static class Bootstrap
    {
        public static void Main(string[] args)
        {
            ServerConfig.Build(args);
            
            var ss = new ServerHandler();
            ss.Start();

            while (ss.IsRunning) {}

            
            Console.WriteLine("bye bye");
        }
    }
}