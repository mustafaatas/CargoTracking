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
    public class AdressController : BaseApiController
    {
        private readonly DataContext context;

        public AdressController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Adress>>> GetAdresses()
        {
            return await context.Adresses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdress(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null) return NotFound();

            return adress;
        }

        [HttpPost]
        public async Task<ActionResult<Adress>> CreateAdress(Adress adress)
        {
            context.Adresses.Add(adress);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Adress>> UpdateAdress(int id, Adress adress)
        {
            if (id != adress.Id) return BadRequest();

            context.Entry(adress).State = EntityState.Modified;

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
        public async Task<ActionResult<Adress>> DeleteAdress(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null) return NotFound();

            context.Adresses.Remove(adress);
            await context.SaveChangesAsync();

            return adress;
        }
    }
}
