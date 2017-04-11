using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityFramework.Web.Areas.Admin.ViewModels.Posts
{
	public class EditViewModel
	{
		[Required]
		[Key]
		public Guid Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Content { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Date { get; set; }
	}
}