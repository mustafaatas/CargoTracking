using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dealer : IEntityBase, IEFSoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public string Adress { get; set; }
        public int ZIPCode { get; set; }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long CreatorUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastModificationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
