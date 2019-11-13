using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1807E_HelloMVC.Models;

namespace T1807E_HelloMVC.Controllers
{
    public class ClassObjectsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ClassObjects
        public ActionResult Index()
        {
            return View(db.ClassObjects.ToList());
        }

        // GET: ClassObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassObject classObject = db.ClassObjects.Find(id);
            if (classObject == null)
            {
                return HttpNotFound();
            }
            return View(classObject);
        }

        // GET: ClassObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] ClassObject classObject)
        {
            if (ModelState.IsValid)
            {
                db.ClassObjects.Add(classObject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classObject);
        }

        // GET: ClassObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassObject classObject = db.ClassObjects.Find(id);
            if (classObject == null)
            {
                return HttpNotFound();
            }
            return View(classObject);
        }

        // POST: ClassObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] ClassObject classObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classObject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classObject);
        }

        // GET: ClassObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassObject classObject = db.ClassObjects.Find(id);
            if (classObject == null)
            {
                return HttpNotFound();
            }
            return View(classObject);
        }

        // POST: ClassObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassObject classObject = db.ClassObjects.Find(id);
            db.ClassObjects.Remove(classObject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
