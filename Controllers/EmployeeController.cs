using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.EmployeeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly dbContext db = new dbContext();
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await db.Employees.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee e)
        {
            db.Employees.Add(e);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id,Employee e)
        {
            db.Entry(e).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            db.Employees.Remove(db.Employees.Find(id));
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Employee e=await db.Employees.FindAsync(id);
            return Ok(e);
        }
    }
}
