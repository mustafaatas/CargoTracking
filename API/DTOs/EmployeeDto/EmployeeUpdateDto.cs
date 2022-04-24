using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.EmployeeDto
{
    public class EmployeeUpdateDto
    {
        public int? RoleId { get; set; }
        public int? DealerId { get; set; }
    }
}
