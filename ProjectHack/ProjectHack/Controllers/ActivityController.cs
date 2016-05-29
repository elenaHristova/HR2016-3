using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;

namespace ProjectHack.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
		ProjectHackContext db = new ProjectHackContext();

		public ActionResult Index()
		{
			return View(CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Activities.xml"),"Activities","Activity").Cast<MainCategory>());
		}

		public ActionResult AddActivity()
		{
			return View();
		}

	    public ActionResult AddActivityToDB(string actId)
	    {
		    //string cn = submit.Substring(4, submit.Length-4);
			int uid = (int)Session["uid"];
			User currentUser = db.Users.Where(user => user.UserId == uid).FirstOrDefault();
			//Category category = db.Categories.Where(cat => cat.Title == cn).FirstOrDefault();
			string allActivities = currentUser.Activities + "," + actId;
			currentUser.Activities = allActivities;
			db.Users.Attach(currentUser);
			var entry = db.Entry(currentUser);
			entry.Property(e => e.Activities).IsModified = true;
			db.SaveChanges();
			return RedirectToAction("Index","Account");
		}
		public ActionResult SaveActivity(string txtTitle, string txtTopic, string txtTopic1, string txtTopic2)
		{
			string username = HttpContext.User.Identity.Name;
			string path = Server.MapPath("~/App_Data/");
			string filePath = Path.Combine(path, username + "Activities.txt");
			string info = String.Format($"{txtTitle}:{txtTopic};{txtTopic1};{txtTopic2}{Environment.NewLine}");
			System.IO.File.AppendAllText(filePath, info);

			return RedirectToAction("Index", "Account");
		}
	}
}