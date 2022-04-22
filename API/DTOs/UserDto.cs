using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Adress> AdressList { get; set; }
        public List<Cargo> CargoList { get; set; }
    }
}
