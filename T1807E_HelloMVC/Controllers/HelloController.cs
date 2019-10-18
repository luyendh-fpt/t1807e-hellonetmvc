using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T1807E_HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Hallo()
        {
            return View();
        }

        public ActionResult HelloWorld(string id)
        {
            Debug.WriteLine("Hello " + id);
            ViewBag.Name = id;
            return View();
        }

    }
}