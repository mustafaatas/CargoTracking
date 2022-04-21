using Domain;
using Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework
{
    public class EfUserDal:GenericRepository<User>, IUserDal
    {
    }
}
