using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<Dao, CreateDao, UpdateDao>
    {
        Task Add(CreateDao t);
        Task<Dao> Delete(int id);
        Task Update(UpdateDao t);
        Task<List<Dao>> GetListAsync();
        Task<Dao> GetById(int id); 
    }
}
