using API.DTOs.DealerDto;
using Business.Abstract;
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
        private readonly DealerService _dealerService;

        public DealerController(DealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DealerDto>>> GetDealers()
        {
            var dealerList = await _dealerService.GetListAsync();
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
            var dealer = await _dealerService.GetById(id);
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

            // var createdDealer = new Dealer();

            await _dealerService.Add(createdDealer);
            return CreatedAtAction("GetDealer", new { id = createdDealer.Id }, dealer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDto>> UpdateDealer(int id, DealerUpdateDto dealer)
        {
            var updatedDealer = await _dealerService.GetById(id);
            updatedDealer.Adress = dealer.Adress;

            if (id != dealer.Id) return BadRequest();

            try
            {
                await _dealerService.Update(updatedDealer);
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DealerDto>> DeleteDealer(int id)
        {
            var dealer = await _dealerService.Delete(id);
            if (dealer == null) return NotFound();

            var deletedDealer = new DealerDto();
            return deletedDealer;
        }
    }
}