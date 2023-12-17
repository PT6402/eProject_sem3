
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
        public DbSet<Call_charges> Detail_Subs { get; set; }
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
                .HasForeignKey(x => x.User_Id)
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

            modelBuilder.Entity<Duration_callCharges>(entity =>
            {
                entity
                .HasOne(x => x.Duration)
                .WithMany(x => x.Duration_callChargeses)
                .HasForeignKey(x => x.Duration_Id)
                .HasConstraintName("FK_Duration_callCharges_Duration");

                entity
                .HasOne(x => x.Call_charges)
                .WithMany(x => x.Duration_callChargeses)
                .HasForeignKey(x => x.Call_charges_Id)
                .HasConstraintName("FK_Duration_callCharges_CallCharges");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity
                .HasOne(x => x.Duration_callCharges)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.Duration_callCharges_Id)
                .HasConstraintName("FK_Order_Duration")
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne(x => x.TP_contractor)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.TP_contractor_Id)
                .HasConstraintName("FK_Order_TP_contractor")
                .OnDelete(DeleteBehavior.NoAction);

                entity
                .HasOne(x => x.Coupon)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.Coupon_Id)
                .HasConstraintName("FK_Order_Coupon")
                .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity
                .HasOne(x => x.Order)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.Order_Id)
                .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<TP_contractor>(entity =>
            {
                entity
                .HasOne(x => x.Addresses)
                .WithOne(x => x.TP_contractor)
                .HasForeignKey<TP_contractor>(x => x.Addresses_Id)
                .HasConstraintName("FK_Contractor_Address");

                entity
                .HasOne(x => x.User)
                .WithMany(x => x.TP_contractors)
                .HasForeignKey(x => x.User_Id)
                .HasConstraintName("FK_Contractor_User");
            });

            modelBuilder.Entity<Product>(entity =>
           {
               entity
               .HasOne(x => x.Connect_type)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.Connect_type_Id)
               .HasConstraintName("FK_Product_ConnectType");
           });

            modelBuilder.Entity<Order_handler>(entity =>
           {
               entity
               .HasOne(x => x.Order)
               .WithOne(x => x.Order_handler)
               .HasForeignKey<Order_handler>(x => x.Order_Id)
               .HasConstraintName("FK_Order_handle_Order");

               entity
               .HasOne(x => x.Address_store)
               .WithMany(x => x.Order_handlers)
               .HasForeignKey(x => x.Address_store_Id)
               .HasConstraintName("FK_Order_handle_Address_store");

               entity
               .HasOne(x => x.Employee)
               .WithMany(x => x.Order_handlers)
               .HasForeignKey(x => x.Employee_Id)
               .HasConstraintName("FK_Order_handle_Employee");

           });



        }
    }
}
