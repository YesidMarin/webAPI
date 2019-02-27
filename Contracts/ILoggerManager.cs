using System;
namespace Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LodDebug(string message);
        void LogError(string message);
        void LogFatal(string message);
    }
}
