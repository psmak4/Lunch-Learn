using EntityFramework.Web.Models;
using System.Collections.Generic;

namespace EntityFramework.Web.ViewModels.Archives
{
	public class PostsViewModel
	{
		public int Year { get; set; }

		public int Month { get; set; }

		public string Title { get; set; }

		public IEnumerable<Post> Posts { get; set; }
	}
}