using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class Category
	{
		public Category()
		{
			
		}

		public Category(string title)
		{
			Title = title;
		}
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public int TimePeriodInDays { get; set; }
	}
}