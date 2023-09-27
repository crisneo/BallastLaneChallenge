using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Common
{
    public interface ILogMessage
    {
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }

    public enum LogSeverity
    {
        Warning,
        Error,
        Info
    }
}
