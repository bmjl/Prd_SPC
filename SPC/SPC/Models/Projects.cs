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
		[DisplayName("��������")]
		public string prd_Name { get; set; }
		[DisplayName("����ID")]
		public int prd_id { get; set; }
		[DisplayName("��Ŀ����")]
		public string Name { get; set; }
		[DisplayName("�����Ŀ")]
		public string ControlItems { get; set; }
		[DisplayName("��λ")]
		public string Unit { get; set; }

        public int is_delete { get; set; }
		[DisplayName("ʱ��")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
