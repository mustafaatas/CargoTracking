using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.CargoDao
{
    public class CargoCreateDao
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int? SellerAdressId { get; set; }
        public int? ClientAdressId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
