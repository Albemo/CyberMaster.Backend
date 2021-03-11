using CyberMaster.Backend.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMaster.Backend.Core.Common
{
    public class Auditable
    {
        public virtual int Id { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTimeOffset CreatedOn { get; set; }

        public virtual DateTimeOffset? UpdatedOn { get; set; }

        public virtual int? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual int? UpdatedById { get; set; }

        public virtual User UpdatedBy { get; set; }
    }
}
