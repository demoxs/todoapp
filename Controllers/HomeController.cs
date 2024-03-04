using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using todoapp.Models;

namespace todoapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            login log=new login();
            List<SelectListItem> sl = new List<SelectListItem>();
            sl.Add(new SelectListItem { Text = "admin1", Value = "1" });
            sl.Add(new SelectListItem { Text = "operator", Value = "2" });
            sl.Add(new SelectListItem { Text = "clerk", Value = "3" });
            sl.Add(new SelectListItem { Text = "Peon", Value = "4" });
            log.role = sl;
            return View(log);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(login log)
        {
            if (ModelState.IsValid)
            {
                //   ViewBag.Message = "Your application description page.";
                FormsAuthentication.SetAuthCookie(log.username, true);
                return RedirectToAction("index", "Tbl_todo");
            }

            
            List<SelectListItem> sl = new List<SelectListItem>();
            sl.Add(new SelectListItem { Text = "admin1", Value = "1" });
            sl.Add(new SelectListItem { Text = "operator", Value = "2" });
            sl.Add(new SelectListItem { Text = "clerk", Value = "3" });
            sl.Add(new SelectListItem { Text = "Peon", Value = "4" });
            log.role = sl;
            return View(log);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}