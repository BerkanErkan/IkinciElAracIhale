using IkinciElAracIhale.API.DTO;
using IkinciElAracIhale.API.Models.Entities;
using IkinciElAracIhale.API.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using IkinciElAracIhale.API.Models.VM;

namespace IkinciElAracIhale.API.DAL
{
    public class IhaleDAL
    {
        readonly MyContext _context;
        public IhaleDAL(MyContext context)
        {
            _context = context;
        }
        public async Task<List<IhaleDTO>> Ihalelerim(int kullaniciID)
        {
            var result = await (from i in _context.Ihale
                                join iS in _context.IhaleStatu on i.IhaleStatuID equals iS.IhaleStatuID
                                join k in _context.Kullanici on i.KullaniciID equals k.KullaniciID
                                where i.KullaniciID== kullaniciID
                                select new IhaleDTO()
                                {
                                     IhaleID=i.IhaleID,
                                     IhaleAdi=i.IhaleAdi,
                                     IhaleBaslangicTarihi=i.IhaleBaslangicTarihi,
                                     IhaleBitisTarihi=i.IhaleBitisTarihi,
                                     KaydedenKullanici= k.KullaniciAdi,
                                     KaydetmeZamani= i.KaydetmeZamani,
                                     IhaleStatuAdi=iS.IhaleStatuAdi,
                                     KurumsalMi = i.KurumsalMi
                                }).ToListAsync();

            return result;


        }
        public async Task<List<IhaleDTO>> ButunIhaleler(int rolID)
        {
            List<IhaleDTO> result =null;
            if (rolID == 2 || rolID == 3)
            {
                result = await (from i in _context.Ihale
                                    join iS in _context.IhaleStatu on i.IhaleStatuID equals iS.IhaleStatuID
                                    join k in _context.Kullanici on i.KullaniciID equals k.KullaniciID
                                    select new IhaleDTO()
                                    {
                                        IhaleID = i.IhaleID,
                                        IhaleAdi = i.IhaleAdi,
                                        IhaleBaslangicTarihi = i.IhaleBaslangicTarihi,
                                        IhaleBitisTarihi = i.IhaleBitisTarihi,
                                        KaydedenKullanici = k.KullaniciAdi,
                                        KaydetmeZamani = i.KaydetmeZamani,
                                        IhaleStatuAdi = iS.IhaleStatuAdi,
                                        KurumsalMi = i.KurumsalMi
                                    }).ToListAsync();
            }
            else
            {
                result = await (from i in _context.Ihale
                                    join iS in _context.IhaleStatu on i.IhaleStatuID equals iS.IhaleStatuID
                                    join k in _context.Kullanici on i.KullaniciID equals k.KullaniciID
                                    where i.KurumsalMi==false
                                select new IhaleDTO()
                                {
                                    IhaleID = i.IhaleID,
                                    IhaleAdi = i.IhaleAdi,
                                    IhaleBaslangicTarihi = i.IhaleBaslangicTarihi,
                                    IhaleBitisTarihi = i.IhaleBitisTarihi,
                                    KaydedenKullanici = k.KullaniciAdi,
                                    KaydetmeZamani = i.KaydetmeZamani,
                                    IhaleStatuAdi = iS.IhaleStatuAdi,
                                    KurumsalMi = i.KurumsalMi
                                }).ToListAsync();

            }

            


            

            return result;


        }
        public async Task<IhaleDTO> IhaleninBilgisi(int ihaleID)
        {
            var result = await (from i in _context.Ihale
                                join iS in _context.IhaleStatu on i.IhaleStatuID equals iS.IhaleStatuID
                                join k in _context.Kullanici on i.KullaniciID equals k.KullaniciID
                                //join ia in _context.IhaleArac on i.IhaleID equals ia.IhaleID
                                where i.IhaleID == ihaleID
                                select new IhaleDTO()
                                {
                                    IhaleID = i.IhaleID,
                                    IhaleAdi = i.IhaleAdi,
                                    IhaleBaslangicTarihi = i.IhaleBaslangicTarihi,
                                    IhaleBitisTarihi = i.IhaleBitisTarihi,
                                    KaydedenKullanici = k.KullaniciAdi,
                                    KaydetmeZamani = i.KaydetmeZamani,
                                    IhaleStatuAdi = iS.IhaleStatuAdi,
                                    KurumsalMi=i.KurumsalMi,
                                    IhaleStatuID=i.IhaleStatuID
                                    

                                }).FirstOrDefaultAsync();


            result.IhaleAracDTOs = (from i in _context.Ihale
                                join iA in _context.IhaleArac on i.IhaleID equals iA.IhaleID
                                join a in _context.Arac on iA.AracID equals a.AracID
                                join m in _context.AracModel on a.AracModelID equals m.AracModelID
                                join ma in _context.AracMarka on a.AracModelID equals ma.AracMarkaID
                                join k in _context.Kullanici on a.KullaniciID equals k.KullaniciID
                                where i.IhaleID == ihaleID
                                select new IhaleAracDTO()
                                {
                                     IhaleAracID=iA.IhaleAracID,
                                     IhaleID=i.IhaleID,
                                     AracID=iA.AracID,
                                     IhaleBaslangicFiyati=iA.IhaleBaslangicFiyati,
                                     MaxAlimFiyati= iA.MaxAlimFiyati,
                                     AracMarkaID=ma.AracMarkaID,
                                     AracMarkaAdi=ma.AracMarkaAdi,
                                     AracModelID=m.AracModelID,
                                     AracModelAdi=m.AracModelAdi,
                                     KurumsalMi=a.KurumsalMİ,
                                     KaydedenKullanici=k.KullaniciAdi,
                                     KaydedilmeZamanı=a.KaydedilmeZamanı
                                      
                                }).ToList();



            return result;


        }
        public async Task<IhaleAracDTO> IhaleAracBilgisi(int aracID)
        {
            var result = await (from a in _context.Arac
                                join m in _context.AracModel on a.AracModelID equals m.AracModelID
                                join ma in _context.AracMarka on a.AracModelID equals ma.AracMarkaID
                                join k in _context.Kullanici on a.KullaniciID equals k.KullaniciID
                                where a.AracID == aracID
                                select new IhaleAracDTO()
                                {
                                    AracID=a.AracID,
                                    AracMarkaID = ma.AracMarkaID,
                                    AracMarkaAdi = ma.AracMarkaAdi,
                                    AracModelID = m.AracModelID,
                                    AracModelAdi = m.AracModelAdi,
                                    KurumsalMi = a.KurumsalMİ,
                                    KaydedenKullanici = k.KullaniciAdi,
                                    KaydedilmeZamanı = a.KaydedilmeZamanı

                                }).FirstOrDefaultAsync();




            return result;


        }

        public async Task<bool> IhaleKaydet(IhaleDTO dto)
        {
            DateTime tarihVeSaat = new DateTime(2023, 5, 15, 12, 30, 0);


            Ihale ihaleBilgisi = new Ihale()
            {
                IhaleAdi = dto.IhaleAdi,
                //IhaleBaslangicTarihi=dto.IhaleBaslangicTarihi,
                //IhaleBitisTarihi=dto.IhaleBitisTarihi,
                //IhaleBaslangicTarihi = DateTime.Now.Date,
                //IhaleBitisTarihi= DateTime.Now.Date,
                IhaleBaslangicTarihi = tarihVeSaat,
                IhaleBitisTarihi= tarihVeSaat,
                KurumsalMi = dto.KurumsalMi,
                 IhaleStatuID= dto.IhaleStatuID,
                //KaydetmeZamani= dto.KaydetmeZamani,
                KaydetmeZamani = tarihVeSaat,
                KullaniciID =dto.KullaniciID
                 
            };
             _context.Ihale.Add(ihaleBilgisi);
            var ihaleKaydiYapildiMi=  _context.SaveChanges()>0;


            
            foreach (var item in dto.IhaleAracDTOs)
            {

                _context.IhaleArac.Add(new IhaleArac()
                {
                    IhaleID = ihaleBilgisi.IhaleID,
                    AracID = item.AracID,
                    IhaleBaslangicFiyati= item.IhaleBaslangicFiyati,
                    MaxAlimFiyati= item.MaxAlimFiyati

                });
                _context.SaveChanges();

            }


            return ihaleKaydiYapildiMi;


        }

        public async Task<bool> IhaleGuncelle(IhaleDTO dto)
        {
            for (int i = 0; i < dto.IhaleAracDTOs.Count; i++)
            {

                if (dto.IhaleAracDTOs[i].IhaleAracID != 0)
                {
                    //int iD = Convert.ToInt32(dto.IhaleAracDTOs[i].IhaleAracID);

                    IhaleArac ihaleArac = await _context.IhaleArac.SingleOrDefaultAsync(a => a.IhaleAracID == dto.IhaleAracDTOs[i].IhaleAracID);

                    ihaleArac.IhaleBaslangicFiyati = dto.IhaleAracDTOs[i].IhaleBaslangicFiyati;
                    ihaleArac.MaxAlimFiyati = dto.IhaleAracDTOs[i].MaxAlimFiyati;


                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.IhaleArac.Add(new IhaleArac()
                    {
                        IhaleID = dto.IhaleID,
                        AracID = dto.IhaleAracDTOs[i].AracID,
                        IhaleBaslangicFiyati = dto.IhaleAracDTOs[i].IhaleBaslangicFiyati,
                        MaxAlimFiyati = dto.IhaleAracDTOs[i].MaxAlimFiyati

                    });
                    _context.SaveChanges();


                }


                

            }

            Ihale ihale = await _context.Ihale.SingleOrDefaultAsync(i => i.IhaleID == dto.IhaleID);

            if (ihale==null)
            {
                return false;
            }

            ihale.IhaleAdi = dto.IhaleAdi;
            //IhaleBaslangicTarihi=dto.IhaleBaslangicTarihi,
            //IhaleBitisTarihi=dto.IhaleBitisTarihi,
            //IhaleBaslangicTarihi = DateTime.Now.Date,
            //IhaleBitisTarihi= DateTime.Now.Date,
            //ihale.IhaleBaslangicTarihi = tarihVeSaat;
            //ihale.IhaleBitisTarihi = tarihVeSaat;
            ihale.KurumsalMi = dto.KurumsalMi;
            ihale.IhaleStatuID = dto.IhaleStatuID;
            ihale.KaydetmeZamani = dto.KaydetmeZamani;
            ihale.KullaniciID = dto.KullaniciID;



            //_context.Ihale.Add(ihaleBilgisi);
            //var ihaleKaydiYapildiMi = await _context.SaveChangesAsync() > 0;



            


            return await _context.SaveChangesAsync()>0;


        }
        public async Task<IhaleFiyatDTO> AracTeklifListesi(int ihaleAracID)
        {
            var result = await (from f in _context.IhaleFiyat
                                join k in _context.Kullanici on f.KullaniciID equals k.KullaniciID
                                join ia in _context.IhaleArac on f.IhaleAracID equals ia.IhaleAracID
                                join a in _context.Arac on ia.AracID equals a.AracID
                                join m in _context.AracModel on a.AracModelID equals m.AracModelID
                                join ma in _context.AracMarka on a.AracModelID equals ma.AracMarkaID
                                where f.IhaleAracID == ihaleAracID
                                select new IhaleFiyatDTO()
                                {
                                     AracMarkaAdi=ma.AracMarkaAdi,
                                     AracModelAdi=m.AracModelAdi,
                                     Plaka=a.Plaka,
                                     IhaleFiyatID=f.IhaleFiyatID,
                                     IhaleID=ia.IhaleID


                                }).FirstOrDefaultAsync();

            result.FiyatList= await (from f in _context.IhaleFiyat
                                     join k in _context.Kullanici on f.KullaniciID equals k.KullaniciID
                                     where f.IhaleAracID == ihaleAracID
                                     select new FiyatDTO()
                                     {
                                          Fiyat=f.Fiyat,
                                          KullaniciAdi=k.KullaniciAdi

                                     }).ToListAsync();


            return result;


        }
        public async Task<bool> TeklifKaydet(FiyatDTO dto)
        {

            IhaleFiyat ihaleFiyat = new IhaleFiyat()
            {
                Fiyat=dto.Fiyat,
                KullaniciID=dto.KullaniciID,
                IhaleAracID=dto.IhaleAracID

            };
            _context.IhaleFiyat.Add(ihaleFiyat);

            return await _context.SaveChangesAsync() > 0; ;


        }

    }
}
