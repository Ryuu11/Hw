using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YesYes.Models;

namespace YesYes.Controllers
{
    public class MaestriasController : Controller
    {
        private universityEntities db = new universityEntities();

        // GET: Maestrias
        public ActionResult Index()
        {
            return View(db.Maestrias.ToList());
        }

        // GET: Maestrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestria maestria = db.Maestrias.Find(id);
            if (maestria == null)
            {
                return HttpNotFound();
            }
            return View(maestria);
        }

        // GET: Maestrias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maestrias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDmaestria,nombre,duracion")] Maestria maestria)
        {
            if (ModelState.IsValid)
            {
                db.Maestrias.Add(maestria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maestria);
        }

        // GET: Maestrias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestria maestria = db.Maestrias.Find(id);
            if (maestria == null)
            {
                return HttpNotFound();
            }
            return View(maestria);
        }

        // POST: Maestrias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDmaestria,nombre,duracion")] Maestria maestria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maestria);
        }

        // GET: Maestrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestria maestria = db.Maestrias.Find(id);
            if (maestria == null)
            {
                return HttpNotFound();
            }
            return View(maestria);
        }

        // POST: Maestrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maestria maestria = db.Maestrias.Find(id);
            db.Maestrias.Remove(maestria);
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
