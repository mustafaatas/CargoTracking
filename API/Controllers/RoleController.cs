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
    public class RoleController : BaseApiController
    {
        private readonly DataContext context;

        public RoleController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            return await context.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null) return NotFound();

            return role;
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            context.Roles.Add(role);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> UpdateRole(int id, Role role)
        {
            if(id != role.Id) return BadRequest();

            context.Entry(role).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null) return NotFound();

            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return role;
        }
    }
}
