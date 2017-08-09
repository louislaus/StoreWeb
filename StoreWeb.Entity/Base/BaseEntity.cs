using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Entity.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
            IsDelete = false;
        }
    }
}
