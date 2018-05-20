using System.Web;
using System.Web.Routing;

namespace Alex
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("index", "", "~/IndexA.aspx");
        }
    }
}
