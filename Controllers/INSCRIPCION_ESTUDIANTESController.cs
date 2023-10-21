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
    public class INSCRIPCION_ESTUDIANTESController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: INSCRIPCION_ESTUDIANTES
        public ActionResult Index()
        {
            var iNSCRIPCION_ESTUDIANTES = db.INSCRIPCION_ESTUDIANTES.Include(i => i.ESTUDIANTE);
            return View(iNSCRIPCION_ESTUDIANTES.ToList());
        }

        // GET: INSCRIPCION_ESTUDIANTES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES = db.INSCRIPCION_ESTUDIANTES.Find(id);
            if (iNSCRIPCION_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            return View(iNSCRIPCION_ESTUDIANTES);
        }

        // GET: INSCRIPCION_ESTUDIANTES/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET");
            return View();
        }

        // POST: INSCRIPCION_ESTUDIANTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_ESTUDIANTE,FECHA_ADICION,ADMISION")] INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES)
        {
            if (ModelState.IsValid)
            {
                db.INSCRIPCION_ESTUDIANTES.Add(iNSCRIPCION_ESTUDIANTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", iNSCRIPCION_ESTUDIANTES.ID);
            return View(iNSCRIPCION_ESTUDIANTES);
        }

        // GET: INSCRIPCION_ESTUDIANTES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES = db.INSCRIPCION_ESTUDIANTES.Find(id);
            if (iNSCRIPCION_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", iNSCRIPCION_ESTUDIANTES.ID);
            return View(iNSCRIPCION_ESTUDIANTES);
        }

        // POST: INSCRIPCION_ESTUDIANTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_ESTUDIANTE,FECHA_ADICION,ADMISION")] INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSCRIPCION_ESTUDIANTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ESTUDIANTE, "ID", "CARNET", iNSCRIPCION_ESTUDIANTES.ID);
            return View(iNSCRIPCION_ESTUDIANTES);
        }

        // GET: INSCRIPCION_ESTUDIANTES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES = db.INSCRIPCION_ESTUDIANTES.Find(id);
            if (iNSCRIPCION_ESTUDIANTES == null)
            {
                return HttpNotFound();
            }
            return View(iNSCRIPCION_ESTUDIANTES);
        }

        // POST: INSCRIPCION_ESTUDIANTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            INSCRIPCION_ESTUDIANTES iNSCRIPCION_ESTUDIANTES = db.INSCRIPCION_ESTUDIANTES.Find(id);
            db.INSCRIPCION_ESTUDIANTES.Remove(iNSCRIPCION_ESTUDIANTES);
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
