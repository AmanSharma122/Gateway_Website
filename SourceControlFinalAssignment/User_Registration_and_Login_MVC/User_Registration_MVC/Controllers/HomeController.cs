using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_Registration_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            UsersEntities usersEntities = new UsersEntities();
            usersEntities.Users.Add(user);
            usersEntities.SaveChanges();
            string message = string.Empty;
            switch (user.UserId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user.UserId.ToString();
                    break;
            }
            ViewBag.Message = message;

            return View(user);
        }
    }
}