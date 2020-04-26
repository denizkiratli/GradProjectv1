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
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Upload your files.";

            return View();
        }

        public ActionResult Results()
        {
            ViewBag.Message = "View the past results.";

            var data = DBBridge.LoadResults();
            List<ResultModel> Results = new List<ResultModel>();

            foreach (var row in data)
            {
                Results.Add(new ResultModel
                {
                    ResultId = row.ResultId,
                    AssignmentName = row.AssignmentName,
                    Score = row.Score,
                    NumberofAttendance = row.TotalAssignmentNumber
                });
            }

            return View(Results);
        }

        public ActionResult ViewUsers()
        {
            ViewBag.Message = "View the registered users.";

            var data = DBBridge.LoadUsers();
            List<UserModel> Users = new List<UserModel>();

            foreach (var row in data)
            {
                Users.Add(new UserModel
                {
                    UserId = row.UserId,
                    FirstName = row.UserFirstName,
                    LastName = row.UserLastName,
                    MailAddress = row.UserMail
                });
            }

            return View(Users);
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