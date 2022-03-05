using System.Web.Routing;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace Dresscode.Feature.Content.Pipelines
{
    public class LoadRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}