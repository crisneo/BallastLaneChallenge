using BallastLane.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Domain.Entities.Authentication
{
    public class User : BaseEntity
    {
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string Roles { get; set; }
    }
}
