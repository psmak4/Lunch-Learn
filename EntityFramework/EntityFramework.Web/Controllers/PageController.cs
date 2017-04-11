using EntityFramework.Web.Models;
using EntityFramework.Web.ViewModels.Page;
using System.Linq;
using System.Web.Mvc;

namespace EntityFramework.Web.Controllers
{
	public class PageController : Controller
	{
		private BlogEntities db = new BlogEntities();

		[ChildActionOnly]
		public ActionResult LatestPosts()
		{
			var model = db.GetLatestPosts(3);

			return PartialView(model);
		}

		[ChildActionOnly]
		public ActionResult Archives()
		{
			var model = db.Posts.Select(p => new ArchivesViewModel() { Year = p.Date.Year, Month = p.Date.Month }).Distinct();

			return PartialView(model);
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