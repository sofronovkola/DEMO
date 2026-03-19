using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DEMO.Entities;

public partial class Db16Context : DbContext
{
    public Db16Context()
    {
    }

    public Db16Context(DbContextOptions<Db16Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Namesproduct> Namesproducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordersproduct> Ordersproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=10.0.8.8;database=DB16;uid=User16;pwd=KitLab@2025", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAdress).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.IdAdress).HasColumnName("ID_Adress");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.HouseNumber).HasColumnName("House_number");
            entity.Property(e => e.Street).HasColumnType("text");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("PRIMARY");

            entity.ToTable("manufacturer");

            entity.Property(e => e.IdManufacturer).HasColumnName("ID_Manufacturer");
            entity.Property(e => e.Manufacturer1)
                .HasColumnType("text")
                .HasColumnName("Manufacturer");
        });

        modelBuilder.Entity<Namesproduct>(entity =>
        {
            entity.HasKey(e => e.IdNameProduct).HasName("PRIMARY");

            entity.ToTable("namesproducts");

            entity.Property(e => e.IdNameProduct).HasColumnName("ID_name_product");
            entity.Property(e => e.NameProduct)
                .HasColumnType("text")
                .HasColumnName("Name_product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.Address, "Address_idx");

            entity.HasIndex(e => e.IdUser, "user_idx");

            entity.Property(e => e.IdOrder).HasColumnName("ID_order");
            entity.Property(e => e.Article).HasColumnType("text");
            entity.Property(e => e.CodeToReceive).HasColumnName("Code_to_receive");
            entity.Property(e => e.DateDelvery)
                .HasColumnType("text")
                .HasColumnName("Date_delvery");
            entity.Property(e => e.DateOrder)
                .HasColumnType("text")
                .HasColumnName("Date_order");
            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.Status).HasColumnType("text");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("Address");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user");
        });

        modelBuilder.Entity<Ordersproduct>(entity =>
        {
            entity.HasKey(e => e.IdOrderProduct).HasName("PRIMARY");

            entity.ToTable("ordersproducts");

            entity.HasIndex(e => e.Order, "order_idx");

            entity.HasIndex(e => e.Product, "prod_idx");

            entity.Property(e => e.IdOrderProduct).HasColumnName("ID_order_product");

            entity.HasOne(d => d.OrderNavigation).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.Order)
                .HasConstraintName("order");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.Product)
                .HasConstraintName("prod");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.Manufacturer, "manuf_idx");

            entity.HasIndex(e => e.NameProduct, "namprod_idx");

            entity.HasIndex(e => e.Supplier, "suppl_idx");

            entity.Property(e => e.IdProduct).HasColumnName("ID_product");
            entity.Property(e => e.Article).HasColumnType("text");
            entity.Property(e => e.Category).HasColumnType("text");
            entity.Property(e => e.CountInStock).HasColumnName("Count_in_stock");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NameProduct).HasColumnName("Name_product");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.ProductUnit)
                .HasColumnType("text")
                .HasColumnName("Product_unit");

            entity.HasOne(d => d.ManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Manufacturer)
                .HasConstraintName("manuf");

            entity.HasOne(d => d.NameProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.NameProduct)
                .HasConstraintName("namprod");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplier)
                .HasConstraintName("suppl");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.RoleName)
                .HasColumnType("text")
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.IdSupplier).HasColumnName("ID_supplier");
            entity.Property(e => e.Supplier1)
                .HasColumnType("text")
                .HasColumnName("Supplier");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleEmployee, "roleemp_idx");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasColumnType("text");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.RoleEmployee).HasColumnName("Role_employee");

            entity.HasOne(d => d.RoleEmployeeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleEmployee)
                .HasConstraintName("roleemp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
