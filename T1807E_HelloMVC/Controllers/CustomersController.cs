using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinqKit;
using Microsoft.Ajax.Utilities;
using T1807E_HelloMVC.Models;

namespace T1807E_HelloMVC.Controllers
{
    public class CustomersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        private List<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
                FullName = "Xuan Hung",
                Age = 20,
                Email = "hung@gmail.com",
                Phone = "0912345678"
            },
            new Customer()
            {
                FullName = "Hong Luyen",
                Age = 10,
                Email = "luyen@gmail.com",
                Phone = "0912122233"
            },
        };

        // GET: Customers
        public ActionResult Index(String keyword, int? age)
        {
            var predicate = PredicateBuilder.New<Customer>(true);
            if (!keyword.IsNullOrWhiteSpace())
            {
                Debug.WriteLine("keyword is okie");
                predicate = predicate.Or(f => f.FullName.Contains(keyword));
                predicate = predicate.Or(f => f.Phone.Contains(keyword));
                predicate = predicate.Or(f => f.Email.Contains(keyword));
                ViewBag.Keyword = keyword;
            }

            if (age > 0)
            {
                Debug.WriteLine("age is okie.");
                predicate = predicate.Or(f => f.Age >= age);
                ViewBag.Age = age;
            }

            var data = db.Customers.AsExpandable().Where(predicate).OrderByDescending(c => c.Age);
            return View(data);
        }
        // GET: Customers
        public ActionResult GetListAjax(String keyword, int? age)
        {
            var predicate = PredicateBuilder.New<Customer>(true);
            if (!keyword.IsNullOrWhiteSpace())
            {
                Debug.WriteLine("keyword is okie");
                predicate = predicate.Or(f => f.FullName.Contains(keyword));
                predicate = predicate.Or(f => f.Phone.Contains(keyword));
                predicate = predicate.Or(f => f.Email.Contains(keyword));
                ViewBag.Keyword = keyword;
            }

            if (age > 0)
            {
                Debug.WriteLine("age is okie.");
                predicate = predicate.Or(f => f.Age >= age);
                ViewBag.Age = age;
            }

            var data = db.Customers.AsExpandable().Where(predicate).OrderByDescending(c => c.Age);
            return View("_ListCustomer", data);
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Phone,Password,ConfirmPassword,Age")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Phone,Password,ConfirmPassword,Age")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
