namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Projects
    {
        public int ID { get; set; }
		[NotMapped]
		[DisplayName("机别名称")]
		public string prd_Name { get; set; }
		[DisplayName("机别ID")]
		public int prd_id { get; set; }
		[DisplayName("项目名称")]
		public string Name { get; set; }
		[DisplayName("检测项目")]
		public string ControlItems { get; set; }
		[DisplayName("单位")]
		public string Unit { get; set; }

        public int is_delete { get; set; }
		[DisplayName("时间")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
