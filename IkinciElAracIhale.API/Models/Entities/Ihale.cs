using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace IkinciElAracIhale.API.Models.Entities
{
    public class Ihale
    {
        public int IhaleID { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime IhaleBaslangicTarihi { get; set; }
        public DateTime IhaleBitisTarihi { get; set; }

        public bool KurumsalMi { get; set; }

        public int KullaniciID { get; set; }

        public int IhaleStatuID { get; set; }

        public DateTime KaydetmeZamani { get; set; }



    }
}
