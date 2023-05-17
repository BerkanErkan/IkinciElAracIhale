using System;

namespace IkinciElAracIhale.API.Models.Entities
{
    public class Arac
    {
        public int AracID { get; set; }
        public DateTime KaydedilmeZamanı { get; set; }
        public int KullaniciID { get; set; }
        public int AracModelID { get; set; }
        public int AracMarkaID { get; set; }
        public bool? KurumsalMİ { get; set; }
        public decimal AracFiyati { get; set; }
        public string Plaka { get; set; }
    }
}
