using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CargoDto
{
    public class CargoDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool Status { get; set; }
        public Adress Adress { get; set; }
        public int? SellerAdressId { get; set; }
        public int? ClientAdressId { get; set; }
    }
}
