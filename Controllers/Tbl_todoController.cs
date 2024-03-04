using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using todoapp.Models;

namespace todoapp.Controllers
{
    //[RoutePrefix("jpsoft")]
    public class Tbl_todoController : Controller
    {
        private todoEntities db = new todoEntities();
        [Authorize]
        // GET: Tbl_todo
        [Route("test")]
        public ActionResult Index()
        {
            return View(db.Tbl_todo.ToList());
        }

        // GET: Tbl_todo/Details/5
      [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_todo tbl_todo = db.Tbl_todo.Find(id);
            if (tbl_todo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_todo);
        }

        // GET: Tbl_todo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Tbl_todo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tittle,description,ISACTIVE")] Tbl_todo tbl_todo)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_todo.Add(tbl_todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_todo);
        }
        [Authorize]
        // GET: Tbl_todo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_todo tbl_todo = db.Tbl_todo.Find(id);
            if (tbl_todo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_todo);
        }
        [Authorize]
        // POST: Tbl_todo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tittle,description,ISACTIVE")] Tbl_todo tbl_todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_todo);
        }
        [Authorize]
        // GET: Tbl_todo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_todo tbl_todo = db.Tbl_todo.Find(id);
            if (tbl_todo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_todo);
        }
        [Authorize]
        // POST: Tbl_todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_todo tbl_todo = db.Tbl_todo.Find(id);
            db.Tbl_todo.Remove(tbl_todo);
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
