using EntityFramework.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace EntityFramework.Web.Controllers
{
	public class PostsController : Controller
	{
		private BlogEntities db = new BlogEntities();

		public ActionResult Index()
		{
			var model = db.Posts.AsEnumerable();

			return View(model);
		}

		[ChildActionOnly]
		public ActionResult LatestPosts()
		{
			var model = db.GetLatestPosts(3);

			return PartialView(model);
		}
	}
}