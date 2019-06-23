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
    public class SchemaViewsController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: SchemaViews
        public ActionResult Index()
        {
            return View(db.SchemaViews.ToList());
        }

        // GET: SchemaViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaViews schemaViews = db.SchemaViews.Find(id);
            if (schemaViews == null)
            {
                return HttpNotFound();
            }
            return View(schemaViews);
        }

        // GET: SchemaViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchemaViews/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,type,is_delete,describe")] SchemaViews schemaViews)
        {
            if (ModelState.IsValid)
            {
                db.SchemaViews.Add(schemaViews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schemaViews);
        }

        // GET: SchemaViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaViews schemaViews = db.SchemaViews.Find(id);
            if (schemaViews == null)
            {
                return HttpNotFound();
            }
            return View(schemaViews);
        }

        // POST: SchemaViews/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,type,is_delete,describe")] SchemaViews schemaViews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schemaViews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schemaViews);
        }

        // GET: SchemaViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaViews schemaViews = db.SchemaViews.Find(id);
            if (schemaViews == null)
            {
                return HttpNotFound();
            }
            return View(schemaViews);
        }

        // POST: SchemaViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchemaViews schemaViews = db.SchemaViews.Find(id);
            db.SchemaViews.Remove(schemaViews);
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
