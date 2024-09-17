using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        CompanyContext dbcontext = new CompanyContext();
        [HttpGet]
        public ActionResult GetAll()
        { 
            var employees = dbcontext.Employees.ToList();
            return Ok(employees);
        } 
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var employee = dbcontext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(employee);
            }
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
           var emp = dbcontext.Add(employee);
            dbcontext.SaveChanges();
            return CreatedAtAction("GetById",
                new { employee.Id}, 
                new { massege = "successfly Created" });
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id,Employee employeeFromUser)
        {
            if (id != employeeFromUser.Id)
            {
                return BadRequest();
            }
            else
            { 
            var employeFromDB = dbcontext.Employees.Find(id);
                if (employeFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    employeFromDB.Salary = employeeFromUser.Salary;
                    employeFromDB.Name = employeeFromUser.Name;
                    dbcontext.SaveChanges();
                      return NoContent();
                   
                }
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id) 
        {
            var employeeEromDb = dbcontext.Employees.Find(id);
            if (employeeEromDb == null)
            {
                return NotFound();
            }
            else
            {
                dbcontext.Employees.Remove(employeeEromDb);
                dbcontext.SaveChanges();
                return NoContent();
            }

        }


    }
}
