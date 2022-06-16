using Business.Abstract;
using Business.DAOs.AdressDao;
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
    public class AdressService : IAdressService
    {
        private readonly DataContext context;

        public AdressService(DataContext context)
        {
            this.context = context;
        }

        public async Task Add(AdressCreateDao adress)
        {
            adress.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            var createdAdress = new Adress()
            {
                City = adress.City,
                District = adress.District,
                Description = adress.Description,
                ZIPCode = adress.ZIPCode
            };

            await context.Adresses.AddAsync(createdAdress);
            await context.SaveChangesAsync();
        }

        public async Task<AdressDao> Delete(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null) return null;

            adress.IsDeleted = true;
            adress.DeletedDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

            var deletedAdress = new AdressDao();

            context.Adresses.Remove(adress);
            await context.SaveChangesAsync();
            return deletedAdress;
        }

        public async Task<AdressDao> GetById(int id)
        {
            var adress = await context.Adresses.FindAsync(id);
            var adressDao = new AdressDao()
            {
                Id = adress.Id,
                City = adress.City,
                District = adress.District,
                Description = adress.Description          
            };

            return adressDao;
        }

        public async Task<List<AdressDao>> GetListAsync()
        {
            var adressList = await context.Adresses.ToListAsync();
            var adressListDao = adressList.Select(i => new AdressDao
            {
                Id = i.Id,
                City = i.City,
                District = i.District,
                Description = i.Description,
                ZIPCode = i.ZIPCode
            });

            return adressListDao.ToList();
        }

        public async Task Update(AdressUpdateDao adress)
        {
            var getAdress = await context.Adresses.FindAsync(adress.Id);
            getAdress.LastModificationDate = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            getAdress.Description = adress.Description;

            context.Entry(getAdress).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
