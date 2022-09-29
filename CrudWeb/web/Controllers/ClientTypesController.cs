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
    public class ClientTypesController : Controller
    {
        private INTEC_AGU_OCT22Entities db = new INTEC_AGU_OCT22Entities();

        // GET: ClientTypes
        public ActionResult Index()
        {
            return View(db.ClientType.ToList());
        }

        // GET: ClientTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientType clientType = db.ClientType.Find(id);
            if (clientType == null)
            {
                return HttpNotFound();
            }
            return View(clientType);
        }

        // GET: ClientTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ClientType clientType)
        {
            if (ModelState.IsValid)
            {
                db.ClientType.Add(clientType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientType);
        }

        // GET: ClientTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientType clientType = db.ClientType.Find(id);
            if (clientType == null)
            {
                return HttpNotFound();
            }
            return View(clientType);
        }

        // POST: ClientTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ClientType clientType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientType);
        }

        // GET: ClientTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientType clientType = db.ClientType.Find(id);
            if (clientType == null)
            {
                return HttpNotFound();
            }
            return View(clientType);
        }

        // POST: ClientTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientType clientType = db.ClientType.Find(id);
            db.ClientType.Remove(clientType);
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
