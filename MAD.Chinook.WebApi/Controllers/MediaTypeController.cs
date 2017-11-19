using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{
    [Route("api/MediaType")]
    public class MediaTypeController : BaseController
    {
        public MediaTypeController(IUnitOfWork unit) : base(unit)
        {
        }


        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.MediaTypes.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.MediaTypes.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] MediaType mediaType)
        {
            if (ModelState.IsValid)
                return Ok(_unit.MediaTypes.Insert(mediaType));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] MediaType mediaType)
        {
            if (ModelState.IsValid && _unit.MediaTypes.Update(mediaType) && mediaType.MediaTypeId > 0)
                return Ok(new { Message = "The mediaType is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.MediaTypes.Delete(new MediaType { MediaTypeId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.MediaTypes.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.MediaTypes.PagedList(startRecord, endRecord));
        }


    }
}