using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class Goal
	{
		public int GoalId { get; set; }
		public string GoalTitle { get; set; }
		public int UserId { get; set; }
	}

}