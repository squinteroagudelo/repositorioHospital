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
    public class medicosController : Controller
    {
        private bd_hospitalEntities db = new bd_hospitalEntities();

        // GET: medicos
        public ActionResult Index()
        {
            var medico = db.medico.Include(m => m.especialidad);
            return View(medico.ToList());
        }

        // GET: medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: medicos/Create
        public ActionResult Create()
        {
            ViewBag.idEspecialidad = new SelectList(db.especialidad, "idEspecialidad", "nombre");
            return View();
        }

        // POST: medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMedico,nombre,apellido,sexo,direccion,telefono,registroMedico,idEspecialidad")] medico medico)
        {
            if (ModelState.IsValid)
            {
                db.medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEspecialidad = new SelectList(db.especialidad, "idEspecialidad", "nombre", medico.idEspecialidad);
            return View(medico);
        }

        // GET: medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEspecialidad = new SelectList(db.especialidad, "idEspecialidad", "nombre", medico.idEspecialidad);
            return View(medico);
        }

        // POST: medicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMedico,nombre,apellido,sexo,direccion,telefono,registroMedico,idEspecialidad")] medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEspecialidad = new SelectList(db.especialidad, "idEspecialidad", "nombre", medico.idEspecialidad);
            return View(medico);
        }

        // GET: medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medico medico = db.medico.Find(id);
            db.medico.Remove(medico);
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
