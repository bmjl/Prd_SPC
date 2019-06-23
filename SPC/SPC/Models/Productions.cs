namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productions
    {
        public int ID { get; set; }
		[DisplayName("名称")]
		public string Name { get; set; }
		[DisplayName("部门名称")]
		[NotMapped]
		public string DepName { get; set; }
        public int depId { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("时间")]
		public DateTime? create_time { get; set; }
		
		public int? create_user { get; set; }
    }
}
