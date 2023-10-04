namespace MyView.Models
{
    public class Satis
    {
        public int SatisID { get; set; }
        public DateTime SatisTarihi { get; set; }
        public int UrunID { get; set; }
        public Urun Urun { get; set; }
        public ICollection<SatisDetay> SatisDetaylari { get; set; }
    }

    public class SatisDetay
    {
        public int SatisDetayID { get; set; }
        public int Miktar { get; set; }

        // Her SatisDetay bir Satis ile ilişkilidir.
        public int SatisID { get; set; }
        public Satis Satis { get; set; }

        // Her SatisDetay bir Urun ile ilişkilidir.
        public int UrunID { get; set; }
        public Urun Urun { get; set; }
    }

    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }

        // Bir Urun, birden çok SatisDetay'a sahiptir.
        public ICollection<SatisDetay> SatisDetaylari { get; set; }
    }

    public class ECommerceData
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int SatisID { get; set; }

        public DateTime SatisTarihi { get; set; }
        public int SatisDetayID { get; set; }

        public int Miktar { get; set; }
    }
}
