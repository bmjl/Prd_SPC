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
    public class ProductionsController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: Productions
        public ActionResult Index()
        {
			var prds = db.Productions.ToList();
			foreach(var prd in prds)
			{
				Departments departments = db.departments.Find(prd.depId);
				prd.DepName = departments.Name;
			}

			return View(prds);
        }

        // GET: Productions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
			Departments departments = db.departments.Find(productions.depId);
			productions.DepName = departments.Name;
			if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // GET: Productions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,depId,is_delete,create_time,create_user")] Productions productions)
        {
			productions.create_time = DateTime.Now;
			productions.is_delete = 0;

			if (ModelState.IsValid)
            {
                db.Productions.Add(productions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productions);
        }

        // GET: Productions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
            if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // POST: Productions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,depId,is_delete,create_time,create_user")] Productions productions)
        {
			productions.create_time = DateTime.Now;
			if (ModelState.IsValid)
            {
                db.Entry(productions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productions);
        }

        // GET: Productions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
            if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productions productions = db.Productions.Find(id);
            db.Productions.Remove(productions);
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
