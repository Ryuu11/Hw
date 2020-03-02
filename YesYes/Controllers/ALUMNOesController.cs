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
    public class ALUMNOesController : Controller
    {
        private universityEntities db = new universityEntities();

        // GET: ALUMNOes
        public ActionResult Index()
        {
            return View(db.ALUMNOes.ToList());
        }

        // GET: ALUMNOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNOes.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // GET: ALUMNOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALUMNOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "boleta,nombre,CURP,fechaNac")] ALUMNO aLUMNO)
        {
            if (ModelState.IsValid)
            {
                db.ALUMNOes.Add(aLUMNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLUMNO);
        }

        // GET: ALUMNOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNOes.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // POST: ALUMNOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "boleta,nombre,CURP,fechaNac")] ALUMNO aLUMNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUMNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLUMNO);
        }

        // GET: ALUMNOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNOes.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // POST: ALUMNOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ALUMNO aLUMNO = db.ALUMNOes.Find(id);
            db.ALUMNOes.Remove(aLUMNO);
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
