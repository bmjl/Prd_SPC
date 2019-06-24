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
						select.DptId = departments.ID;
						select.DptName = departments.Name;
						selects.Add(select);
					}
					break;
				case 2:
					List<Productions> lproductions = db.Productions.Where(m => m.depId == id).ToList();
					foreach (Productions productions in lproductions)
					{
						select.PrdName = productions.Name;
						select.PrdId = productions.ID;
						selects.Add(select);
					}
					
					break;
				case 3:
					List<Projects> lprojects = db.Projects.Where(m => m.prd_id == id).ToList();
					foreach (Projects projects in lprojects)
					{
						select.PjtName = projects.Name;
						select.PjtId = projects.ID;
						selects.Add(select);
					}


					break;
			}
			return Json(selects, JsonRequestBehavior.AllowGet);

		}

        
    }
}
