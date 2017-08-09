using StoreWeb.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity
{
    public class RoleEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
