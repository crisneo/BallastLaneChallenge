using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Domain.Common
{
    public interface IAuditableEntity : IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
