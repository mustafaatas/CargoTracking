using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.AdressDao
{
    public class AdressDao
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int ZIPCode { get; set; }
    }
}
