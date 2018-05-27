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
    public class DogadjajisController : Controller
    {
        private TravelYourWayContext db = new TravelYourWayContext();

        // GET: Dogadjajis
        public ActionResult Index()
        {
            return View(db.dogadjajis.ToList());
        }

        // GET: Dogadjajis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaji dogadjaji = db.dogadjajis.Find(id);
            if (dogadjaji == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaji);
        }

        // GET: Dogadjajis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogadjajis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Dogadjaji dogadjaji)
        {
            if (ModelState.IsValid)
            {
                db.dogadjajis.Add(dogadjaji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dogadjaji);
        }

        // GET: Dogadjajis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaji dogadjaji = db.dogadjajis.Find(id);
            if (dogadjaji == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaji);
        }

        // POST: Dogadjajis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Dogadjaji dogadjaji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogadjaji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dogadjaji);
        }

        // GET: Dogadjajis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaji dogadjaji = db.dogadjajis.Find(id);
            if (dogadjaji == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaji);
        }

        // POST: Dogadjajis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dogadjaji dogadjaji = db.dogadjajis.Find(id);
            db.dogadjajis.Remove(dogadjaji);
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
