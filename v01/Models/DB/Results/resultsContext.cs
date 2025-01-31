﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.DB.Results
{
    public partial class ResultsContext : DbContext
    {
        public ResultsContext()
        {
        }

        public ResultsContext(DbContextOptions<ResultsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssemblyPartial> AssemblyPartial { get; set; }
        public virtual DbSet<ConsumablePartial> ConsumablePartial { get; set; }
        public virtual DbSet<EquipmentPartial> EquipmentPartial { get; set; }
        public virtual DbSet<LaborPartial> LaborPartial { get; set; }
        public virtual DbSet<MaterialPartial> MaterialPartial { get; set; }
        public virtual DbSet<ParamItemPartial> ParamItemPartial { get; set; }
        public virtual DbSet<Partial> Partial { get; set; }
        public virtual DbSet<SubcontractorPartial> SubcontractorPartial { get; set; }
        public virtual DbSet<SupplierPartial> SupplierPartial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=results;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssemblyPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ConsumablePartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EquipmentPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LaborPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MaterialPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ParamItemPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Partial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SubcontractorPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SupplierPartial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ascending).HasColumnName("ascending");

                entity.Property(e => e.PageSize).HasColumnName("pageSize");

                entity.Property(e => e.PartialSize).HasColumnName("partialSize");

                entity.Property(e => e.PartialStart).HasColumnName("partialStart");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryType)
                    .IsRequired()
                    .HasColumnName("queryType")
                    .HasMaxLength(255);

                entity.Property(e => e.ResultSize).HasColumnName("resultSize");

                entity.Property(e => e.Seconds)
                    .HasColumnName("seconds")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SortByField)
                    .IsRequired()
                    .HasColumnName("sortByField")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
