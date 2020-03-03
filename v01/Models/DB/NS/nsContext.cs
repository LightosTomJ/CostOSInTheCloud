using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.DB.NS
{
    public partial class nsContext : DbContext
    {
        public nsContext()
        {
        }

        public nsContext(DbContextOptions<nsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectNamingStrategy> ProjectNamingStrategy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=ns;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectNamingStrategy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasMaxLength(127);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
