namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class departments
    {
        public int ID { get; set; }
		[DisplayName("����")]
		public string Name { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("ʱ��")]
		public DateTime? create_time { get; set; }
    }
}
