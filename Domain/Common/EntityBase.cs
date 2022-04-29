using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntityBase
    {
        public DateTime CreatedDate { get; set; }

        public long CreatorUserId { get; set; }

        public DateTime LastModificationDate { get; set; }

    }
}
