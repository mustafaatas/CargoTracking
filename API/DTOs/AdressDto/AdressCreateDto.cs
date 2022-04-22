using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AdressDTO
{
    public class AdressCreateDto
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public int ZIPCode { get; set; }
    }
}
