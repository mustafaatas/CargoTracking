using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class EmployeeGenericService : IGenericService<Employee>
    {
        public void Add(Employee t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
