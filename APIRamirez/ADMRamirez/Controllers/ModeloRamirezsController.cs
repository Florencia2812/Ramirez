using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADMRamirez.Models;

namespace ADMRamirez.Controllers
{
    public class ModeloRamirezsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ModeloRamirezs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ModeloRamirezs.ToList());
        }

        // GET: ModeloRamirezs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloRamirez modeloRamirez = db.ModeloRamirezs.Find(id);
            if (modeloRamirez == null)
            {
                return HttpNotFound();
            }
            return View(modeloRamirez);
        }

        // GET: ModeloRamirezs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloRamirezs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RamirezID,FriendofRamirez,Place,Email,Birthdate")] ModeloRamirez modeloRamirez)
        {
            if (ModelState.IsValid)
            {
                db.ModeloRamirezs.Add(modeloRamirez);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modeloRamirez);
        }

        // GET: ModeloRamirezs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloRamirez modeloRamirez = db.ModeloRamirezs.Find(id);
            if (modeloRamirez == null)
            {
                return HttpNotFound();
            }
            return View(modeloRamirez);
        }

        // POST: ModeloRamirezs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RamirezID,FriendofRamirez,Place,Email,Birthdate")] ModeloRamirez modeloRamirez)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloRamirez).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modeloRamirez);
        }

        // GET: ModeloRamirezs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloRamirez modeloRamirez = db.ModeloRamirezs.Find(id);
            if (modeloRamirez == null)
            {
                return HttpNotFound();
            }
            return View(modeloRamirez);
        }

        // POST: ModeloRamirezs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloRamirez modeloRamirez = db.ModeloRamirezs.Find(id);
            db.ModeloRamirezs.Remove(modeloRamirez);
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
