using Domain;
using Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework
{
    class EfRoleDal:GenericRepository<Role>, IRoleDal
    {
    }
}
