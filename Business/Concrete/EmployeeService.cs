using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class EmployeeService : IGenericService<Employee>
    {
        public Task Add(Employee t)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
