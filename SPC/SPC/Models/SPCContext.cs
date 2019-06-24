using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPC.Models
{
    public class SPCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SPCContext() : base("name=SPCContext")
        {
        }

		public System.Data.Entity.DbSet<SPC.Models.ControlConstants> ControlConstants { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.Departments> departments { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.Productions> Productions { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.Projects> Projects { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.SamplDatas> SamplDatas { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.SchemaViews> SchemaViews { get; set; }

		public System.Data.Entity.DbSet<SPC.Models.Settings> Settings { get; set; }
	}
}
