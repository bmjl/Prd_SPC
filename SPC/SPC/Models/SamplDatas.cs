namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SamplDatas
    {
        public int ID { get; set; }
		[DisplayName("编号")]
		public string SerialNumber { get; set; }
		[DisplayName("设置名称")]
		[NotMapped]
		public string Set_Name { get; set; }
		public int? Set_id { get; set; }
		[DisplayName("X")]
		public int ArrayX { get; set; }

		[DisplayName("Y")]
		public int ArrayY { get; set; }
		[DisplayName("检测数据")]
		public string ArrayNum { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("时间")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
		[NotMapped]
		[DisplayName("图形")]
		public string ViewType { get; set; }
	}
}
