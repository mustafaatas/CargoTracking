using Business.DAOs.CargoDao;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface ICargoService : IGenericService<CargoDao, CargoCreateDao, CargoUpdateDao>
    {
    }
}
