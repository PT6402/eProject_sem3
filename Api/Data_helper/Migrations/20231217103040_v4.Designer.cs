﻿// <auto-generated />
using System;
using Api.Data_helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Data_helper.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231217103040_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lib.Entities.Address_store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Region_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbAddress_store");
                });

            modelBuilder.Entity("Lib.Entities.Addresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address_full")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbAddress");
                });

            modelBuilder.Entity("Lib.Entities.Call_charges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbCall_charges");
                });

            modelBuilder.Entity("Lib.Entities.Connect_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Letter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Security_Deposit")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("tbConnect_type");
                });

            modelBuilder.Entity("Lib.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.Property<int>("Range_Connect")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbCoupon");
                });

            modelBuilder.Entity("Lib.Entities.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Package_Id")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Package_Id");

                    b.ToTable("tbDuration");
                });

            modelBuilder.Entity("Lib.Entities.Duration_callCharges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Call_charges_Id")
                        .HasColumnType("int");

                    b.Property<int>("Duration_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Call_charges_Id");

                    b.HasIndex("Duration_Id");

                    b.ToTable("tbDuration_callCharges");
                });

            modelBuilder.Entity("Lib.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Address_store_Id")
                        .HasColumnType("int");

                    b.Property<int>("Employee_type_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Address_store_Id");

                    b.HasIndex("Employee_type_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("tbEmployee");
                });

            modelBuilder.Entity("Lib.Entities.Employee_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbEmployee_type");
                });

            modelBuilder.Entity("Lib.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Coupon_Id")
                        .HasColumnType("int");

                    b.Property<int>("Duration_callCharges_Id")
                        .HasColumnType("int");

                    b.Property<int>("Numb_Connect")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TP_contractor_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Total_Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Coupon_Id")
                        .IsUnique()
                        .HasFilter("[Coupon_Id] IS NOT NULL");

                    b.HasIndex("Duration_callCharges_Id");

                    b.HasIndex("TP_contractor_Id")
                        .IsUnique();

                    b.ToTable("tbOrders");
                });

            modelBuilder.Entity("Lib.Entities.Order_handler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Address_store_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Employee_Id")
                        .HasColumnType("int");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("StatusHandle")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Address_store_Id");

                    b.HasIndex("Employee_Id");

                    b.HasIndex("Order_Id")
                        .IsUnique();

                    b.ToTable("Order_handler");
                });

            modelBuilder.Entity("Lib.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Connect_type_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Connect_type_Id");

                    b.ToTable("tbPackage");
                });

            modelBuilder.Entity("Lib.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Method_Payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id")
                        .IsUnique();

                    b.ToTable("tbPayment");
                });

            modelBuilder.Entity("Lib.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Connect_type_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numb_Connect")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Seri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Supplier_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Connect_type_Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("tbProduct");
                });

            modelBuilder.Entity("Lib.Entities.Stories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("tbStories");
                });

            modelBuilder.Entity("Lib.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detail_contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbSupplier");
                });

            modelBuilder.Entity("Lib.Entities.TP_contractor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Addresses_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Addresses_Id")
                        .IsUnique();

                    b.HasIndex("User_Id");

                    b.ToTable("tbTP_contractor");
                });

            modelBuilder.Entity("Lib.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MethodReset")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordReset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("tbUser");
                });

            modelBuilder.Entity("Lib.Entities.Duration", b =>
                {
                    b.HasOne("Lib.Entities.Package", "Package")
                        .WithMany("Durations")
                        .HasForeignKey("Package_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Duration_Package");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Lib.Entities.Duration_callCharges", b =>
                {
                    b.HasOne("Lib.Entities.Call_charges", "Call_charges")
                        .WithMany("Duration_callChargeses")
                        .HasForeignKey("Call_charges_Id")
                        .HasConstraintName("FK_Duration_callCharges_CallCharges");

                    b.HasOne("Lib.Entities.Duration", "Duration")
                        .WithMany("Duration_callChargeses")
                        .HasForeignKey("Duration_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Duration_callCharges_Duration");

                    b.Navigation("Call_charges");

                    b.Navigation("Duration");
                });

            modelBuilder.Entity("Lib.Entities.Employee", b =>
                {
                    b.HasOne("Lib.Entities.Address_store", "Address_store")
                        .WithMany("Employees")
                        .HasForeignKey("Address_store_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Emp_Address_store");

                    b.HasOne("Lib.Entities.Employee_type", "Employee_type")
                        .WithMany("Employees")
                        .HasForeignKey("Employee_type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Emp_Emp_type");

                    b.HasOne("Lib.Entities.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Emp_User");

                    b.Navigation("Address_store");

                    b.Navigation("Employee_type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lib.Entities.Order", b =>
                {
                    b.HasOne("Lib.Entities.Coupon", "Coupon")
                        .WithOne("Order")
                        .HasForeignKey("Lib.Entities.Order", "Coupon_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Order_Coupon");

                    b.HasOne("Lib.Entities.Duration_callCharges", "Duration_callCharges")
                        .WithMany("Orders")
                        .HasForeignKey("Duration_callCharges_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Duration");

                    b.HasOne("Lib.Entities.TP_contractor", "TP_contractor")
                        .WithOne("Order")
                        .HasForeignKey("Lib.Entities.Order", "TP_contractor_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Order_TP_contractor");

                    b.Navigation("Coupon");

                    b.Navigation("Duration_callCharges");

                    b.Navigation("TP_contractor");
                });

            modelBuilder.Entity("Lib.Entities.Order_handler", b =>
                {
                    b.HasOne("Lib.Entities.Address_store", "Address_store")
                        .WithMany("Order_handlers")
                        .HasForeignKey("Address_store_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_handle_Address_store");

                    b.HasOne("Lib.Entities.Employee", "Employee")
                        .WithMany("Order_handlers")
                        .HasForeignKey("Employee_Id")
                        .HasConstraintName("FK_Order_handle_Employee");

                    b.HasOne("Lib.Entities.Order", "Order")
                        .WithOne("Order_handler")
                        .HasForeignKey("Lib.Entities.Order_handler", "Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_handle_Order");

                    b.Navigation("Address_store");

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lib.Entities.Package", b =>
                {
                    b.HasOne("Lib.Entities.Connect_type", "Connect_type")
                        .WithMany("Packages")
                        .HasForeignKey("Connect_type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Packages_Connect_type");

                    b.Navigation("Connect_type");
                });

            modelBuilder.Entity("Lib.Entities.Payment", b =>
                {
                    b.HasOne("Lib.Entities.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Lib.Entities.Payment", "Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Payment_Order");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lib.Entities.Product", b =>
                {
                    b.HasOne("Lib.Entities.Connect_type", "Connect_type")
                        .WithMany("Products")
                        .HasForeignKey("Connect_type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ConnectType");

                    b.HasOne("Lib.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("Supplier_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Supplier");

                    b.Navigation("Connect_type");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Lib.Entities.Stories", b =>
                {
                    b.HasOne("Lib.Entities.Product", "Product")
                        .WithMany("Stories")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Stories");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Lib.Entities.TP_contractor", b =>
                {
                    b.HasOne("Lib.Entities.Addresses", "Addresses")
                        .WithOne("TP_contractor")
                        .HasForeignKey("Lib.Entities.TP_contractor", "Addresses_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Contractor_Address");

                    b.HasOne("Lib.Entities.User", "User")
                        .WithMany("TP_contractors")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Contractor_User");

                    b.Navigation("Addresses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lib.Entities.Address_store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Order_handlers");
                });

            modelBuilder.Entity("Lib.Entities.Addresses", b =>
                {
                    b.Navigation("TP_contractor");
                });

            modelBuilder.Entity("Lib.Entities.Call_charges", b =>
                {
                    b.Navigation("Duration_callChargeses");
                });

            modelBuilder.Entity("Lib.Entities.Connect_type", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Lib.Entities.Coupon", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lib.Entities.Duration", b =>
                {
                    b.Navigation("Duration_callChargeses");
                });

            modelBuilder.Entity("Lib.Entities.Duration_callCharges", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Lib.Entities.Employee", b =>
                {
                    b.Navigation("Order_handlers");
                });

            modelBuilder.Entity("Lib.Entities.Employee_type", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Lib.Entities.Order", b =>
                {
                    b.Navigation("Order_handler");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Lib.Entities.Package", b =>
                {
                    b.Navigation("Durations");
                });

            modelBuilder.Entity("Lib.Entities.Product", b =>
                {
                    b.Navigation("Stories");
                });

            modelBuilder.Entity("Lib.Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Lib.Entities.TP_contractor", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lib.Entities.User", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("TP_contractors");
                });
#pragma warning restore 612, 618
        }
    }
}
