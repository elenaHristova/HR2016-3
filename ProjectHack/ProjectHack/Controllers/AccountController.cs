using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectHack.Models;

namespace ProjectHack.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        ProjectHackContext db = new ProjectHackContext();

        public ActionResult Index()
        {
            ViewBag.Title = "My profile";
            ViewBag.Id = Session["uid"];
            int uid = (int)Session["uid"];
            User currentUser = db.Users.Where(user => user.UserId == uid).FirstOrDefault();
            List<string> categories = currentUser.Categories?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //List<int> categoriesId = new List<int>();
            List<string> catTitles = new List<string>();
            if (categories == null)
            {
                ViewBag.ActivityTitles = new List<string>();
                return View(catTitles);
            }
            var categoriesXml = CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml"), "Categories", "Category").Cast<MainCategory>();
            //for (int i = 0; i<categories.Count; i++)
            //      {
            //       categoriesId.Add(Convert.ToInt32(categories[i]));
            //      }
            //categories.Clear();
            foreach (var dbCats in categories)
            {
                foreach (var category in categoriesXml.Select(c => c.Elements).SelectMany(i => i))
                {
                    if (dbCats == category.Id) catTitles.Add(category.Title);
                }
                //var categoryId = db.Categories.Where(cat => cat.CategoryId == categoryId).FirstOrDefault();
            }

			List<string> activities = currentUser.Activities?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			//List<int> categoriesId = new List<int>();
			List<string> actTitles = new List<string>();
	        if (activities==null)
	        {
				ViewBag.ActivityTitles = actTitles;
				return View(catTitles);
	        }
			var activitiesXml = CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Activities.xml"), "Activities", "Activity").Cast<MainCategory>();
			//for (int i = 0; i<categories.Count; i++)
			//      {
			//       categoriesId.Add(Convert.ToInt32(categories[i]));
			//      }
			//categories.Clear();
			foreach (var activity in activitiesXml.Select(c => c.Elements).SelectMany(i => i))
			{
				foreach (var dbActs in activities)
				{
					if (dbActs == activity.Id) catTitles.Add(activity.Title);
				}
				//var categoryId = db.Categories.Where(cat => cat.CategoryId == categoryId).FirstOrDefault();
			}
	        string fact = GenerateRandomLineFromFile("interestingFacts.txt");
	        string quote = GenerateRandomLineFromFile("motivationalQuotes.txt");
	        ViewBag.Fact = fact;
	        ViewBag.Quote = quote;
			ViewBag.ActivityTitles = actTitles;
			return View(catTitles);
        }

	    private string GenerateRandomLineFromFile(string fileName)
	    {
			string path = Server.MapPath("~/App_Data/"+fileName);
			var lines = System.IO.File.ReadAllLines(path);
			var r = new Random();
			var randomLineNumber = r.Next(0, lines.Length - 1);
			var line = lines[randomLineNumber];
			return line;
		}

	    public ActionResult NewUser()
	    {
			return View();
	    }

        [HttpPost]
        public ActionResult SaveNewUser(string txtFullname, string txtAge, string gender)
        {
            int age = int.Parse(txtAge);
            int uid = (int)Session["uid"];
            PersonalInfo pi = new PersonalInfo(txtFullname, age, gender, uid);
            db.PersonalInfos.Add(pi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}