using API.DTOs.EmployeeDto;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : BaseApiController
    {
        private readonly DataContext context;

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var employeeList = await context.Employees.Include(i => i.Dealer).ToListAsync();
            var employeeListDto = employeeList.Select(i => new EmployeeDto
            {
                Id = i.Id,
                Name = i.Name,
                RoleId = i.RoleId,
                DealerId = i.DealerId,

            });
            return employeeListDto.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            var takenEmployee = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name
            };

            return takenEmployee;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeCreateDto employee)
        {
            var createdEmployee = new Employee
            {
                Name = employee.Name,
                RoleId = employee.RoleId,
                DealerId = employee.DealerId
            };

            context.Employees.Add(createdEmployee);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = createdEmployee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = await context.Employees.FindAsync(id);
            updatedEmployee.RoleId = employee.RoleId;
            updatedEmployee.DealerId = employee.DealerId;

            if (id != employee.Id) return BadRequest();

            try
            {
                await context.SaveChangesAsync();
                context.Entry(employee).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            var deletedEmployee = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name
            };

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();

            return deletedEmployee;
        }
    }
}