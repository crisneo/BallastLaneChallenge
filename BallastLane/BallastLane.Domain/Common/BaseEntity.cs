using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Domain.Common
{
    public class BaseEntity : IAuditableEntity
    {
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual int Id { get; set; }
    }
}
