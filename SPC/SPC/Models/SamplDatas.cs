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
		[DisplayName("��������")]
		[NotMapped]
		public string Set_Name { get; set; }
		public int? Set_id { get; set; }
		[DisplayName("˳��")]
		public string ArrayIindex { get; set; }
		[DisplayName("�������")]
		public string ArrayNUm { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("ʱ��")]
		public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
