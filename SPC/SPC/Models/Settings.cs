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
		[DisplayName("����")]
		public string Name { get; set; }
		[NotMapped]
		[DisplayName("��Ŀ����")]
		public string project_Name { get; set; }
		[DisplayName("��ĿID")]
		public int project_id { get; set; }
		[DisplayName("Ⱥ����")]
		public int Group_Num { get; set; }
		[DisplayName("������")]
		public int Group_Total { get; set; }
		[DisplayName("����")]
		public string UCL { get; set; }
		[DisplayName("������")]
		public string CL { get; set; }
		[DisplayName("����")]
		public string LCL { get; set; }
		[DisplayName("��������")]
		public string Sample { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("ʱ��")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
		[DisplayName("ͼ��")]
		public string ViewType { get; set; }

	}
}
