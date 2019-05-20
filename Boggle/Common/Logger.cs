using System;
namespace Boggle.Common
{
    public class Logger
    {
        private enum LogLevel
        {
            DEBUG,
            INFO,
            ERROR,
            WARNING
        };

        private Logger(){ }

        public static void Info(string message)
        {
            Log(message, LogLevel.INFO);
        }

        public static void Debug(string message)
        {
            Log(message, LogLevel.INFO);
        }

        public static void Error(string message)
        {
            Log(message, LogLevel.INFO);
            Environment.Exit(100);
        }

        public static void Warning(string message)
        {
            Log(message, LogLevel.INFO);
        }

        private static void Log(string message, LogLevel level)
        {
            var logContent = $"{DateTime.Now.ToShortTimeString()} {level}: {message}";
            Console.WriteLine($"{logContent}");
        }
    }
}
