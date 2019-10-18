using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using T1807E_HelloMVC.Models;

namespace T1807E_HelloMVC.Controllers
{
    public class MemberController : Controller
    {
        private List<Member> members = new List<Member>();
        // GET: Member
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(Member member)
        {
            ViewBag.member = member;    
            return View();
        }
    }
}