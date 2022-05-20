using API.DTOs.AdressDto;
using API.DTOs.AdressDTO;
using AutoMapper.Internal.Mappers;
using Business.Abstract;
using Business.Concrete;
using Business.DAOs.AdressDao;
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
        private readonly AdressService _adressService;

        public AdressController(AdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdressDto>>> GetAdresses()
        {
            var adressList = await _adressService.GetListAsync();
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
            var adress = await _adressService.GetById(id);
            if (adress == null) return NotFound();

            var takenAdress = new AdressDto
            {
                Id = adress.Id,
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
            var createdAdress = new AdressCreateDao
            {
                City = adress.City,
                District = adress.District,
                Description = adress.Description,
                ZIPCode = adress.ZIPCode
            };

            await _adressService.Add(createdAdress);
            return CreatedAtAction("GetAdress", new { id = createdAdress.Id }, adress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdressDto>> UpdateAdress(int id, AdressUpdateDto adress)
        {
            var adressDealer = new AdressUpdateDao
            {
                Id = id,
                Description = adress.Description
            };

            if (id != adressDealer.Id) return BadRequest();

            try
            {
                await _adressService.Update(adressDealer);
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
            var adress = await _adressService.Delete(id);
            if (adress == null) return NotFound();

            var deletedAdress = new AdressDto();
            return deletedAdress;
        }
    }
}
