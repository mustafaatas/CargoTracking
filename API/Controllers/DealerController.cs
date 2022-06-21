using API.DTOs.DealerDto;
using Business.Abstract;
using Business.DAOs.DealerDao;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [Authorize(Roles = "Manager")]
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
            var dealerJSON = JsonConvert.SerializeObject(dealerListDto);
            return dealerListDto.ToList();
        }

        [Authorize(Roles = "Manager, Dealer Manager")]
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
            var createdDealerDAO = new DealerCreateDao
            {
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode
            };

            await _dealerService.Add(createdDealerDAO);
            return CreatedAtAction("GetDealer", new { id = createdDealerDAO.Id }, dealer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDto>> UpdateDealer(int id, DealerUpdateDto dealer)
        {
            //var updatedDealer = await _dealerService.GetById(id);
            //updatedDealer.Adress = dealer.Adress;
            var updatedDealer = new DealerUpdateDao
            {
                Id = id,
                Adress = dealer.Adress
            };

            if (id != dealer.Id) return BadRequest();

            try
            {
                await _dealerService.Update(updatedDealer);
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
            var dealer = await _dealerService.Delete(id);
            if (dealer == null) return NotFound();

            var deletedDealer = new DealerDto();
            return deletedDealer;
        }
    }
}