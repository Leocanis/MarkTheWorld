using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarkTheWorld.Models;
using MarkTheWorld.Context;

namespace MarkTheWorld.Controllers
{
    public class DotController : Controller
    {
        private DotContext db = new DotContext();

        // GET: /Dot/
        public ActionResult Index()
        {
            return View(db.Dots.ToList());
        }

        // GET: /Dot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = db.Dots.Find(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // GET: /Dot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Dot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,x,y")] Dot dot)
        {
            if (ModelState.IsValid)
            {
                db.Dots.Add(dot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dot);
        }

        // GET: /Dot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = db.Dots.Find(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // POST: /Dot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,x,y")] Dot dot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dot);
        }

        // GET: /Dot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dot dot = db.Dots.Find(id);
            if (dot == null)
            {
                return HttpNotFound();
            }
            return View(dot);
        }

        // POST: /Dot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dot dot = db.Dots.Find(id);
            db.Dots.Remove(dot);
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
