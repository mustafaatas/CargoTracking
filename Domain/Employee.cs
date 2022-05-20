using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee : IEntityBase, IEFSoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int? RoleId { get; set; }
        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public List<Cargo> CargoList { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
