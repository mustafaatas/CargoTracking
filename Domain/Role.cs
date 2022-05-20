using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role : IEntityBase, IEFSoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> EmployeeList { get; set; } //= new List<Employee>();
        public DateTime CreatedDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
