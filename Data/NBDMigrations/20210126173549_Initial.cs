using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDcase.Data.NBDMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NBD");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Contact = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(maxLength: 50, nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: false),
                    ProjectSite = table.Column<string>(maxLength: 255, nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "NBD",
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BidDate = table.Column<DateTime>(nullable: false),
                    BidAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    BidHours = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "NBD",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Size = table.Column<string>(maxLength: 10, nullable: false),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "NBD",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionName = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "NBD",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Size = table.Column<string>(maxLength: 10, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    InventoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materials_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalSchema: "NBD",
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Labors",
                schema: "NBD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaborType = table.Column<string>(maxLength: 50, nullable: false),
                    LaborPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    LaborCost = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    StaffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labors_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalSchema: "NBD",
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "NBD",
                table: "Bids",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BidID",
                schema: "NBD",
                table: "Inventories",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_Labors_StaffID",
                schema: "NBD",
                table: "Labors",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InventoryID",
                schema: "NBD",
                table: "Materials",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                schema: "NBD",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_BidID",
                schema: "NBD",
                table: "Staffs",
                column: "BidID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labors",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "NBD");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "NBD");
        }
    }
}
