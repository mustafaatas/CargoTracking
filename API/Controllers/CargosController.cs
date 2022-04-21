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
    public class CargosController : BaseApiController
    {
        private readonly DataContext context;

        public CargosController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cargo>>> GetCargos()
        {
            return await context.Cargos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await context.Cargos.FindAsync(id);
            if (cargo == null) return NotFound();

            return cargo;
        }

        [HttpPost]
        public async Task<ActionResult<Cargo>> CreateCargo(Cargo cargo)
        {
            context.Cargos.Add(cargo);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = cargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cargo>> UpdateCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id) return BadRequest();

            context.Entry(cargo).State = EntityState.Modified;

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
        public async Task<ActionResult<Cargo>> DeleteCargo(int id)
        {
            var cargo = await context.Cargos.FindAsync(id);
            if (cargo == null) return NotFound();

            context.Cargos.Remove(cargo);
            await context.SaveChangesAsync();

            return cargo;
        }
    }
}
