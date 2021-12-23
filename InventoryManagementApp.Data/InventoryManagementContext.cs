using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryManagementApp.Data.Models
{
    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
        {
        }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<ClientSite> ClientSite { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=USC-W-6990M13\\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.ClientSiteId).HasColumnName("ClientSiteID");

                entity.Property(e => e.InventoriedBy).HasMaxLength(64);

                entity.Property(e => e.InventoryDate).HasColumnType("datetime");

                entity.Property(e => e.InventoryOwner)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.ItemName).HasMaxLength(64);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ManuafcturerId).HasColumnName("ManuafcturerID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber).HasMaxLength(64);

                entity.HasOne(d => d.ClientSite)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ClientSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asset__ClientSit__440B1D61");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asset__LocationI__4316F928");

                entity.HasOne(d => d.Manuafcturer)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ManuafcturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asset__Manuafctu__412EB0B6");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asset__ModelID__4222D4EF");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asset__ProductID__403A8C7D");
            });

            modelBuilder.Entity<ClientSite>(entity =>
            {
                entity.Property(e => e.ClientSiteId).HasColumnName("ClientSiteID");

                entity.Property(e => e.ClientSiteName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
