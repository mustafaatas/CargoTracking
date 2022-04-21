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

    public class DealerController : BaseApiController
    {
        private readonly DataContext context;

        public DealerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dealer>>> GetDealers()
        {
            return await context.Dealers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            if (dealer == null) return NotFound();

            return dealer;
        }

        [HttpPost]
        public async Task<ActionResult<Dealer>> CreateDealer(Dealer dealer)
        {
            context.Dealers.Add(dealer);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = dealer.Id }, dealer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dealer>> UpdateDealer(int id, Dealer dealer)
        {
            if (id != dealer.Id) return BadRequest();

            context.Entry(dealer).State = EntityState.Modified;

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
        public async Task<ActionResult<Dealer>> DeleteDealer(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            if (dealer == null) return NotFound();

            context.Dealers.Remove(dealer);
            await context.SaveChangesAsync();

            return dealer;
        }
    }
}
