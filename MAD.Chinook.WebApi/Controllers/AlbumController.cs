using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{

    [Route("api/Album")]
    public class AlbumController : BaseController
    {
        public AlbumController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Albums.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Albums.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Albums.Insert(album));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Album album)
        {
            if (ModelState.IsValid && _unit.Albums.Update(album) && album.AlbumId > 0)
                return Ok(new { Message = "The album is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Albums.Delete(new Album { AlbumId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Albums.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Albums.PagedList(startRecord, endRecord));
        }


    }
}