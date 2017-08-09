using Newtonsoft.Json;
using StoreWeb.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity
{
    public class UserRoleEntity:BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
    }
}
