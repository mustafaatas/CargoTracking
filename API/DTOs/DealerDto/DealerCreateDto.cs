using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DealerDto
{
    public class DealerCreateDto
    {
        public string Adress { get; set; }
        public int ZIPCode { get; set; }
    }
}
