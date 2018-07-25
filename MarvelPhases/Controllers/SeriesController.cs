using MarvelPhases.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MarvelPhases.Controllers
{
    public class SeriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Home()
        {
            return View();
        } 

        // GET: Series
        public ActionResult Index()
        {
            return View();
        }

        // GET: Series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Series series = db.Series.Find(id);

            if (series == null)
            {
                return HttpNotFound();
            }

            return View(series);
        }


        // GET: Series/Create
        public ActionResult Create()
        {
            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName");
            return View();
        }

        // POST: Series/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,SeriesNumber,ReleaseDate,Description,PhaseId,Rating,TvService")] Series series)
        {
            if (ModelState.IsValid)
            {
                db.Series.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", series.PhaseId);

            return View(series);
        }


        // GET: Series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.Series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", series.PhaseId);

            return View(series);
        }

        // POST: Series/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,SeriesNumber,ReleaseDate,Description,PhaseId,Rating,TvService")] Series series)
        {
            if (ModelState.IsValid)
            {
                db.Entry(series).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", series.PhaseId);

            return View(series);
        }

        // GET: Series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.Series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Series series = db.Series.Find(id);
            db.Series.Remove(series);
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
