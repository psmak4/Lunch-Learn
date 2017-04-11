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

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}