using BusinessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EPL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        TeamService<Players> servis = new TeamService<Players>();

        [HttpGet]
        public IActionResult GetAll()
        {

            var liste = servis.GetAll();

            bool result = liste.IsNullOrEmpty();

            if (result == false)
            {
                return Ok(liste);
            }

            return BadRequest("tablo boş");
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {

            var liste = servis.GetById(id);

            if (liste != null)
            {
                return Ok(liste);
            }

            return BadRequest($"({id})'ye sahip oyuncu bulunamadı");

        }

        [HttpPost]
        public IActionResult Add(Players players)
        {
            if (ModelState.IsValid)
            {
                servis.Add(players);
                return Ok("oyuncu eklendi");

            }
            return BadRequest("oyuncu eklenemedi");
        }

        [HttpPut]
        public IActionResult Update(Players players)
        {

            var liste = servis.GetById(players.PlayerId);

            if (liste != null)
            {
                servis.Update(players);
                return Ok("oyuncu güncellendi");
            }
            return BadRequest($"({players.PlayerId})'ye sahip oyuncu bulunamadı");

        }


        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var liste = servis.GetById(id);

            if (liste != null)
            {
                servis.Delete(liste);
                return Ok("oyuncu silindi");

            }

            return BadRequest($"({id})'ye sahip oyuncu bulunamadı");

        }


    }
}
