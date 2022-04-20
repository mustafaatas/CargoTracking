using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Adress> AdressList { get; set; }
        public List<Cargo> KargoList { get; set; }
    }
}
