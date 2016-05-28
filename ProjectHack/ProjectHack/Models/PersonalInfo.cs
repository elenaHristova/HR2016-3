using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class PersonalInfo
	{
		public PersonalInfo()
		{
			
		}

		public PersonalInfo(string fullname, int age, string gender, int userId)
		{
			Fullname = fullname;
			Age = age;
			Gender = gender;
			UserId = userId;
		}
		public int PersonalInfoId { get; set; }
		public string Fullname { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public int UserId { get; set; }
	}
}