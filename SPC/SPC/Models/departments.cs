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
		[DisplayName("Ãû³Æ")]
		public string Name { get; set; }

        public int? is_delete { get; set; }
		[DisplayName("Ê±¼ä")]
		public DateTime? create_time { get; set; }
    }
}
