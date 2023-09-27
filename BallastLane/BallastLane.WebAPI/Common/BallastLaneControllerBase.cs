using Microsoft.AspNetCore.Mvc;

namespace BallastLane.WebAPI.Common
{
    public class BallastLaneControllerBase : ControllerBase
    {
        public StatusCodeResult CreateCustomResponseResult(int statusCode, string message)
        {
            return new StatusCodeResult(statusCode);
        }
    }
}
