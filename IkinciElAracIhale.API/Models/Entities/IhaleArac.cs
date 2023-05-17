namespace IkinciElAracIhale.API.Models.Entities
{
    public class IhaleArac
    {
        public int IhaleAracID { get; set; }
        public int IhaleID { get; set; }
        public int AracID { get; set; }
        public decimal IhaleBaslangicFiyati { get; set; }
        public decimal MaxAlimFiyati { get; set; }
    }
}
