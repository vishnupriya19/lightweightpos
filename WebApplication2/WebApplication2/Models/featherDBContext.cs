using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class featherDBContext : DbContext
    {
        //public featherDBContext()
        //{
        //}

        public featherDBContext(DbContextOptions<featherDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Merchant> Merchant { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Quantity> Quantity { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketLineProduct> TicketLineProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=VANI;Database=featherDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.MerchantId });

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Merchant");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.MerchantId });

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Points).HasColumnName("points");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Merchant");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.MerchantId });

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.Dateofjoining)
                    .HasColumnName("dateofjoining")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Designation");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Merchant");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.OrganizationName)
                    .HasColumnName("organizationName")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.MerchantId });

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Comission).HasColumnName("comission");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedUserName)
                    .HasColumnName("modifiedUserName")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Sellingprice).HasColumnName("sellingprice");

                entity.Property(e => e.Unitcost).HasColumnName("unitcost");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Merchant");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => new { d.CategoryId, d.MerchantId })
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Quantity>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.MerchantId });

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.DepletionQuantity).HasColumnName("depletionQuantity");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantityInStock");

                entity.Property(e => e.QuantityRemaining).HasColumnName("quantityRemaining");

                entity.Property(e => e.QuantitySold).HasColumnName("quantitySold");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Quantity)
                    .HasForeignKey<Quantity>(d => new { d.ProductId, d.MerchantId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quantity_Product");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.Merchantid });

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticketId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Merchantid).HasColumnName("merchantid");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalCost).HasColumnName("totalCost");
            });

            modelBuilder.Entity<TicketLineProduct>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.ProductId, e.MerchantId });

                entity.Property(e => e.TicketId).HasColumnName("ticketId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.Commission).HasColumnName("commission");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            });
        }
    }
}
