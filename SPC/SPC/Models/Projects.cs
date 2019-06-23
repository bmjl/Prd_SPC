namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Projects
    {
        public int ID { get; set; }

        public int prd_id { get; set; }

        public string Name { get; set; }

        public string ControlItems { get; set; }

        public string Unit { get; set; }

        public int is_delete { get; set; }

        public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
