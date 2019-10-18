using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T1807E_HelloMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(string username, string fullname, string email )
        {
            ViewBag.username = username;
            ViewBag.fullname = fullname;
            ViewBag.email = email;
            return View();
        }
    }
}