using Business.DAOs.DealerDao;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IDealerService:IGenericService<DealerDao, DealerCreateDao, DealerUpdateDao>
    {

    }
}
