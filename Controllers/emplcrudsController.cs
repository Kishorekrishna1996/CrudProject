using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudemp_project.Models;

namespace crudemp_project.Controllers
{
    public class emplcrudsController : Controller
    {
        private crudemplEntities1 db = new crudemplEntities1();

        // GET: emplcruds
        public ActionResult Index()
        {
            return View(db.emplcruds.ToList());
        }

        // GET: emplcruds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emplcrud emplcrud = db.emplcruds.Find(id);
            if (emplcrud == null)
            {
                return HttpNotFound();
            }
            return View(emplcrud);
        }

        // GET: emplcruds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emplcruds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Address,Age,Designation,Qualification")] emplcrud emplcrud)
        {
            if (ModelState.IsValid)
            {
                db.emplcruds.Add(emplcrud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emplcrud);
        }

        // GET: emplcruds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emplcrud emplcrud = db.emplcruds.Find(id);
            if (emplcrud == null)
            {
                return HttpNotFound();
            }
            return View(emplcrud);
        }

        // POST: emplcruds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Address,Age,Designation,Qualification")] emplcrud emplcrud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplcrud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emplcrud);
        }

        // GET: emplcruds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emplcrud emplcrud = db.emplcruds.Find(id);
            if (emplcrud == null)
            {
                return HttpNotFound();
            }
            return View(emplcrud);
        }

        // POST: emplcruds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emplcrud emplcrud = db.emplcruds.Find(id);
            db.emplcruds.Remove(emplcrud);
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
