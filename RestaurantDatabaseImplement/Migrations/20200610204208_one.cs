using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantDatabaseImplement.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierFIO = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishFoods_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeName = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    Free = table.Column<int>(nullable: false),
                    Reserved = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeFoods_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Inres = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestFoods_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishFoods_DishId",
                table: "DishFoods",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishFoods_FoodId",
                table: "DishFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeFoods_FoodId",
                table: "FridgeFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeFoods_FridgeId",
                table: "FridgeFoods",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_SupplierId",
                table: "Fridges",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFoods_FoodId",
                table: "RequestFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFoods_RequestId",
                table: "RequestFoods",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SupplierId",
                table: "Requests",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishFoods");

            migrationBuilder.DropTable(
                name: "FridgeFoods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RequestFoods");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
