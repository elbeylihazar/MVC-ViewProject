using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyView.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunID);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    SatisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.SatisID);
                    table.ForeignKey(
                        name: "FK_Satislar_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatisDetaylari",
                columns: table => new
                {
                    SatisDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    SatisID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisDetaylari", x => x.SatisDetayID);
                    table.ForeignKey(
                        name: "FK_SatisDetaylari_Satislar_SatisID",
                        column: x => x.SatisID,
                        principalTable: "Satislar",
                        principalColumn: "SatisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisDetaylari_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "UrunID", "UrunAdi" },
                values: new object[] { 1, "Laptop" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "UrunID", "UrunAdi" },
                values: new object[] { 2, "Akıllı Telefon" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "UrunID", "UrunAdi" },
                values: new object[] { 3, "Tablet" });

            migrationBuilder.InsertData(
                table: "Satislar",
                columns: new[] { "SatisID", "SatisTarihi", "UrunID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2023, 9, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2023, 9, 12, 9, 15, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2023, 9, 13, 16, 45, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "SatisDetaylari",
                columns: new[] { "SatisDetayID", "Miktar", "SatisID", "UrunID" },
                values: new object[,]
                {
                    { 1, 3, 1, 1 },
                    { 2, 2, 2, 2 },
                    { 3, 1, 3, 1 },
                    { 4, 4, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetaylari_SatisID",
                table: "SatisDetaylari",
                column: "SatisID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetaylari_UrunID",
                table: "SatisDetaylari",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_UrunID",
                table: "Satislar",
                column: "UrunID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatisDetaylari");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
