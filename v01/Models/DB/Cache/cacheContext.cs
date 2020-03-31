using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.DB.Cache
{
    public partial class CacheContext : DbContext
    {
        public CacheContext()
        {
        }

        public CacheContext(DbContextOptions<CacheContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=cache;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasColumnName("ISO")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Iso3)
                    .HasColumnName("ISO3")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.Property(e => e.Numcode).HasColumnName("numcode");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");

                entity.Property(e => e.SentenceCaseName)
                    .IsRequired()
                    .HasMaxLength(127);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.AlphabeticCode, e.NumericCode, e.MinorUnit })
                    .HasName("IDX_CNAME");

                entity.Property(e => e.AlphabeticCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Currency)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Currency_Country");
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.Property(e => e.ExchangeRateId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.ExchangeRate)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeRate_Currency");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
