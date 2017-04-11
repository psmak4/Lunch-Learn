using EntityFramework.Web.Areas.Admin.ViewModels.Posts;
using EntityFramework.Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EntityFramework.Web.Areas.Admin.Controllers
{
	public class PostsController : Controller
	{
		private BlogEntities db = new BlogEntities();

		// GET: Admin/Posts
		public ActionResult Index()
		{
			return View(db.Posts.OrderByDescending(p => p.Date).ToList());
		}

		// GET: Admin/Posts/Details/5
		public ActionResult Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return HttpNotFound();
			}
			return View(post);
		}

		// GET: Admin/Posts/Create
		public ActionResult Create()
		{
			var model = new CreateViewModel();
			model.Date = DateTime.Now;

			return View(model);
		}

		// POST: Admin/Posts/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				var post = new Post();
				post.Id = Guid.NewGuid();
				post.Title = model.Title;
				post.Content = model.Content;
				post.Date = model.Date;
				db.Posts.Add(post);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(model);
		}

		// GET: Admin/Posts/Edit/5
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return HttpNotFound();
			}

			var model = new EditViewModel();
			model.Id = post.Id;
			model.Title = post.Title;
			model.Content = post.Content;
			model.Date = post.Date;

			return View(model);
		}

		// POST: Admin/Posts/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EditViewModel model)
		{
			if (ModelState.IsValid)
			{
				Post post = db.Posts.Find(model.Id);
				if (post == null)
				{
					return HttpNotFound();
				}
				post.Title = model.Title;
				post.Content = model.Content;
				post.Date = model.Date;
				db.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(model);
		}

		// GET: Admin/Posts/Delete/5
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return HttpNotFound();
			}
			return View(post);
		}

		// POST: Admin/Posts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			Post post = db.Posts.Find(id);
			db.Posts.Remove(post);
			db.SaveChanges();
			return RedirectToAction("Index");
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