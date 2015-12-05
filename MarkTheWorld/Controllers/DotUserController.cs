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
    public class DotUserController : Controller
    {
        private DotUserContext db = new DotUserContext();

        // GET: /DotUser/
        public ActionResult Index()
        {
            return View(db.DotUsers.ToList());
        }

        // GET: /DotUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotUser dotuser = db.DotUsers.Find(id);
            if (dotuser == null)
            {
                return HttpNotFound();
            }
            return View(dotuser);
        }

        // GET: /DotUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DotUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,userID,dotID,isFirst,desc")] DotUser dotuser)
        {
            if (ModelState.IsValid)
            {
                db.DotUsers.Add(dotuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dotuser);
        }

        // GET: /DotUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotUser dotuser = db.DotUsers.Find(id);
            if (dotuser == null)
            {
                return HttpNotFound();
            }
            return View(dotuser);
        }

        // POST: /DotUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,userID,dotID,isFirst,desc")] DotUser dotuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dotuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dotuser);
        }

        // GET: /DotUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotUser dotuser = db.DotUsers.Find(id);
            if (dotuser == null)
            {
                return HttpNotFound();
            }
            return View(dotuser);
        }

        // POST: /DotUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DotUser dotuser = db.DotUsers.Find(id);
            db.DotUsers.Remove(dotuser);
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
