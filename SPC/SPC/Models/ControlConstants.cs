namespace SPC.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ControlConstants
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
		
		[Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DisplayName("×éÊý")]
		public int GroupNum { get; set; }

        [StringLength(10)]
        public string A2 { get; set; }

        [StringLength(10)]
        public string A3 { get; set; }

        [StringLength(10)]
        public string A4 { get; set; }

        [StringLength(10)]
        public string B2 { get; set; }

        [StringLength(10)]
        public string B3 { get; set; }

        [StringLength(10)]
        public string B4 { get; set; }

        [StringLength(10)]
        public string C2 { get; set; }

        [StringLength(10)]
        public string C3 { get; set; }

        [StringLength(10)]
        public string C4 { get; set; }

        [StringLength(10)]
        public string D2 { get; set; }

        [StringLength(10)]
        public string D3 { get; set; }

        [StringLength(10)]
        public string D4 { get; set; }

        [StringLength(10)]
        public string E2 { get; set; }

        [StringLength(10)]
        public string E3 { get; set; }

        [StringLength(10)]
        public string E4 { get; set; }
    }
}
