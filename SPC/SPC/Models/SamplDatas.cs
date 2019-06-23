namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SamplDatas
    {
        public int ID { get; set; }

        public int? Set_id { get; set; }

        public string ArrayIindex { get; set; }

        public string ArrayNUm { get; set; }

        public int? is_delete { get; set; }

        public DateTime? create_time { get; set; }

        public int? create_user { get; set; }
    }
}
