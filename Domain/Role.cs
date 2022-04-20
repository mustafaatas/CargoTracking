using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}
