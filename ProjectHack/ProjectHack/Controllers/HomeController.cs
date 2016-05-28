using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;
using System.Web.Security;
using System.Security.Principal;

namespace ProjectHack.Controllers
{
	public class HomeController : Controller
	{
		public ProjectHackContext db=new ProjectHackContext();
		public ActionResult Index()
		{
            bool IsAuthenticated = false;
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated == false) ;
            }
            catch
            {
                IsAuthenticated = false;
            }
			ViewBag.Id = Session["uid"];
			return View(HttpContext.User.Identity.IsAuthenticated);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		[HttpPost]
		public ActionResult Login(string txtUsername, string txtPassword)
		{
            bool flag = false;
            int uid = 0;
            User currentUser = null;

            foreach (User user in db.Users)
            {
                if (user.Username == txtUsername && user.Password == txtPassword)
                {
                    flag = true;
                    uid = user.UserId;
                    currentUser = user;
                    break;
                }
            }
            if (flag)
            {
				FormsAuthentication.SetAuthCookie(currentUser.Username, false);
	            Session["uid"] = uid;
				return RedirectToAction("Index", "Account");
            }
            return Index();
		}

		[HttpPost]
		public ActionResult Register(string txtEmail, string txtUsernameRegister, string txtPasswordRegister)
		{
			bool userExists = false;

			foreach (User user in db.Users)
			{
				if (user.Username == txtUsernameRegister)
				{
					userExists = true;

				}
			}
			if (userExists==false)
			{
				User newUser = new User { Username = txtUsernameRegister, Email = txtEmail, Password = txtPasswordRegister };
				db.Users.Add(newUser);
				db.SaveChanges();
				FormsAuthentication.SetAuthCookie(newUser.Username,true);
				Session["uid"] = newUser.UserId;
				return RedirectToAction("NewUser", "Account");
				//here we will show them the additional info we want
			}
			return RedirectToAction("Index");
		}
	}
}