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
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Home()
        {
            return View();
        }

        // GET: Movies
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.SortTitle = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "Title";
            ViewBag.SortRating = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewBag.SortBoxOffice = sortOrder == "Box Office" ? "boxoffice_desc" : "Box Office";

            var movies = from m in db.Movies.Include(m => m.Phase) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Title":
                    movies = movies.OrderBy(m => m.Title);
                    break;
                case "title_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                case "Box Office":
                    movies = movies.OrderBy(m => m.BoxOffice);
                    break;
                case "boxoffice_desc":
                    movies = movies.OrderByDescending(m => m.BoxOffice);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Id);
                    break;
            }

            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,CollectionNumber,Description,PhaseId,Rating,BoxOffice")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", movie.PhaseId);

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", movie.PhaseId);

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CollectionNumber,Description,PhaseId,Rating,BoxOffice")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhaseId = new SelectList(db.Phases, "Id", "PhaseName", movie.PhaseId);

            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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

        public ActionResult SortPhase(int phaseThreshold)
        {
            var movies = db.Movies.Where(m => m.PhaseId == phaseThreshold).ToList();

            return View(movies);
        }

    }
}
