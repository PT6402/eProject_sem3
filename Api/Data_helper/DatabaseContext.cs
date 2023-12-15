
using Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data_helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee_type> Employee_types { get; set; }
        public DbSet<Address_store> Address_stores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Connect_type> Connect_types { get; set; }
        public DbSet<Supplier> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stories> Product_changes { get; set; }
        public DbSet<Package> Category { get; set; }
        public DbSet<Duration> SubCategories { get; set; }
        public DbSet<Duration_detail> Detail_Subs { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<TP_contractor> Info_users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity
                .HasOne(x => x.User)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_Emp_User");

                entity
                .HasOne(x => x.Employee_type)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.Employee_type_Id)
                .HasConstraintName("FK_Emp_Emp_type");

                entity
                .HasOne(x => x.Address_store)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.Address_store_Id)
                .HasConstraintName("FK_Emp_Address_store");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.Supplier_Id)
                .HasConstraintName("FK_Product_Supplier");
            });
            modelBuilder.Entity<Stories>(entity =>
            {
                entity
                .HasOne(x => x.Product)
                .WithMany(x => x.Stories)
                .HasForeignKey(x => x.Product_Id)
                .HasConstraintName("FK_Product_Stories");
            });
            modelBuilder.Entity<Package>(entity =>
            {
                entity
                .HasOne(x => x.Connect_type)
                .WithMany(x => x.Packages)
                .HasForeignKey(x => x.Connect_type_Id)
                .HasConstraintName("FK_Packages_Connect_type");
            });
            modelBuilder.Entity<Duration>(entity =>
          {
              entity
              .HasOne(x => x.Package)
              .WithMany(x => x.Durations)
              .HasForeignKey(x => x.Package_Id)
              .HasConstraintName("FK_Duration_Package");
          });
            modelBuilder.Entity<Duration_detail>(entity =>
          {
              entity
              .HasOne(x => x.Duration)
              .WithMany(x => x.Duration_details)
              .HasForeignKey(x => x.Duration_Id)
              .HasConstraintName("FK_Duration_detail_Duration");
          }); modelBuilder.Entity<Order>(entity =>
          {
              entity
              .HasOne(x => x.Duration)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.Duration_Id)
              .HasConstraintName("FK_Order_Duration")
              .OnDelete(DeleteBehavior.NoAction);

              entity
              .HasOne(x => x.Duration_detail)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.Duration_detail_Id)
              .HasConstraintName("FK_Order_Duration_detail")
              .OnDelete(DeleteBehavior.NoAction);


              entity
              .HasOne(x => x.TP_contractor)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.TP_contractor_Id)
              .HasConstraintName("FK_Order_TP_contractor")
              .OnDelete(DeleteBehavior.NoAction);

              entity
              .HasOne(x => x.Coupon)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.Coupon_Id)
              .HasConstraintName("FK_Order_Coupon")
              .OnDelete(DeleteBehavior.NoAction);
          });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity
                .HasOne(x => x.Order)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.Order_Id)
                .HasConstraintName("FK_Payment_Order");
            });

        }
    }
}
