using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyView.Migrations
{
    public partial class CreateECommerceDataView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
    CREATE VIEW ECommerceData AS
    SELECT
        U.UrunID AS UrunID,
        U.UrunAdi AS UrunAdi,
        S.SatisID AS SatisID,
        S.SatisTarihi AS SatisTarihi,
        SD.SatisDetayID AS SatisDetayID,
        SD.Miktar AS Miktar
    FROM Urunler U
    JOIN Satislar S ON U.UrunID = S.UrunID
    JOIN SatisDetaylari SD ON S.SatisID = SD.SatisID;


");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
