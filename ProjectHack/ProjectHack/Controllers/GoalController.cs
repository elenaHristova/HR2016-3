using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHack.Controllers
{
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult SetGoal()
		{
			return View();
		}

	    public ActionResult MyGoals()
	    {
		    return View();
	    }
	}
}