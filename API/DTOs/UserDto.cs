using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}
