using LoggingSample.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingSample
{
    public class ColoredConsoleLogger : ILogger
    {
        public static object _lock = new object();
        private readonly string _name;
        private readonly ColoredConsoleLoggerConfiguration _config;
        public ColoredConsoleLogger(string name, ColoredConsoleLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            lock(_lock)
            {
                if(_config.EventId == 0 || _config.EventId == eventId)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)} - {_config.Color} - {Console.ForegroundColor.ToString()} ");
                    Console.ResetColor();
                }
            }
        }
    }
}
