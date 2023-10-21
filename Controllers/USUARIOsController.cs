using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProFinalEstudiantes.Models;

namespace ProFinalEstudiantes.Controllers
{
    public class USUARIOsController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: USUARIOs
        public ActionResult Index()
        {
            return View(db.USUARIO.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USUARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USUARIO1,CONTRASEÑA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USUARIO1,CONTRASEÑA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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


        // GET: USUARIOs/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]  // Asegúrate de incluir la validación antifalsificación
        public ActionResult Login(string USUARIO1, string CONTRASEÑA)
        {
            var user = db.USUARIO.SingleOrDefault(u => u.USUARIO1 == USUARIO1 && u.CONTRASEÑA == CONTRASEÑA);
            if (user != null)
            {
                // Las credenciales son correctas, inicia la sesión.
                AuthManager.Login(user.ID.ToString(), this.HttpContext);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Las credenciales incorrectas
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
               
                return View();
            }
        }


        //logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();  // limpiar las variables de sesión.
            return RedirectToAction("Login", "USUARIOs");
        }


    }
}
