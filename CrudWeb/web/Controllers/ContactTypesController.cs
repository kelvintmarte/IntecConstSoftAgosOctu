using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace web.Controllers
{
    public class ContactTypesController : Controller
    {
        private INTEC_AGU_OCT22Entities db = new INTEC_AGU_OCT22Entities();

        // GET: ContactTypes
        public ActionResult Index()
        {
            return View(db.ContactType.ToList());
        }

        // GET: ContactTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contactType = db.ContactType.Find(id);
            if (contactType == null)
            {
                return HttpNotFound();
            }
            return View(contactType);
        }

        // GET: ContactTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ContactType contactType)
        {
            if (ModelState.IsValid)
            {
                db.ContactType.Add(contactType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactType);
        }

        // GET: ContactTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contactType = db.ContactType.Find(id);
            if (contactType == null)
            {
                return HttpNotFound();
            }
            return View(contactType);
        }

        // POST: ContactTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ContactType contactType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactType);
        }

        // GET: ContactTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contactType = db.ContactType.Find(id);
            if (contactType == null)
            {
                return HttpNotFound();
            }
            return View(contactType);
        }

        // POST: ContactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactType contactType = db.ContactType.Find(id);
            db.ContactType.Remove(contactType);
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
