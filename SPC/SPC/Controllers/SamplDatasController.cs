using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SPC.Models;

namespace SPC.Controllers
{
    public class SamplDatasController : Controller
    {
        private SPCContext db = new SPCContext();

        // GET: SamplDatas
        public ActionResult Index(int page = 1)
        {
			IPagedList<SamplDatas> ldata = db.SamplDatas.OrderBy(m=>m.SerialNumber).ThenBy(n => n.Set_id).ThenBy( m=>m.ArrayX).ThenBy(m=>m.ArrayY).ToPagedList(page, 10);
			for(int i = 0; i < ldata.Count; i++)
			{
				Settings sets= db.Settings.Find(ldata[i].Set_id);
				ldata[i].Set_Name = sets.Name;
			}
			return View(ldata);
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
			ViewBag.SerrialNum = GenerateOrderNumber();

			return View();
        }
		[HttpPost]
		public ActionResult Create_P(int setid,int ArrayX, int ArrayY,string  ArrayNum,string SerialNumber)
		{
			SamplDatas samplDatas = new SamplDatas();
			samplDatas.SerialNumber = SerialNumber;
			samplDatas.Set_id = setid;
			samplDatas.ArrayX = ArrayX;
			samplDatas.ArrayY = ArrayY;
			samplDatas.ArrayNum = ArrayNum;
			samplDatas.is_delete = 0;
			samplDatas.create_time = DateTime.Now;
			db.SamplDatas.Add(samplDatas);
			db.SaveChanges();
			return Json("ok");
		}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Set_id,ArrayX,ArrayY,ArrayNum,is_delete,create_time,create_user")] SamplDatas samplDatas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SamplDatas.Add(samplDatas);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(samplDatas);
        //}

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
        public ActionResult Edit([Bind(Include = "ID,Set_id,ArrayX,ArrayY,ArrayNum,is_delete,create_time,create_user")] SamplDatas samplDatas)
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

		/// <summary>
         /// 唯一订单号生成
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNumber()
         {
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmsssms");
            //string strRandomResult = NextRandom(1000, 1).ToString();
            return strDateTimeNumber;
        }
		private static int NextRandom(int numSeeds, int length)        {
            // Create a byte array to hold the random value.  
             byte[] randomNumber = new byte[length];
             // Create a new instance of the RNGCryptoServiceProvider.  
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
             // Fill the array with a random value.  
             rng.GetBytes(randomNumber);
            // Convert the byte to an uint value to make the modulus operation easier.  
            uint randomResult = 0x0;
            for (int i = 0; i<length; i++)
            {
                randomResult |= ((uint) randomNumber[i] << ((length - 1 - i) * 8));
            }
             return (int) (randomResult % numSeeds) + 1;
         }
    
 
	}
}
