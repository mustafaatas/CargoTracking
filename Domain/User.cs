using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : IEntityBase, IEFSoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Adress> AdressList { get; set; }
        public List<Cargo> CargoList { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
