using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelYourWay.Models;

namespace TravelYourWay.Controllers
{
    public class AgencijasController : Controller
    {
        private TravelYourWayContext db = new TravelYourWayContext();

        // GET: Agencijas
        public ActionResult Index()
        {
            return View(db.agencijas.ToList());
        }

        // GET: Agencijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // GET: Agencijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agencijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Agencija agencija)
        {
            if (ModelState.IsValid)
            {
                db.agencijas.Add(agencija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencija);
        }

        // GET: Agencijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // POST: Agencijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Agencija agencija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencija);
        }

        // GET: Agencijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencija agencija = db.agencijas.Find(id);
            if (agencija == null)
            {
                return HttpNotFound();
            }
            return View(agencija);
        }

        // POST: Agencijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agencija agencija = db.agencijas.Find(id);
            db.agencijas.Remove(agencija);
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
