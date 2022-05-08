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

        public async Task Add(Dealer dealer)
        {
            //var employeeList = context.Employees.Where(i => i.DealerId == 5).Include(i => i.CargoList);
            //var cargoListOfEmployeeList = employeeList.Select(i => i.Name);
            //id numarası 5 olan bayinin kargo listesindeki işçilerin isim listesi
            
            var employeeList = context.Employees.Include(i => i.CargoList);
            dealer.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            await context.Dealers.AddAsync(dealer);
            await context.SaveChangesAsync();
        }

        public async Task<Dealer> Delete(int id)
        {
            var dealer = await context.Dealers.FindAsync(id);

            if (dealer == null) return null;

            dealer.IsDeleted = true;
            dealer.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            //context.Dealers.Remove(dealer);
            context.Remove(dealer);
            await context.SaveChangesAsync();
            return dealer;
        }

        public async Task<Dealer> GetById(int id)
        {
            return await context.Dealers.FindAsync(id);
        }

        public async Task<List<Dealer>> GetListAsync()
        {
            return await context.Dealers.ToListAsync();
        }

        public async Task Update(Dealer dealer)
        {
            dealer.LastModificationDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            context.Entry(dealer).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
