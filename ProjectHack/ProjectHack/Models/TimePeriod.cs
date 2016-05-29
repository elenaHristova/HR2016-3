using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class TimePeriod
	{
		public TimePeriod() { }
		public int TimePeriodId { get; set; }
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
		public string TitleId { get; set; }
		public int UserId { get; set; }
		
	}
}