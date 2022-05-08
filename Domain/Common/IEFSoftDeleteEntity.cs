using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEFSoftDeleteEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
