using System;
using GP.BLL.Interfaces.Logging;

namespace GP.BLL.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine("INFO: " + message);
        }

        public void Warn(string message)
        {
            Console.WriteLine("WARN: " + message);
        }

        public void Debug(string message)
        {
            Console.WriteLine("DEBUG: " + message);
        }

        public void Debug(string message, Exception exception)
        {
            Console.WriteLine("DEBUG: " + message + ", " + exception);
        }
    }
}