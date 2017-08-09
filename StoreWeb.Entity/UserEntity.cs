using StoreWeb.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity
{
    public class UserEntity:BaseEntity
    {
        public string LoginName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
