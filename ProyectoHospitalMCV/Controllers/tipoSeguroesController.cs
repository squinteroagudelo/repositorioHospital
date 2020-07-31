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
    public class tipoSeguroesController : Controller
    {
        private bd_hospitalEntities db = new bd_hospitalEntities();

        // GET: tipoSeguroes
        public ActionResult Index()
        {
            return View(db.tipoSeguro.ToList());
        }

        // GET: tipoSeguroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoSeguro tipoSeguro = db.tipoSeguro.Find(id);
            if (tipoSeguro == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeguro);
        }

        // GET: tipoSeguroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoSeguroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoSeguro,tipo")] tipoSeguro tipoSeguro)
        {
            if (ModelState.IsValid)
            {
                db.tipoSeguro.Add(tipoSeguro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSeguro);
        }

        // GET: tipoSeguroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoSeguro tipoSeguro = db.tipoSeguro.Find(id);
            if (tipoSeguro == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeguro);
        }

        // POST: tipoSeguroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoSeguro,tipo")] tipoSeguro tipoSeguro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSeguro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSeguro);
        }

        // GET: tipoSeguroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoSeguro tipoSeguro = db.tipoSeguro.Find(id);
            if (tipoSeguro == null)
            {
                return HttpNotFound();
            }
            return View(tipoSeguro);
        }

        // POST: tipoSeguroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoSeguro tipoSeguro = db.tipoSeguro.Find(id);
            db.tipoSeguro.Remove(tipoSeguro);
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
