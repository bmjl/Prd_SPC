using SPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPC.Controllers
{
    public class DrawViewController : Controller
    {
		private SPCContext db = new SPCContext();
		// GET: DrawView
		public ActionResult XR(int SetId,string SN)
        {
			Settings settings = db.Settings.Find(SetId);
			ViewBag.setdata = settings;
			ControlConstants control = db.ControlConstants.Where(m => m.GroupNum == settings.Group_Num).First();
			ViewBag.ccdata = control;
			List<SamplDatas> sampls = db.SamplDatas.Where(m => m.SerialNumber == SN).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
			return View(sampls);
		}
		public ActionResult XS(int SetId, string SN)
		{
			//Settings settings = db.Settings.Find(SetId);
			//ViewBag.setdata = settings;
			//ControlConstants control = db.ControlConstants.Where(m => m.GroupNum == settings.Group_Num).First();
			//ViewBag.ccdata = control;
			//List<SamplDatas> sampls = db.SamplDatas.Where(m => m.SerialNumber == SN).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
			//return View(sampls);
			return View();
		}
		public ActionResult XMR(int SetId, string SN)
		{
			Settings settings = db.Settings.Find(SetId);
			ViewBag.setdata = settings;
			ControlConstants control = db.ControlConstants.Where(m => m.GroupNum == settings.Group_Num).First();
			ViewBag.ccdata = control;
			List<SamplDatas> sampls = db.SamplDatas.Where(m => m.SerialNumber == SN).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
			return View(sampls);
		}
		public ActionResult GetSettingData(int SetId)
		{
			Settings set = db.Settings.Find(SetId);
			return Json(set, JsonRequestBehavior.AllowGet);
		}
		public ActionResult GetSamplData(string SN)
		{
			List<SamplDatas> sampls = db.SamplDatas.Where(m => m.SerialNumber == SN).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
			return Json(sampls, JsonRequestBehavior.AllowGet);
		}
	}



}