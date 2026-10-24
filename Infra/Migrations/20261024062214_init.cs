using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencyes",
                columns: table => new
                {
                    DispatchAgencyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchAgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencyes", x => x.DispatchAgencyID);
                });

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    MainCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategorynName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.MainCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "serviceProvidersCompany",
                columns: table => new
                {
                    ServiceProviderCompanyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceProvidersCompany", x => x.ServiceProviderCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_subCategories_MainCategories_MainCategoryID",
                        column: x => x.MainCategoryID,
                        principalTable: "MainCategories",
                        principalColumn: "MainCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    OrderID1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Orders_OrderID1",
                        column: x => x.OrderID1,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Orders_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    ServiceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Charges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    ChargesType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_services_subCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "subCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDispatches",
                columns: table => new
                {
                    OrderDispatchID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReachDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocketNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    DispatchAgencyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDispatches", x => x.OrderDispatchID);
                    table.ForeignKey(
                        name: "FK_orderDispatches_Agencyes_DispatchAgencyID",
                        column: x => x.DispatchAgencyID,
                        principalTable: "Agencyes",
                        principalColumn: "DispatchAgencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDispatches_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderPayment",
                columns: table => new
                {
                    OrderPaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderPayment", x => x.OrderPaymentID);
                    table.ForeignKey(
                        name: "FK_orderPayment_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicePhotos",
                columns: table => new
                {
                    ServicePhotosID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicePhotos", x => x.ServicePhotosID);
                    table.ForeignKey(
                        name: "FK_servicePhotos_services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "MainCategoryID", "MainCategorynName" },
                values: new object[,]
                {
                    { 1L, "Electrical Services" },
                    { 2L, "Plumbing" }
                });

            migrationBuilder.InsertData(
                table: "serviceProvidersCompany",
                columns: new[] { "ServiceProviderCompanyID", "Address", "EmailId", "MobileNo", "Password", "ServiceProviderCompanyName", "WebsiteUrl" },
                values: new object[] { 1L, "Akurdi pune", "contact@gmail.com", "8963251456", "abcd", "Ri-Tech", "https://ritechpune.com" });

            migrationBuilder.InsertData(
                table: "subCategories",
                columns: new[] { "SubCategoryID", "MainCategoryID", "SubCategoryName" },
                values: new object[,]
                {
                    { 1L, 1L, "Pipe Leakage Repair" },
                    { 2L, 2L, "Fan Installation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceID",
                table: "OrderDetails",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDispatches_DispatchAgencyID",
                table: "orderDispatches",
                column: "DispatchAgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDispatches_OrderID",
                table: "orderDispatches",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderPayment_OrderID",
                table: "orderPayment",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderID1",
                table: "Orders",
                column: "OrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_servicePhotos_ServiceID",
                table: "servicePhotos",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_services_SubCategoryID",
                table: "services",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_subCategories_MainCategoryID",
                table: "subCategories",
                column: "MainCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "orderDispatches");

            migrationBuilder.DropTable(
                name: "orderPayment");

            migrationBuilder.DropTable(
                name: "servicePhotos");

            migrationBuilder.DropTable(
                name: "serviceProvidersCompany");

            migrationBuilder.DropTable(
                name: "Agencyes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "subCategories");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}
