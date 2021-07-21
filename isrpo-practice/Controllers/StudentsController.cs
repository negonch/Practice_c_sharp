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
    public class StudentsController : Controller
    {
        private databaseEntities2 db = new databaseEntities2();

        // GET: Students
        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.Badge).Include(s => s.Contract).Include(s => s.Room);
            return View(student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.id_pass = new SelectList(db.Badge, "Id", "Id");
            ViewBag.id_contract = new SelectList(db.Contract, "Id_contract", "Id_contract");
            ViewBag.id_room = new SelectList(db.Room, "Id_room", "comment");
            return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Student,Family,Name,Othestvo,Address,id_contract,id_pass,id_room")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pass = new SelectList(db.Badge, "Id", "Id", student.id_pass);
            ViewBag.id_contract = new SelectList(db.Contract, "Id_contract", "Id_contract", student.id_contract);
            ViewBag.id_room = new SelectList(db.Room, "Id_room", "comment", student.id_room);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pass = new SelectList(db.Badge, "Id", "Id", student.id_pass);
            ViewBag.id_contract = new SelectList(db.Contract, "Id_contract", "Id_contract", student.id_contract);
            ViewBag.id_room = new SelectList(db.Room, "Id_room", "comment", student.id_room);
            return View(student);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Student,Family,Name,Othestvo,Address,id_contract,id_pass,id_room")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pass = new SelectList(db.Badge, "Id", "Id", student.id_pass);
            ViewBag.id_contract = new SelectList(db.Contract, "Id_contract", "Id_contract", student.id_contract);
            ViewBag.id_room = new SelectList(db.Room, "Id_room", "comment", student.id_room);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
