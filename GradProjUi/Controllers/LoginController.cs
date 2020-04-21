using GradProjUi.Models;
using DataLibrary;
using DataLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradProjUi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //DBBridge.SearchUser(model.EMail, model.Password);
                
                if(DBBridge.SearchUser(model.EMail, model.Password) != 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        // GET: Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // POST: Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserModel model)
        {
            if(ModelState.IsValid)
            {
                DBBridge.CreateUser(model.UserId, model.FirstName, model.LastName, model.MailAddress, model.Password);
                ViewBag.Message = "Registration successful.";
            }
            
            return View();
        }
    }
}