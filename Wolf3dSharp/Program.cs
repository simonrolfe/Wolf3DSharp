using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Wolf3dSharp.NonWolf.Logging;

namespace Wolf3dSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot config;

            Console.WriteLine("Welcome to Wolf3dSharp!");
            Console.WriteLine("Reading config...");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            config = builder.Build();

            bool gotConfig;
            LogLevel logLevel;
            if (Enum.TryParse<LogLevel>(config["LogLevel"], out logLevel))
            {
                gotConfig = true;
            }
            else
            {
                int logLevelInt;
                if (int.TryParse(config["logLevel"], out logLevelInt))
                {
                    try
                    {
                        logLevel = (LogLevel)logLevelInt;
                        gotConfig = true;
                    }
                    catch
                    {
                        logLevel = LogLevel.Debug;
                        gotConfig = false;
                    }
                }
                else
                {
                    logLevel = LogLevel.Debug;
                    gotConfig = false;
                }
            }

            AbstractLogger logger;

            logger = new ConsoleLogger(logLevel);
            if (config["logger"].ToLowerInvariant() != "console")
            {
                logger.LogWarning("Console logger is the only thing supported at the moment, using it anyway.");
            }
            if (gotConfig)
            {
                logger.LogInfo($"Using log level {logLevel} with console logger.");
            }
            else
            {
                logger.LogWarning("Couldn't get log level, logging everything with console logger.");
            }

            GameLoader gameLoader = new GameLoader(config["gameDataPath"], logger);
        }

    }
}
