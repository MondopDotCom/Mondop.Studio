using System;
using System.Collections.Generic;
using System.Text;

namespace Mondop.Core.Rendering
{
    public enum LogType
    {
        Debug,
        Info,
        Warn,
        Error
    };

    public interface IRenderLogger
    {
        void Log(LogType logType, string message);
    }
}
