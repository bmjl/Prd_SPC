namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settings
    {
        public int ID { get; set; }

        public int project_id { get; set; }

        public int Group_Num { get; set; }

        public int Group_Total { get; set; }

        public string UCL { get; set; }

        public string CL { get; set; }

        public string LCL { get; set; }

        public string Sample { get; set; }

        public int? is_delete { get; set; }

        public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
