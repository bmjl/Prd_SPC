using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPC.Models;

namespace SPC.Controllers
{
    public class ControlConstantsController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: ControlConstants
        public ActionResult Index()
        {
            return View(db.ControlConstants.ToList());
        }

        // GET: ControlConstants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlConstants controlConstants = db.ControlConstants.Find(id);
            if (controlConstants == null)
            {
                return HttpNotFound();
            }
            return View(controlConstants);
        }

        // GET: ControlConstants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlConstants/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupNum,A2,A3,A4,B2,B3,B4,C2,C3,C4,D2,D3,D4,E2,E3,E4")] ControlConstants controlConstants)
        {
            if (ModelState.IsValid)
            {
                db.ControlConstants.Add(controlConstants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(controlConstants);
        }

        // GET: ControlConstants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlConstants controlConstants = db.ControlConstants.Find(id);
            if (controlConstants == null)
            {
                return HttpNotFound();
            }
            return View(controlConstants);
        }

        // POST: ControlConstants/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupNum,A2,A3,A4,B2,B3,B4,C2,C3,C4,D2,D3,D4,E2,E3,E4")] ControlConstants controlConstants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlConstants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controlConstants);
        }

        // GET: ControlConstants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlConstants controlConstants = db.ControlConstants.Find(id);
            if (controlConstants == null)
            {
                return HttpNotFound();
            }
            return View(controlConstants);
        }

        // POST: ControlConstants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlConstants controlConstants = db.ControlConstants.Find(id);
            db.ControlConstants.Remove(controlConstants);
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
