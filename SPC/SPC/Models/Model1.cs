namespace SPC.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<departments> departments { get; set; }
		public virtual DbSet<Productions> Productions { get; set; }
		public virtual DbSet<Projects> Projects { get; set; }
		public virtual DbSet<SamplDatas> SamplDatas { get; set; }
		public virtual DbSet<SchemaViews> SchemaViews { get; set; }
		public virtual DbSet<Settings> Settings { get; set; }
		public virtual DbSet<ControlConstants> ControlConstants { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.A2)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.A3)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.A4)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.B2)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.B3)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.B4)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.C2)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.C3)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.C4)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.D2)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.D3)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.D4)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.E2)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.E3)
				.IsFixedLength();

			modelBuilder.Entity<ControlConstants>()
				.Property(e => e.E4)
				.IsFixedLength();
		}
	}
}
