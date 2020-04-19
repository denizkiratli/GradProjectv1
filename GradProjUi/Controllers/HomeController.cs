using GradProjUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradProjUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Results()
        {
            return View();
        }

        public ActionResult EditInfo()
        {
            ViewBag.Message = "Edit your user information.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}