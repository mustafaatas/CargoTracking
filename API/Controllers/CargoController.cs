using API.DTOs;
using API.DTOs.CargoDto;
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
        private readonly DataContext context;

        public CargoController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CargoDto>>> GetCargos()
        {
            var cargoList = await context.Cargos.ToListAsync();
            var cargoListDto = cargoList.Select(i => new CargoDto
            {
                Id = i.Id,
                UserId = i.UserId,
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
            var cargo = await context.Cargos.FindAsync(id);
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
            var createdCargo = new Cargo
            {
                SellerAdressId = cargo.SellerAdressId,
                ClientAdressId = cargo.ClientAdressId,
                Status = cargo.Status
            };

            context.Cargos.Add(createdCargo);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = createdCargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CargoDto>> UpdateCargo(int id, CargoUpdateDto cargo)
        {
            var UpdateCargo = await context.Cargos.FindAsync(id);
            UpdateCargo.Status = cargo.Status;

            if (id != cargo.Id) return BadRequest();

            try
            {
                context.Entry(UpdateCargo).State = EntityState.Modified;
                await context.SaveChangesAsync();
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
            var cargo = await context.Cargos.FindAsync(id);
            if (cargo == null) return NotFound();

            var deletedCargo = new CargoDto
            {
                Id = cargo.Id,
                SellerAdressId = cargo.SellerAdressId,
                ClientAdressId = cargo.ClientAdressId
            };

            context.Cargos.Remove(cargo);
            await context.SaveChangesAsync();

            return deletedCargo;
        }
    }
}
