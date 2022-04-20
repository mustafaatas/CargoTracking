using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cargo
    {

        public int Id { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool Status { get; set; }
        public Adress SellerAdress { get; set; }
        public Adress ClientAdress { get; set; }
    }
}
