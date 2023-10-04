using Microsoft.EntityFrameworkCore;
using MyView.Models;

namespace MyView.MyViewData
{
    public class DatabaseContext:DbContext

    {
        public DbSet<ECommerceData> ECommerceDataView { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetay> SatisDetaylari { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<ECommerceData>().ToView("ECommerceData").HasNoKey();


            base.OnModelCreating(modelBuilder);

            // Verilerinizi burada ekleyin
            var urun1 = new Urun {UrunID=1, UrunAdi = "Laptop" };
            var urun2 = new Urun {UrunID=2 ,UrunAdi = "Akıllı Telefon" };
            var urun3 = new Urun { UrunID=3,UrunAdi = "Tablet" };
            modelBuilder.Entity<Urun>().HasData(urun1, urun2, urun3);

            var satis1 = new Satis {SatisID=1, SatisTarihi = new DateTime(2023, 9, 10, 10, 0, 0), UrunID = urun1.UrunID };
            var satis2 = new Satis { SatisID = 2, SatisTarihi = new DateTime(2023, 9, 11, 14, 30, 0), UrunID = urun2.UrunID };
            var satis3 = new Satis { SatisID = 3, SatisTarihi = new DateTime(2023, 9, 12, 9, 15, 0), UrunID = urun1.UrunID };
            var satis4 = new Satis { SatisID = 4, SatisTarihi = new DateTime(2023, 9, 13, 16, 45, 0), UrunID = urun3.UrunID };
            modelBuilder.Entity<Satis>().HasData(satis1, satis2, satis3, satis4);

            var satisDetay1 = new SatisDetay { SatisDetayID = 1, Miktar = 3, SatisID = satis1.SatisID, UrunID = urun1.UrunID };
            var satisDetay2 = new SatisDetay { SatisDetayID = 2,Miktar = 2, SatisID = satis2.SatisID, UrunID = urun2.UrunID };
            var satisDetay3 = new SatisDetay { SatisDetayID = 3,Miktar = 1, SatisID = satis3.SatisID, UrunID = urun1.UrunID };
            var satisDetay4 = new SatisDetay { SatisDetayID = 4, Miktar = 4, SatisID = satis4.SatisID, UrunID = urun3.UrunID };
            modelBuilder.Entity<SatisDetay>().HasData(satisDetay1, satisDetay2, satisDetay3, satisDetay4);

                 modelBuilder.Entity<SatisDetay>()
            .HasOne(sd => sd.Urun)              // SatisDetay'daki Urun navigasyonu
           .WithMany(u => u.SatisDetaylari)    // Urun'daki SatisDetaylari koleksiyonu
           .HasForeignKey(sd => sd.UrunID)    // SatisDetay'daki UrunID
           .OnDelete(DeleteBehavior.Restrict); // Silmeyi engellemek için
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DatabaseConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
