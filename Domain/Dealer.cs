using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dealer
    {

        public int Id { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public string Adress { get; set; }
        public int ZIPCode { get; set; }
    }
}
