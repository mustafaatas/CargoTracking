using API.DTOs.AdressDto;
using API.DTOs.AdressDTO;
using AutoMapper.Internal.Mappers;
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
    public class AdressController : BaseApiController
    {
        private readonly DataContext context;

        public AdressController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdressDto>>> GetAdresses()
        {
            var adressList = await context.Adresses.ToListAsync();
            var adresListDto = adressList.Select(i => new AdressDto
            {
                Id = i.Id,
                City = i.City,
                District = i.District,
                Description = i.Description,
                ZIPCode = i.ZIPCode
            });

            return adresListDto.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdressDto>> GetAdress(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null) return NotFound();

            var takenAdress = new AdressDto
            {
                City = adress.City,
                District = adress.District,
                Description = adress.Description,
                ZIPCode = adress.ZIPCode
            };

            return takenAdress;
        }

        [HttpPost]
        public async Task<ActionResult<AdressDto>> CreateAdress(AdressCreateDto adress)
        {
            var createdAdress = new Adress
            {
                City = adress.City,
                District = adress.District,
                Description = adress.Description,
                ZIPCode = adress.ZIPCode
            };

            context.Adresses.Add(createdAdress);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = createdAdress.Id }, adress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdressDto>> UpdateAdress(int id, AdressUpdateDto adress)
        {
            var updatedAdress = await context.Adresses.FindAsync(id);
            updatedAdress.Description = adress.Description;

            if (id != updatedAdress.Id) return BadRequest();

            try
            {
                context.Entry(updatedAdress).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AdressDto>> DeleteAdress(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null) return NotFound();

            var deletedAdress = new AdressDto
            {
                City = adress.City,
                District = adress.District,
                ZIPCode = adress.ZIPCode
            };

            context.Adresses.Remove(adress);
            await context.SaveChangesAsync();

            return deletedAdress;
        }
    }
}
