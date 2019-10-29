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
        private static List<Member> members = new List<Member>();
        private MyDbContext _myDbContext;

        public MemberController()
        {
            _myDbContext = new MyDbContext();
        }

        [HttpGet]
        public ActionResult List()
        {
            return new JsonResult()
            {
                Data = _myDbContext.Members.ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public ActionResult Store(Member member)
        {
            ViewBag.member = member;
            member.Id = DateTime.Now.Millisecond;
            _myDbContext.Members.Add(member);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                Data = member,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPut]
        public ActionResult Update(long id, Member updateMember)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id.Equals(id))
                {
                    members[i] = updateMember;
                }
            }
            return new JsonResult()
            {
                Data = updateMember,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            int removeIndex = -1;
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id.Equals(id))
                {
                    removeIndex = i;
                }
            }
            if (removeIndex != -1)
            {
                members.RemoveAt(removeIndex);
            }
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}