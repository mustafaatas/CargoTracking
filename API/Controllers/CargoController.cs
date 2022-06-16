using API.DTOs;
using API.DTOs.CargoDto;
using Business.Concrete;
using Business.DAOs.CargoDao;
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
    public class CargoController : BaseApiController
    {
        private readonly CargoService _cargoService;

        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CargoDto>>> GetCargos()
        {
            var cargoList = await _cargoService.GetListAsync();
            var cargoListDto = cargoList.Select(i => new CargoDto
            {
                Id = i.Id,
                Status = i.Status,
                EmployeeId = i.EmployeeId,
                ClientAdressId = i.ClientAdressId,
                SellerAdressId = i.SellerAdressId
            });

            return cargoListDto.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CargoDto>> GetCargo(int id)
        {
            var cargo = await _cargoService.GetById(id);
            if (cargo == null) return NotFound();

            var takenCargo = new CargoDto
            {
                Id = cargo.Id,
                Status = cargo.Status
            };

            return takenCargo;
        }

        [HttpPost]
        public async Task<ActionResult<CargoDto>> CreateCargo(CargoCreateDto cargo)
        {
            var createdCargo = new CargoCreateDao
            {
                SellerAdressId = cargo.SellerAdressId,
                ClientAdressId = cargo.ClientAdressId,
                Status = cargo.Status
            };

            await _cargoService.Add(createdCargo);
            return CreatedAtAction("GetCargo", new { id = createdCargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CargoDto>> UpdateCargo(int id, CargoUpdateDto cargo)
        {
            var cargoDealer = new CargoUpdateDao
            {
                Id = id,
                Status = cargo.Status
            };

            if (id != cargo.Id) return BadRequest();

            try
            {
                await _cargoService.Update(cargoDealer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CargoDto>> DeleteCargo(int id)
        {
            var cargo = await _cargoService.Delete(id);
            if (cargo == null) return NotFound();

            var deletedCargo = new CargoDto();
            return deletedCargo;
        }
    }
}
