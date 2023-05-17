using IkinciElAracIhale.API.DTO;
using IkinciElAracIhale.API.Models;
using IkinciElAracIhale.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkinciElAracIhale.API.DAL
{
    public class KullaniciDAL
    {
        readonly MyContext _context;
        public KullaniciDAL(MyContext context)
        {
            _context = context;
        }
        public async Task<KullaniciDTO> KullaniciKontrolu(Kullanici kullanici)
        {
            var result = await (from k in _context.Kullanici
                                join r in _context.Rol on k.RolID equals r.RolID
                                where k.Mail == kullanici.Mail && k.Sifre == kullanici.Sifre && k.KullaniciOnaylimi == true && k.KullaniciAktifmi== true
                                select new KullaniciDTO()
                                {
                                     KullaniciID=k.KullaniciID,
                                     AdVeSoyad=k.AdVeSoyad,
                                     KullaniciAdi=k.KullaniciAdi,
                                     Mail= k.Mail,
                                     RolAdi=r.RolAdi,
                                     RolID=k.RolID
                                }).FirstOrDefaultAsync();

            return result;


        }
    }
}
