using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{

    [Route("api/Artist")]
    public class ArtistController : BaseController
    {
        public ArtistController(IUnitOfWork unit) : base(unit)
        {
        }


        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Artists.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Artists.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Artist artist)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Artists.Insert(artist));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Artist artist)
        {
            if (ModelState.IsValid && _unit.Artists.Update(artist) && artist.ArtistId > 0)
                return Ok(new { Message = "The artist is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Artists.Delete(new Artist { ArtistId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Artists.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Artists.PagedList(startRecord, endRecord));
        }


    }
}