using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProFinalEstudiantes.Models;

namespace ProFinalEstudiantes.Controllers
{
    public class COLA_ESTUDIANTESController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: COLA_ESTUDIANTES
        public ActionResult Index()
        {
            var cOLA_ESTUDIANTES = db.COLA_ESTUDIANTES.Include(c => c.ESTUDIANTE);
            return View(cOLA_ESTUDIANTES.ToList());
        }

        // GET: COLA_ESTUDIANTES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLA_ESTUDIANTES cOLA_ESTUDIANTES = db.COLA_ESTUDIANTES.Find(id);
            if (cOLA_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            return View(cOLA_ESTUDIANTES);
        }

        // GET: COLA_ESTUDIANTES/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET");
            return View();
        }

        // POST: COLA_ESTUDIANTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_ESTUDIANTE,FECHA_ADICION")] COLA_ESTUDIANTES cOLA_ESTUDIANTES)
        {
            if (ModelState.IsValid)
            {
                db.COLA_ESTUDIANTES.Add(cOLA_ESTUDIANTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", cOLA_ESTUDIANTES.ID);
            return View(cOLA_ESTUDIANTES);
        }

        // GET: COLA_ESTUDIANTES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLA_ESTUDIANTES cOLA_ESTUDIANTES = db.COLA_ESTUDIANTES.Find(id);
            if (cOLA_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", cOLA_ESTUDIANTES.ID);
            return View(cOLA_ESTUDIANTES);
        }

        // POST: COLA_ESTUDIANTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_ESTUDIANTE,FECHA_ADICION")] COLA_ESTUDIANTES cOLA_ESTUDIANTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLA_ESTUDIANTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", cOLA_ESTUDIANTES.ID);
            return View(cOLA_ESTUDIANTES);
        }

        // GET: COLA_ESTUDIANTES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLA_ESTUDIANTES cOLA_ESTUDIANTES = db.COLA_ESTUDIANTES.Find(id);
            if (cOLA_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            return View(cOLA_ESTUDIANTES);
        }

        // POST: COLA_ESTUDIANTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            COLA_ESTUDIANTES cOLA_ESTUDIANTES = db.COLA_ESTUDIANTES.Find(id);
            db.COLA_ESTUDIANTES.Remove(cOLA_ESTUDIANTES);
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
