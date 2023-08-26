using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobileStore.DataAccessLayer.Models
{
    public partial class MobileStoreContext : DbContext
    {
        public MobileStoreContext()
        {
        }

        public MobileStoreContext(DbContextOptions<MobileStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=MobileStore; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("cidpk");

                entity.ToTable("Customer");

                entity.Property(e => e.Cid)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cid")
                    .IsFixedLength();

                entity.Property(e => e.CEmail)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cEmail");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName");
            });

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("midpk");

                entity.ToTable("Mobile");

                entity.Property(e => e.Mid)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mid")
                    .IsFixedLength();

                entity.Property(e => e.MBrand)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mBrand");

                entity.Property(e => e.MDate)
                    .HasColumnType("date")
                    .HasColumnName("mDate");

                entity.Property(e => e.MModel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mModel");

                entity.Property(e => e.Qty).HasColumnName("qty");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("sidpk");

                entity.ToTable("Sale");

                entity.Property(e => e.Sid)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("sid")
                    .IsFixedLength();

                entity.Property(e => e.Cid)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cid")
                    .IsFixedLength();

                entity.Property(e => e.Costpermobile).HasColumnName("costpermobile");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Mid)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mid")
                    .IsFixedLength();

                entity.Property(e => e.Saledate)
                    .HasColumnType("date")
                    .HasColumnName("saledate");

                entity.Property(e => e.Sellingpricepermobile).HasColumnName("sellingpricepermobile");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("cidfk");

                entity.HasOne(d => d.MidNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Mid)
                    .HasConstraintName("midfk");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__tmp_ms_x__DDDFDD361BBEDF6F");

                entity.ToTable("saleDetails");

                entity.Property(e => e.Sid)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("sid")
                    .IsFixedLength();

                entity.Property(e => e.Actualsellingprice).HasColumnName("actualsellingprice");

                entity.Property(e => e.Costpricepermobile).HasColumnName("costpricepermobile");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Discountamount).HasColumnName("discountamount");

                entity.Property(e => e.Profiteorloss).HasColumnName("profiteorloss");

                entity.Property(e => e.Sellingpricepermobile).HasColumnName("sellingpricepermobile");

                entity.Property(e => e.Totalactualsellingprice).HasColumnName("totalactualsellingprice");

                entity.Property(e => e.Totalcostprice).HasColumnName("totalcostprice");

                entity.Property(e => e.TotalsellingPrice).HasColumnName("totalsellingPrice");

                entity.HasOne(d => d.SidNavigation)
                    .WithOne(p => p.SaleDetail)
                    .HasForeignKey<SaleDetail>(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saleDetails__sid__17F790F9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
