using Microsoft.Ajax.Utilities;
using SPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPC.Controllers
{
    public class SelectController : Controller
    {
		private SPCContext db = new SPCContext();
		[HttpGet]
		public ActionResult GetData(int type,int id)
		{
			List<SamplDatas> sampls = new List<SamplDatas>();
			int setid = 0, dptid = 0, pjtid = 0;
			switch (type)
			{
				case 0:
					sampls = db.SamplDatas.OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
					break;
				case 4:
					//目前只用这个查询
					//id=set_id
					//ViewType
					var viewtype = db.Settings.Find(id).ViewType;
					var datas = db.SamplDatas.DistinctBy(p=>p.SerialNumber).ToList();
					sampls = datas.Where(m => m.Set_id == id).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
					//sampls = sampls.DistinctBy(p => p.SerialNumber).ToList();
					foreach (SamplDatas sampl in sampls)
					{
						sampl.ViewType = viewtype;
					}
					
					break;

				case 3:
					//id=pjt_id					
					setid = db.Settings.Find(id).ID;
					sampls = db.SamplDatas.Where(m => m.Set_id == setid).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
					break;
				case 2:
					//id=prd_id
					pjtid = db.Projects.Find(id).ID;
					setid = db.Settings.Find(pjtid).ID;
					sampls = db.SamplDatas.Where(m => m.Set_id == setid).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
					break;
				case 1:
					//id=dmt_id
					dptid = db.Productions.Find(id).ID;
					pjtid = db.Projects.Find(id).ID;
					setid = db.Settings.Find(pjtid).ID;
					sampls = db.SamplDatas.Where(m => m.Set_id == setid).OrderBy(m => m.SerialNumber).ThenBy(n => n.Set_id).ThenBy(m => m.ArrayX).ThenBy(m => m.ArrayY).ToList();
					break;
			}


			return Json(sampls, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
        public ActionResult Index(int id,int type)
		{
			List<Select> selects = new List<Select>();
			//1,部门；2，机别；3，项目；4，设置；
			Select select = new Select();
			switch (type)
			{
				case 1:
					List<Departments> ldepartments  = db.departments.ToList();
					foreach(Departments departments in ldepartments)
					{
						select = new Select();
						select.DptId = departments.ID;
						select.DptName = departments.Name;
						selects.Add(select);
					}
					break;
				case 2:
					List<Productions> lproductions = db.Productions.Where(m => m.depId == id).ToList();
					foreach (Productions productions in lproductions)
					{
						select = new Select();
						select.PrdName = productions.Name;
						select.PrdId = productions.ID;
						selects.Add(select);
					}
					
					break;
				case 3:
					List<Projects> lprojects = db.Projects.Where(m => m.prd_id == id).ToList();
					foreach (Projects projects in lprojects)
					{
						select = new Select();
						select.PjtName = projects.Name;
						select.PjtId = projects.ID;
						selects.Add(select);
					}
					break;
				case 4:
					List<Settings> lsettings = db.Settings.Where(m => m.project_id == id).ToList();
					ViewBag.setlist = lsettings;
					foreach (Settings settings in lsettings)
					{
						select = new Select();
						select.SetName = settings.Name;
						select.SetId = settings.ID;
						select.X = settings.Group_Num;
						select.Y = settings.Group_Total;
						selects.Add(select);
					}
					break;
			}
			return Json(selects, JsonRequestBehavior.AllowGet);

		}

        
    }
}
