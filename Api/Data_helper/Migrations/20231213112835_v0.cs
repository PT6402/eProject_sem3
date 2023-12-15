using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data_helper.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAddress_store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_full = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAddress_store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbConnect_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_Letter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Security_Deposit = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConnect_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCoupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range_Connect = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCoupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbEmployee_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmployee_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail_contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSupplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTP_contractor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTP_contractor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connect_type_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Connect_type",
                        column: x => x.Connect_type_Id,
                        principalTable: "tbConnect_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Connect_type_IdId = table.Column<int>(type: "int", nullable: false),
                    Supplier_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Supplier",
                        column: x => x.Supplier_Id,
                        principalTable: "tbSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbProduct_tbConnect_type_Connect_type_IdId",
                        column: x => x.Connect_type_IdId,
                        principalTable: "tbConnect_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Employee_type_Id = table.Column<int>(type: "int", nullable: false),
                    Address_store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emp_Address_store",
                        column: x => x.Address_store_Id,
                        principalTable: "tbAddress_store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_Emp_type",
                        column: x => x.Employee_type_Id,
                        principalTable: "tbEmployee_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_User",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbDuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package_Id = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duration_Package",
                        column: x => x.Package_Id,
                        principalTable: "tbPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbStories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbStories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Stories",
                        column: x => x.Product_Id,
                        principalTable: "tbProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbDuration_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDuration_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duration_detail_Duration",
                        column: x => x.Duration_Id,
                        principalTable: "tbDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Price = table.Column<float>(type: "real", nullable: false),
                    TP_contractor_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Coupon_Id = table.Column<int>(type: "int", nullable: false),
                    Duration_detail_Id = table.Column<int>(type: "int", nullable: false),
                    Duration_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Coupon",
                        column: x => x.Coupon_Id,
                        principalTable: "tbCoupon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Duration",
                        column: x => x.Duration_Id,
                        principalTable: "tbDuration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Duration_detail",
                        column: x => x.Duration_detail_Id,
                        principalTable: "tbDuration_detail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_TP_contractor",
                        column: x => x.TP_contractor_Id,
                        principalTable: "tbTP_contractor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Method_Payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Order",
                        column: x => x.Order_Id,
                        principalTable: "tbOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbDuration_Package_Id",
                table: "tbDuration",
                column: "Package_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbDuration_detail_Duration_Id",
                table: "tbDuration_detail",
                column: "Duration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbEmployee_Address_store_Id",
                table: "tbEmployee",
                column: "Address_store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbEmployee_Employee_type_Id",
                table: "tbEmployee",
                column: "Employee_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbEmployee_UserId",
                table: "tbEmployee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_Coupon_Id",
                table: "tbOrders",
                column: "Coupon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_Duration_detail_Id",
                table: "tbOrders",
                column: "Duration_detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_Duration_Id",
                table: "tbOrders",
                column: "Duration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders",
                column: "TP_contractor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbPackage_Connect_type_Id",
                table: "tbPackage",
                column: "Connect_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbPayment_Order_Id",
                table: "tbPayment",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduct_Connect_type_IdId",
                table: "tbProduct",
                column: "Connect_type_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduct_Supplier_Id",
                table: "tbProduct",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbStories_Product_Id",
                table: "tbStories",
                column: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbEmployee");

            migrationBuilder.DropTable(
                name: "tbPayment");

            migrationBuilder.DropTable(
                name: "tbStories");

            migrationBuilder.DropTable(
                name: "tbAddress_store");

            migrationBuilder.DropTable(
                name: "tbEmployee_type");

            migrationBuilder.DropTable(
                name: "tbUser");

            migrationBuilder.DropTable(
                name: "tbOrders");

            migrationBuilder.DropTable(
                name: "tbProduct");

            migrationBuilder.DropTable(
                name: "tbCoupon");

            migrationBuilder.DropTable(
                name: "tbDuration_detail");

            migrationBuilder.DropTable(
                name: "tbTP_contractor");

            migrationBuilder.DropTable(
                name: "tbSupplier");

            migrationBuilder.DropTable(
                name: "tbDuration");

            migrationBuilder.DropTable(
                name: "tbPackage");

            migrationBuilder.DropTable(
                name: "tbConnect_type");
        }
    }
}
