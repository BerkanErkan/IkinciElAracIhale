using IkinciElAracIhale.API.DAL;
using IkinciElAracIhale.API.DTO;
using IkinciElAracIhale.API.Models.Entities;
using IkinciElAracIhale.API.Models.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IkinciElAracIhale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IhaleController : ControllerBase
    {

        private readonly IhaleDAL _dal;
        public IhaleController(IhaleDAL dal)
        {
            _dal = dal;
        }
        [HttpPost]
        public async Task<IActionResult> GetIhalelerim([FromBody] int kullaniciID)
        {
            
            try
            {

                var ihalelerim = await _dal.Ihalelerim(kullaniciID);
                return ihalelerim != null ? Ok(ihalelerim) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }
        [HttpPost("ihaleler")]
        public async Task<IActionResult> ButunIhaleler([FromBody] int rolID)
        {

            try
            {

                var ihaleler = await _dal.ButunIhaleler(rolID);
                return ihaleler != null ? Ok(ihaleler) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }
        [HttpPost("aracbilgi")]
        public async Task<IActionResult> AracBilgilerim([FromBody] int aracID)
        {

            try
            {

                var ihaleArac = await _dal.IhaleAracBilgisi(aracID);
                return ihaleArac != null ? Ok(ihaleArac) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }

        [HttpPost("ihalekaydet")]
        public async Task<IActionResult> IhaleKaydet([FromBody] IhaleDTO dto)
        {

            try
            {

                var kayitOldumu = await _dal.IhaleKaydet(dto);
                return kayitOldumu != true ? Ok(kayitOldumu) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }

        [HttpPost("ihalebilgi")]
        public async Task<IActionResult> IhaleBilgisi([FromBody] int ihaleID)
        {

            try
            {

                var ihale = await _dal.IhaleninBilgisi(ihaleID);
                return ihale != null ? Ok(ihale) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }
        [HttpPost("ihaleguncelle")]
        public async Task<IActionResult> IhaleGuncelle([FromBody] IhaleDTO dto)
        {

            try
            {

                var kayitOldumu = await _dal.IhaleGuncelle(dto);
                return kayitOldumu != true ? Ok(kayitOldumu) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }

        [HttpPost("aracfiyat")]
        public async Task<IActionResult> AracTeklif([FromBody] int ihaleAracID)
        {

            try
            {

                var ihale = await _dal.AracTeklifListesi(ihaleAracID);
                return ihale != null ? Ok(ihale) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }
        [HttpPost("teklifkaydet")]
        public async Task<IActionResult> TeklifKaydet([FromBody] FiyatDTO dto)
        {

            try
            {

                var kayitOldumu = await _dal.TeklifKaydet(dto);
                return kayitOldumu == true ? Ok(kayitOldumu) : BadRequest();
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);


        }
    }
}
