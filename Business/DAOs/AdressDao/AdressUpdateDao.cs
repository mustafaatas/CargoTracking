using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.AdressDao
{
    public class AdressUpdateDao
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
