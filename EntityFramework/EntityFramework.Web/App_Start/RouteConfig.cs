using System.Web.Mvc;
using System.Web.Routing;

namespace EntityFramework.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Archive Posts",
				"Archives/{year}/{month}",
				new { controller = "Archives", action = "Posts" },
				new[] { "EntityFramework.Web.Controllers" }
			);

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Posts", action = "Index", id = UrlParameter.Optional },
				new[] { "EntityFramework.Web.Controllers" }
			);
		}
	}
}