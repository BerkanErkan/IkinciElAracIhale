namespace IkinciElAracIhale.API.Models.Entities
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; }

        public string AdVeSoyad { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public bool KullaniciAktifmi { get; set; }

        public string Sifre { get; set; }

        public int ToplamIhaleAracSayisi { get; set; }

        public bool KullaniciOnaylimi { get; set; }

        public bool KVKKTiklimi { get; set; }

        public int RolID { get; set; }

        public int PaketID { get; set; }

        public int SirketBilgisiID { get; set; }

        public bool? KurumsalMi { get; set; }
    }
}
