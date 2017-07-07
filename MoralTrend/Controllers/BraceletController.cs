using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoralTrend.Models;

namespace MoralTrend.Controllers
{
    public class BraceletController : Controller
    {
        private moraltrendDBEntities db = new moraltrendDBEntities();

        // GET: Bracelet
        public ActionResult Index()
        {
            return View(db.braceletInfoes.ToList());
        }

        // GET: Bracelet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            braceletInfo braceletInfo = db.braceletInfoes.Find(id);
            if (braceletInfo == null)
            {
                return HttpNotFound();
            }
            return View(braceletInfo);
        }

        // GET: Bracelet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bracelet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "braceletID,name,location,deedDate,goodDeed")] braceletInfo braceletInfo)
        {
            if (ModelState.IsValid)
            {
                db.braceletInfoes.Add(braceletInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(braceletInfo);
        }

        // GET: Bracelet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            braceletInfo braceletInfo = db.braceletInfoes.Find(id);
            if (braceletInfo == null)
            {
                return HttpNotFound();
            }
            return View(braceletInfo);
        }

        // POST: Bracelet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "braceletID,name,location,deedDate,goodDeed")] braceletInfo braceletInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(braceletInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(braceletInfo);
        }

        // GET: Bracelet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            braceletInfo braceletInfo = db.braceletInfoes.Find(id);
            if (braceletInfo == null)
            {
                return HttpNotFound();
            }
            return View(braceletInfo);
        }

        // POST: Bracelet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            braceletInfo braceletInfo = db.braceletInfoes.Find(id);
            db.braceletInfoes.Remove(braceletInfo);
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
