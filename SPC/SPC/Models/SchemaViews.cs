namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SchemaViews
    {
        public int ID { get; set; }

        public string type { get; set; }

        public int is_delete { get; set; }

        public string describe { get; set; }
    }
}
