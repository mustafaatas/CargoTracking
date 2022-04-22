using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CargoDto
{
    public class CargoCreateDto
    {
        public bool Status { get; set; }
        public int? SellerAdressId { get; set; }
        public int? ClientAdressId { get; set; }
    }
}
