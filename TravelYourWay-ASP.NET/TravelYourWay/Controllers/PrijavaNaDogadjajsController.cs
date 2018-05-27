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
    public class PrijavaNaDogadjajsController : Controller
    {
        private TravelYourWayContext db = new TravelYourWayContext();

        // GET: PrijavaNaDogadjajs
        public ActionResult Index()
        {
            var prijavaNaDogadjajs = db.PrijavaNaDogadjajs.Include(p => p.dogadjaj);
            return View(prijavaNaDogadjajs.ToList());
        }

        // GET: PrijavaNaDogadjajs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaNaDogadjaj prijavaNaDogadjaj = db.PrijavaNaDogadjajs.Find(id);
            if (prijavaNaDogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(prijavaNaDogadjaj);
        }

        // GET: PrijavaNaDogadjajs/Create
        public ActionResult Create()
        {
            ViewBag.korisnikId = new SelectList(db.korisniks, "id", "ImePrezime");
            return View();
        }

        // POST: PrijavaNaDogadjajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,korisnikId,dogadjajId")] PrijavaNaDogadjaj prijavaNaDogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.PrijavaNaDogadjajs.Add(prijavaNaDogadjaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dogadjajId = new SelectList(db.dogadjajis, "id", "id", prijavaNaDogadjaj.dogadjajId);
            return View(prijavaNaDogadjaj);
        }

        // GET: PrijavaNaDogadjajs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaNaDogadjaj prijavaNaDogadjaj = db.PrijavaNaDogadjajs.Find(id);
            if (prijavaNaDogadjaj == null)
            {
                return HttpNotFound();
            }
            ViewBag.dogadjajId = new SelectList(db.dogadjajis, "id", "id", prijavaNaDogadjaj.dogadjajId);
            return View(prijavaNaDogadjaj);
        }

        // POST: PrijavaNaDogadjajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,korisnikId,dogadjajId")] PrijavaNaDogadjaj prijavaNaDogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijavaNaDogadjaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dogadjajId = new SelectList(db.dogadjajis, "id", "id", prijavaNaDogadjaj.dogadjajId);
            return View(prijavaNaDogadjaj);
        }

        // GET: PrijavaNaDogadjajs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaNaDogadjaj prijavaNaDogadjaj = db.PrijavaNaDogadjajs.Find(id);
            if (prijavaNaDogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(prijavaNaDogadjaj);
        }

        // POST: PrijavaNaDogadjajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrijavaNaDogadjaj prijavaNaDogadjaj = db.PrijavaNaDogadjajs.Find(id);
            db.PrijavaNaDogadjajs.Remove(prijavaNaDogadjaj);
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
