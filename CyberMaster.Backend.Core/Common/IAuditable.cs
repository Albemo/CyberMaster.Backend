using CyberMaster.Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMaster.Backend.Core.Common
{
    public interface IAuditable
    {
        public int Id { get; }

        bool IsDeleted { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset? UpdatedOn { get; set; }

        int? CreatedById { get; set; }

        User CreatedBy { get; set; }

        int? UpdatedById { get; set; }

        User UpdatedBy { get; set; }
    }
}
