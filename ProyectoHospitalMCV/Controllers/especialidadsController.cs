using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoHospitalMCV.Models;

namespace ProyectoHospitalMCV.Controllers
{
    public class especialidadsController : Controller
    {
        private bd_hospitalEntities db = new bd_hospitalEntities();

        // GET: especialidads
        public ActionResult Index()
        {
            return View(db.especialidad.ToList());
        }

        // GET: especialidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad especialidad = db.especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // GET: especialidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: especialidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEspecialidad,nombre,descripcion")] especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.especialidad.Add(especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: especialidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad especialidad = db.especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: especialidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEspecialidad,nombre,descripcion")] especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: especialidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad especialidad = db.especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: especialidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            especialidad especialidad = db.especialidad.Find(id);
            db.especialidad.Remove(especialidad);
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
