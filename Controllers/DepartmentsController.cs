using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        CompanyContext dbcontext = new CompanyContext();
        [HttpGet]
        public ActionResult GetAll()
        {
            var departments = dbcontext.Departments.ToList();
            return Ok(departments);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var departments = dbcontext.Departments.Find(id);
            if (departments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(departments);
            }
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            var emp = dbcontext.Add(department);
            dbcontext.SaveChanges();
            return CreatedAtAction("GetById",
                new { department.Id },
                new { massege = "successfly Created" });
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, Department departmentFromUser)
        {
            if (id != departmentFromUser.Id)
            {
                return BadRequest();
            }
            else
            {
                var departmentFromDB = dbcontext.Departments.Find(id);
                if (departmentFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    departmentFromDB.Location= departmentFromUser.Location;
                    departmentFromDB.Name = departmentFromUser.Name;
                    dbcontext.SaveChanges();
                    return NoContent();
                }
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var departmentFromDB = dbcontext.Departments.Find(id);
            if (departmentFromDB == null)
            {
                return NotFound();
            }
            else
            {
                dbcontext.Departments.Remove(departmentFromDB);
                dbcontext.SaveChanges();
                return NoContent();
            }

        }

    }
}
