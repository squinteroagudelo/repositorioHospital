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
    public class seguroesController : Controller
    {
        private bd_hospitalEntities db = new bd_hospitalEntities();

        // GET: seguroes
        public ActionResult Index()
        {
            return View(db.seguro.ToList());
        }

        // GET: seguroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = db.seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // GET: seguroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: seguroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSeguro,nombre")] seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.seguro.Add(seguro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seguro);
        }

        // GET: seguroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = db.seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // POST: seguroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSeguro,nombre")] seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seguro);
        }

        // GET: seguroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seguro seguro = db.seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // POST: seguroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seguro seguro = db.seguro.Find(id);
            db.seguro.Remove(seguro);
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
