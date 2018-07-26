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
    public class PhasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Home()
        {
            return View();
        }

         // GET: Phases
        public ActionResult Index()
        {
            return View(db.Phases.ToList());  //list the phase
        }

        // GET: Phases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // GET: Phases/Create
         public ActionResult Create()
         {
             return View();
         }

        //Post: Phase
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "Id, PhaseName")] Phase phase)
         {
             if (ModelState.IsValid)
             {
                 db.Phases.Add(phase);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
 
             return View(phase);
        }

         // GET: Admin/Edit/5
       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Phase phase = db.Phases.Find(id);
           if (phase == null)
           {
               return HttpNotFound();
           }
           return View(phase);
        }
       
        //Post: Phase
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "Id,PhaseName")] Phase phase)
       {
           if (ModelState.IsValid)
           {
               db.Entry(phase).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           return View(phase);
       }
        //Get: Phases/Delete
       public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Phase phase = db.Phases.Find(id);
           if (phase == null)
           {
               return HttpNotFound();
           }
           return View(phase);
       }
        //Post delete
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int id)
       {
           Phase phase = db.Phases.Find(id);
           db.Phases.Remove(phase);
           db.SaveChanges();
           return RedirectToAction("Index");
        }
        //disposing data
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
  
    