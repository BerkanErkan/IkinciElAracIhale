namespace IkinciElAracIhale.API.Models.Entities
{
    public class IhaleFiyat
    {
        public int IhaleFiyatID { get; set; }

        public decimal Fiyat { get; set; }

        public int KullaniciID { get; set; }

        public int IhaleAracID { get; set; }


    }
}
