using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.AdressDao
{
    public class AdressCreateDao
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public int ZIPCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
