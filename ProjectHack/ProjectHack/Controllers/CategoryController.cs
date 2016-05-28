using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;
using System.IO;

namespace ProjectHack.Controllers
{
    public class CategoryController : Controller
    {
		ProjectHackContext db = new ProjectHackContext();

		public ActionResult Index()
        {
			return View(CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml"),"Categories","Category").Cast<MainCategory>());
        }

	    public ActionResult AddCategory()
	    {
			
		    return View();
	    }

	    public ActionResult AddtoDB(string catId)
	    {
		    //string cn = submit.Substring(4, submit.Length-4);
		    int uid =(int)Session["uid"];
		    User currentUser = db.Users.Where(user => user.UserId == uid).FirstOrDefault();
		    //Category category = db.Categories.Where(cat => cat.Title == cn).FirstOrDefault();
		    string allCategories = currentUser.Categories + "," + catId /*category.CategoryId*/;
            currentUser.Categories=allCategories;
		    db.Users.Attach(currentUser);
		    var entry = db.Entry(currentUser);
		    entry.Property(e => e.Categories).IsModified = true;
		    db.SaveChanges();
		    return View("Index");
	    }
        public ActionResult SaveCategory(string txtTitle,string txtTopic, string txtTopic1, string txtTopic2)
		{
			string username=HttpContext.User.Identity.Name;
			string path=Server.MapPath("~/App_Data/");
			string filePath = Path.Combine(path, username + ".txt");
            string info = String.Format($"{txtTitle}:{txtTopic};{txtTopic1};{txtTopic2}{Environment.NewLine}");
			System.IO.File.AppendAllText(filePath,info);
			
			return RedirectToAction("Index","Account");
		}
	}
}