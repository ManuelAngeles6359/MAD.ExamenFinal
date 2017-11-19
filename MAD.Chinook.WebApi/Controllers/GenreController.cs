using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{
    [Route("api/Genre")]
    public class GenreController : BaseController
    {
        public GenreController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Genres.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Genres.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Genres.Insert(genre));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Genre genre)
        {
            if (ModelState.IsValid && _unit.Genres.Update(genre) && genre.GenreId > 0)
                return Ok(new { Message = "The genre is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Genres.Delete(new Genre { GenreId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Genres.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Genres.PagedList(startRecord, endRecord));
        }

    }
}