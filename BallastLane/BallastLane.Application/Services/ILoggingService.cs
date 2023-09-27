using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallastLane.Application.Common;

namespace BallastLane.Application.Services
{
    public interface ILoggingService
    {
        public void Log(ILogMessage logMessage);
    }
}
