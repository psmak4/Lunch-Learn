using EntityFramework.Web.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EntityFramework.Web.Areas.Admin.Controllers
{
	public class TagsController : Controller
	{
		private BlogEntities db = new BlogEntities();

		// GET: Admin/Tags
		public ActionResult Index()
		{
			return View(db.Tags.OrderBy(t => t.Name).AsEnumerable());
		}

		// GET: Admin/Tags/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Tags/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name")] Tag tag)
		{
			if (ModelState.IsValid)
			{
				tag.Id = Guid.NewGuid();
				db.Tags.Add(tag);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(tag);
		}

		// GET: Admin/Tags/Edit/5
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tag tag = db.Tags.Find(id);
			if (tag == null)
			{
				return HttpNotFound();
			}
			return View(tag);
		}

		// POST: Admin/Tags/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Tag tag)
		{
			if (ModelState.IsValid)
			{
				db.Entry(tag).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(tag);
		}

		// GET: Admin/Tags/Delete/5
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tag tag = db.Tags.Find(id);
			if (tag == null)
			{
				return HttpNotFound();
			}
			return View(tag);
		}

		// POST: Admin/Tags/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			db.Database.ExecuteSqlCommand($"delete from PostTags where TagId = '{id}'");
			db.Database.ExecuteSqlCommand($"delete from Tags where Id = '{id}'");

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