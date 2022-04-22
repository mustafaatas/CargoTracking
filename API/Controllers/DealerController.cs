using API.DTOs.DealerDto;
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
    public class DealerController : BaseApiController
    {
        private readonly DataContext context;

        public DealerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DealerDto>>> GetDealers()
        {
            var dealerList = await context.Dealers.ToListAsync();
            var dealerListDto = dealerList.Select(i => new DealerDto
            {
                Id = i.Id,
                ZIPCode = i.ZIPCode,
                Adress = i.Adress
            });

            return dealerListDto.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealerDto>> GetDealer(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            if (dealer == null) return NotFound();

            var takenDealer = new DealerDto
            {
                Id = dealer.Id,
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode
            };

            return takenDealer;
        }

        [HttpPost]
        public async Task<ActionResult<DealerDto>> CreateDealer(DealerCreateDto dealer)
        {
            var createdDealer = new Dealer
            {              
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode
            };

            context.Dealers.Add(createdDealer);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = createdDealer.Id }, dealer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDto>> UpdateDealer(int id, DealerUpdateDto dealer)
        {
            var updatedDealer = await context.Dealers.FindAsync(id);
            updatedDealer.Adress = dealer.Adress;

            if (id != dealer.Id) return BadRequest();

            try
            {
                context.Entry(dealer).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DealerDto>> DeleteDealer(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            if (dealer == null) return NotFound();

            var deletedDealer = new DealerDto
            {
                Id = dealer.Id,
                ZIPCode = dealer.ZIPCode
            };

            context.Dealers.Remove(dealer);
            await context.SaveChangesAsync();

            return deletedDealer;
        }
    }
}
