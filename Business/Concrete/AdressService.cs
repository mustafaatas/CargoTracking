using Business.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdressService : IAdressService
    {
        public Task Add(Adress t)
        {
            throw new NotImplementedException();
        }

        public Task<Adress> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Adress> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Adress>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(Adress t)
        {
            throw new NotImplementedException();
        }
    }
}
