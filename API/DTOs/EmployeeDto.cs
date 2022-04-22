using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int? RoleId { get; set; }
        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public List<Cargo> CargoList { get; set; }
    }
}
