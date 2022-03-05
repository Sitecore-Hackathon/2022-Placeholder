using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Feature.Test.Rendering.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureTest(this RenderingEngineOptions options)
        {
            /*
            options.AddModelBoundView<MyModel>("MyView");
            */
            return options;
        }
    }
}