using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.DealerDao
{
    public class DealerDao
    {
        public int Id { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public string Adress { get; set; }
        public int ZIPCode { get; set; }
    }
}
