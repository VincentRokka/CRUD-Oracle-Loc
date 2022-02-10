namespace DbFirst.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OracleDb : DbContext
    {
        public OracleDb()
            : base("name=OracleDb")
        {
        }

        public virtual DbSet<PERSON> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PERSON>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.FULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.SALARY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.NOTE)
                .IsUnicode(false);
        }
    }
}
