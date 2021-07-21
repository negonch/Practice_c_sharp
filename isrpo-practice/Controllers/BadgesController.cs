using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using isrpo_practice;

namespace isrpo_practice.Controllers
{
    public class BadgesController : Controller
    {
        private databaseEntities2 db = new databaseEntities2();

        // GET: Badges
        public ActionResult Index()
        {
            return View(db.Badge.ToList());
        }

        // GET: Badges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badge.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // GET: Badges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Badges/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,date")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                db.Badge.Add(badge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(badge);
        }

        // GET: Badges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badge.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badges/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,date")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(badge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(badge);
        }

        // GET: Badges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Badge badge = db.Badge.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Badge badge = db.Badge.Find(id);
            db.Badge.Remove(badge);
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
