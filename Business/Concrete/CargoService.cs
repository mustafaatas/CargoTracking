using Business.Abstract;
using Business.DAOs.CargoDao;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CargoService : ICargoService
    {
        private readonly DataContext context;

        public CargoService(DataContext context)
        {
            this.context = context;
        }

        public async Task Add(CargoCreateDao cargo)
        {
            cargo.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            var createdCargo = new Cargo()
            {
                SellerAdressId = cargo.SellerAdressId,
                ClientAdressId = cargo.ClientAdressId,
                Status = cargo.Status
            };

            await context.Cargos.AddAsync(createdCargo);
            await context.SaveChangesAsync();
        }

        public async Task<CargoDao> Delete(int id)
        {
            var cargo = await context.Cargos.FindAsync(id);
            if (cargo == null) return null;

            cargo.IsDeleted = true;
            cargo.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

            var deletedCargo = new CargoDao();

            context.Cargos.Remove(cargo);
            await context.SaveChangesAsync();
            return deletedCargo;
        }

        public async Task<CargoDao> GetById(int id)
        {
            var cargo = await context.Cargos.FindAsync(id);
            var cargoDao = new CargoDao()
            {
                Id = cargo.Id,
                Status = cargo.Status
            };

            return cargoDao;
        }

        public async Task<List<CargoDao>> GetListAsync()
        {
            var cargoList = await context.Cargos.ToListAsync();
            var cargoListDao = cargoList.Select(i => new CargoDao
            {
                Id = i.Id,
                Status = i.Status,
                EmployeeId = i.EmployeeId,
                ClientAdressId = i.ClientAdressId,
                SellerAdressId = i.SellerAdressId
            });

            return cargoListDao.ToList();
        }

        public async Task Update(CargoUpdateDao cargo)
        {
            var getCargo = await context.Cargos.FindAsync(cargo.Id);
            getCargo.LastModificationDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            getCargo.Status = cargo.Status;

            context.Entry(getCargo).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
