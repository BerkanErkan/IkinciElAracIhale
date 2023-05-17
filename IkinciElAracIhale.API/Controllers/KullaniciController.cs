using IkinciElAracIhale.API.DAL;
using IkinciElAracIhale.API.DTO;
using IkinciElAracIhale.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IkinciElAracIhale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly KullaniciDAL _dal;
        public KullaniciController(KullaniciDAL dal)
        {
            _dal = dal;
        }


        [HttpPost]
        public async Task<IActionResult> KullaniciKontrolu([FromBody] Kullanici kullanici)
        {


            try
            {

                KullaniciDTO kullaniciDTO = await _dal.KullaniciKontrolu(kullanici);
                //return new StatusCodeResult(201);
                return Ok(kullaniciDTO);
            }
            catch (System.Exception ex)
            {
                //todo log al

            }
            return new StatusCodeResult(400);
        }




    }
}
