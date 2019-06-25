namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settings
    {
        public int ID { get; set; }
		[DisplayName("名称")]
		public string Name { get; set; }
		[NotMapped]
		[DisplayName("项目名称")]
		public string project_Name { get; set; }
		[DisplayName("项目ID")]
		public int project_id { get; set; }
		[DisplayName("群组数")]
		public int Group_Num { get; set; }
		[DisplayName("总组数")]
		public int Group_Total { get; set; }
		[DisplayName("上限")]
		public string UCL { get; set; }
		[DisplayName("中心限")]
		public string CL { get; set; }
		[DisplayName("下限")]
		public string LCL { get; set; }
		[DisplayName("抽样方法")]
		public string Sample { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("时间")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
		[DisplayName("图形")]
		public string ViewType { get; set; }

	}
}
