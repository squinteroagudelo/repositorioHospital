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
    public class pacientesController : Controller
    {
        private bd_hospitalEntities db = new bd_hospitalEntities();

        // GET: pacientes
        public ActionResult Index()
        {
            var paciente = db.paciente.Include(p => p.seguro).Include(p => p.tipoSeguro);
            return View(paciente.ToList());
        }

        // GET: pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: pacientes/Create
        public ActionResult Create()
        {
            ViewBag.idSeguro = new SelectList(db.seguro, "idSeguro", "nombre");
            ViewBag.idTipo = new SelectList(db.tipoSeguro, "idTipoSeguro", "tipo");
            return View();
        }

        // POST: pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaciente,nombre,apellido,sexo,direccion,telefono,fechaNacimiento,idSeguro,idTipo")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSeguro = new SelectList(db.seguro, "idSeguro", "nombre", paciente.idSeguro);
            ViewBag.idTipo = new SelectList(db.tipoSeguro, "idTipoSeguro", "tipo", paciente.idTipo);
            return View(paciente);
        }

        // GET: pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSeguro = new SelectList(db.seguro, "idSeguro", "nombre", paciente.idSeguro);
            ViewBag.idTipo = new SelectList(db.tipoSeguro, "idTipoSeguro", "tipo", paciente.idTipo);
            return View(paciente);
        }

        // POST: pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaciente,nombre,apellido,sexo,direccion,telefono,fechaNacimiento,idSeguro,idTipo")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSeguro = new SelectList(db.seguro, "idSeguro", "nombre", paciente.idSeguro);
            ViewBag.idTipo = new SelectList(db.tipoSeguro, "idTipoSeguro", "tipo", paciente.idTipo);
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paciente paciente = db.paciente.Find(id);
            db.paciente.Remove(paciente);
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
