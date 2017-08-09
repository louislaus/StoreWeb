using StoreWeb.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity
{
    public class MenuEntity:BaseEntity
    {
        public int ParentId { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
    }
}
