using GradProjUi.Models;
using DataLibrary;
using DataLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                var data = DBBridge.LoginUser(model.EMail, model.Password);
                if (data.Count != 0)
                {
                    int timeout = model.RememberMe ? 43200 : 15; //43200s = 1 month
                    var ticket = new FormsAuthenticationTicket(model.EMail, model.RememberMe, timeout);
                    string encryptticket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptticket);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Cannot login.";
                    return View(model);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Login", "Login");
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
                var data = DBBridge.SearchUser(model.MailAddress);
                if(data.Count == 0)
                {
                    DBBridge.CreateUser(model.UserId, model.FirstName, model.LastName, model.MailAddress, model.Password);
                    ViewBag.Message = "Your account is created successfully.";
                }
                else
                {
                    ModelState.AddModelError("EmailExist", "The typed e-mail is exist.");
                    return View(model);
                }
            }
            else
            {
                ViewBag.Message = "Invalid input(s).";
                return View(model);
            }
            
            return View();
        }
    }
}