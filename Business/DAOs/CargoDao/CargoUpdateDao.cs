using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAOs.CargoDao
{
    public class CargoUpdateDao
    {
        public int Id { get; set; }
        public bool Status;
        public DateTime? LastModificationDate { get; set; }
    }
}
