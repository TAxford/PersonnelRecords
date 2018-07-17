using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonnelRecord.Models;

namespace PersonnelRecord.Controllers
{
    public class Personnel_InformationController : Controller
    {
        private PersonnelEntities db = new PersonnelEntities();

        // GET: Personnel_Information
        public ActionResult Index()
        {
            return View(db.Personnel_Information.ToList());
        }

        // GET: Personnel_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel_Information personnel_Information = db.Personnel_Information.Find(id);
            if (personnel_Information == null)
            {
                return HttpNotFound();
            }
            return View(personnel_Information);
        }

        // GET: Personnel_Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personnel_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonnelID,FirstName,LastName,Age,PhoneNumber")] Personnel_Information personnel_Information)
        {
            if (ModelState.IsValid)
            {
                db.Personnel_Information.Add(personnel_Information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personnel_Information);
        }

        // GET: Personnel_Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel_Information personnel_Information = db.Personnel_Information.Find(id);
            if (personnel_Information == null)
            {
                return HttpNotFound();
            }
            return View(personnel_Information);
        }

        // POST: Personnel_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonnelID,FirstName,LastName,Age,PhoneNumber")] Personnel_Information personnel_Information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnel_Information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personnel_Information);
        }

        // GET: Personnel_Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel_Information personnel_Information = db.Personnel_Information.Find(id);
            if (personnel_Information == null)
            {
                return HttpNotFound();
            }
            return View(personnel_Information);
        }

        // POST: Personnel_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personnel_Information personnel_Information = db.Personnel_Information.Find(id);
            db.Personnel_Information.Remove(personnel_Information);
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
