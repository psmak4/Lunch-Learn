using EntityFramework.Web.Models;
using EntityFramework.Web.ViewModels.Archives;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace EntityFramework.Web.Controllers
{
	public class ArchivesController : Controller
	{
		private BlogEntities db = new BlogEntities();

		// GET: Archives
		public ActionResult Index()
		{
			var model = db.Posts.Select(p => new IndexViewModel() { Year = p.Date.Year, Month = p.Date.Month }).Distinct();

			return View(model);
		}

		public ActionResult Posts(int year, int month)
		{
			var model = new PostsViewModel()
			{
				Year = year,
				Month = month,
				Title = new DateTime(year, month, 1).ToString("MMMM yyyy", CultureInfo.InvariantCulture),
				Posts = db.Posts.Where(p => p.Date.Year == year && p.Date.Month == month).AsEnumerable()
			};

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