using System;

namespace GP.BLL.Interfaces.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Debug(string message, Exception exception);
    }
}