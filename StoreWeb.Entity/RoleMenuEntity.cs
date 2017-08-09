using StoreWeb.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity
{
    public class RoleMenuEntity:BaseEntity
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
    }
}
