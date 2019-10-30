using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using T1807E_HelloMVC.Models;

namespace T1807E_HelloMVC.Controllers
{
    public class MemberController : Controller
    {
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
                Data = _myDbContext.Members.Where(member => member.Status != (int)Member.MemberStatus.Deleted),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public ActionResult Store(Member member)
        {
            ViewBag.member = member;
            member.Id = DateTime.Now.Millisecond;
            member.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            member.Status = (int) Member.MemberStatus.Active;
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
            Member existMember = _myDbContext.Members.Find(id);
            if (existMember == null)
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                return Json(new { success = false, message = "Member is not found" }, JsonRequestBehavior.AllowGet);

            }
            existMember.Email = updateMember.Email;
            existMember.Password = updateMember.Password;
            existMember.UpdatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _myDbContext.Members.AddOrUpdate(existMember);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                Data = existMember,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            Member existMember = _myDbContext.Members.Find(id);
            if (existMember == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { success = false, message = "Member is not found" }, JsonRequestBehavior.AllowGet);

            }
            existMember.DeletedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            existMember.Status = (int) Member.MemberStatus.Deleted;
            _myDbContext.Members.AddOrUpdate(existMember);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}