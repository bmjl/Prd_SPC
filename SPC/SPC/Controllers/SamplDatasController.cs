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
    public class SamplDatasController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: SamplDatas
        public ActionResult Index()
        {
            return View(db.SamplDatas.ToList());
        }

        // GET: SamplDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplDatas samplDatas = db.SamplDatas.Find(id);
            if (samplDatas == null)
            {
                return HttpNotFound();
            }
            return View(samplDatas);
        }

        // GET: SamplDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SamplDatas/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Set_id,ArrayIindex,ArrayNUm,is_delete,create_time,create_user")] SamplDatas samplDatas)
        {
            if (ModelState.IsValid)
            {
                db.SamplDatas.Add(samplDatas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samplDatas);
        }

        // GET: SamplDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplDatas samplDatas = db.SamplDatas.Find(id);
            if (samplDatas == null)
            {
                return HttpNotFound();
            }
            return View(samplDatas);
        }

        // POST: SamplDatas/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Set_id,ArrayIindex,ArrayNUm,is_delete,create_time,create_user")] SamplDatas samplDatas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samplDatas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samplDatas);
        }

        // GET: SamplDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplDatas samplDatas = db.SamplDatas.Find(id);
            if (samplDatas == null)
            {
                return HttpNotFound();
            }
            return View(samplDatas);
        }

        // POST: SamplDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SamplDatas samplDatas = db.SamplDatas.Find(id);
            db.SamplDatas.Remove(samplDatas);
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
