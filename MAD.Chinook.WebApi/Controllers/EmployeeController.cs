using MAD.Chinook.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Chinook.Models;

namespace MAD.Chinook.WebApi.Controllers
{

    [Route("api/Employee")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IUnitOfWork unit) : base(unit)
        {
        }


        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Employees.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Employees.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Employees.Insert(employee));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (ModelState.IsValid && _unit.Employees.Update(employee) && employee.EmployeeId > 0)
                return Ok(new { Message = "The employee is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Employees.Delete(new Employee { EmployeeId = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Employees.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Employees.PagedList(startRecord, endRecord));
        }



    }
}