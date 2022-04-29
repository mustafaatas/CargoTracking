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
    public class DealerGenericService : IGenericService<Dealer>
    {
        private readonly DataContext context;

        public DealerGenericService(DataContext context)
        {
            this.context = context;
        }

        public void Add(Dealer t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Dealer t)
        {
            throw new NotImplementedException();
        }

        public Dealer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dealer> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Dealer t)
        {
            throw new NotImplementedException();
        }
    }
}
