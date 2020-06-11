using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainDTrainorV2.API.Middleware
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public HangfireAuthorizationFilter() { }
    public bool Authorize(DashboardContext context)
        {
            //var httpContext = context.GetHttpContext();​
            return true;
        }
    }
}
