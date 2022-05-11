using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.DealerDao
{
    public class DealerUpdateDao
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
