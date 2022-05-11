using Business.DAOs.DealerDao;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class DealerService : IDealerService
    {
        private readonly DataContext context;

        public DealerService(DataContext context)
        {
            this.context = context;
        }

        public async Task Add(DealerCreateDao dealer)
        {
            //var employeeList = context.Employees.Where(i => i.DealerId == 5).Include(i => i.CargoList);
            //var cargoListOfEmployeeList = employeeList.Select(i => i.Name);
            //id numarası 5 olan bayinin kargo listesindeki işçilerin isim listesi
            
            dealer.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            var createdDealer = new Dealer()
            {
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode,
                CreatedDate = dealer.CreatedDate
            };

            await context.Dealers.AddAsync(createdDealer);
            await context.SaveChangesAsync();
        }

        public async Task<DealerDao> Delete(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            if (dealer == null) return null;

            dealer.IsDeleted = true;
            dealer.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

            var deletedDealer = new DealerDao()
            {
                Id = dealer.Id,
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode
            };

            context.Dealers.Remove(dealer);
            await context.SaveChangesAsync();
            return deletedDealer;
        }

        public async Task<DealerDao> GetById(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);
            var dealerList = new DealerDao()
            {
                Id = dealer.Id,
                Adress = dealer.Adress,
                ZIPCode = dealer.ZIPCode,
                EmployeeList = dealer.EmployeeList
            };

            return dealerList;
        }

        public async Task<List<DealerDao>> GetListAsync()
        {
            var dealerList = await context.Dealers.ToListAsync();
            var dealerListDao = dealerList.Select(i => new DealerDao
            { 
                Id = i.Id,
                Adress = i.Adress,
                ZIPCode = i.ZIPCode,
                EmployeeList = i.EmployeeList
            });

            return dealerListDao.ToList();
        }

        public async Task Update(DealerUpdateDao dealer)
        {
            var getDealer = await context.Dealers.FindAsync(dealer.Id);
            getDealer.LastModificationDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            getDealer.Adress = dealer.Adress;

            context.Entry(getDealer).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
