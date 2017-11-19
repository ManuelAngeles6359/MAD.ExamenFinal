using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{
    [Route("api/Playlist")]
    public class PlaylistRepositoryController : BaseController
    {
        public PlaylistRepositoryController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Playlists.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Playlists.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Playlist playlist)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Playlists.Insert(playlist));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Playlist playlist)
        {
            if (ModelState.IsValid && _unit.Playlists.Update(playlist) && playlist.PlaylistId > 0)
                return Ok(new { Message = "The playlist is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Playlists.Delete(new Playlist { PlaylistId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Playlists.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Playlists.PagedList(startRecord, endRecord));
        }

    }
}