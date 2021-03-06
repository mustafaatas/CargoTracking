using Business.DAOs.AdressDao;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IAdressService : IGenericService<AdressDao, AdressCreateDao, AdressUpdateDao>
    {
    }
}
