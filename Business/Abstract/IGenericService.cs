using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        Task Add(T t);
        Task<T> Delete(int id);
        Task Update(T t);
        Task<List<T>> GetListAsync();
        Task<T> GetById(int id); 
    }
}
