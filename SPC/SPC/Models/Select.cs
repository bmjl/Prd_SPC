using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPC.Models
{
	public class Select
	{
		[NotMapped]
		[DisplayName("部门名称")]
		public string DptName { get; set; }
		[NotMapped]
		public int DptId { get; set; }
		[NotMapped]
		[DisplayName("机别名称")]
		public string PrdName { get; set; }
		[NotMapped]
		public int PrdId { get; set; }

		[DisplayName("项目名称")]
		[NotMapped]
		public string PjtName { get; set; }
		[NotMapped]
		public int PjtId { get; set; }

		[NotMapped]
		[DisplayName("设置名称")]
		public string SetName { get; set; }
		[NotMapped]
		public int SetId { get; set; }

		//1,部门；2，机别；3，项目；4，设置；
		[NotMapped]
		[DisplayName("类别")]
		public int Type { get; set; }
	}
}