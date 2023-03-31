using BusinessLayer.Concrete;
using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace EPL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        TeamService<Teams> servis = new TeamService<Teams>();
     

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

            return BadRequest($"({id})'ye sahip takım bulunamadı");

        }

        [HttpPost]
        public IActionResult Add(Teams teams)
        {
            if (ModelState.IsValid)
            {
                servis.Add(teams);
                return Ok("Takım eklendi");

            }
            return BadRequest("takım eklenemedi");
        }

        [HttpPut]
        public IActionResult Update(Teams teams) 
        {

            var liste = servis.GetById(teams.TeamId);

            if (liste != null)
            {
                servis.Update(teams);
                return Ok("Takım güncellendi");
            }
            return BadRequest($"({teams.TeamId})'ye sahip takım bulunamadı");

        }


        [HttpDelete]
        public IActionResult DeleteById(int id) 
        {
            var liste = servis.GetById(id);
        
            if (liste != null)
            {
                servis.Delete(liste);
                return Ok("Takım silindi");

            }

            return BadRequest($"({id})'ye sahip takım bulunamadı");



        }




    }
}
