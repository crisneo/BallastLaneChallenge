using BallastLane.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Infrastructure.Common
{
    public class LogMessage : ILogMessage
    {
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }
}
