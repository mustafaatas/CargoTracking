using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DealerDto
{
    public class DealerDto
    {
        public int Id { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public string Adress { get; set; }
        public int ZIPCode { get; set; }
    }
}
