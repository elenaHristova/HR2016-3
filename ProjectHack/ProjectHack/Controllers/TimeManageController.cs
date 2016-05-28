using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ProjectHack.Models;


namespace ProjectHack.Controllers
{
	public class TimeManageController : Controller
	{
		public ActionResult Index()
		{
			return View(CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml"),"Categories","Category"));
		}
	}
}