using BallastLane.Application.Common;
using BallastLane.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Infrastructure.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(ILogMessage logMessage)
        {
            //TODO: implement logic for logging messages
            // we can use a library like Log4Net or Application Insights for Azure
        }
    }
}
