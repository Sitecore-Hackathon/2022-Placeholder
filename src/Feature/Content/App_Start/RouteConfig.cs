using System.Web.Mvc;
using System.Web.Routing;

namespace Dresscode.Feature.Content
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "CheckoutPurchase",
                url: "api/{controller}/{action}"
            );
        }
    }
}