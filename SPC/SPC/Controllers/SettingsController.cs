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
    public class SettingsController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: Settings
        public ActionResult Index()
        {
			var sets = db.Settings.ToList();
			foreach (var set in sets)
			{
				Projects projects = db.Projects.Find(set.project_id);
				set.project_Name = projects.Name;
			}
			return View(sets);
        }

        // GET: Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = db.Settings.Find(id);

			Projects projects = db.Projects.Find(settings.project_id);
			settings.project_Name = projects.Name;
			if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,project_id,Group_Num,Group_Total,UCL,CL,LCL,Sample,is_delete,create_time,create_user")] Settings settings)
        {
			settings.create_time = DateTime.Now;
			settings.is_delete = 0;
			if (ModelState.IsValid)
            {
                db.Settings.Add(settings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(settings);
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = db.Settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: Settings/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,project_id,Group_Num,Group_Total,UCL,CL,LCL,Sample,is_delete,create_time,create_user")] Settings settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(settings);
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = db.Settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Settings settings = db.Settings.Find(id);
            db.Settings.Remove(settings);
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
