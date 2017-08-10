using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class BasePvo
    {
        public int Id { get; set; }
        public DateTime CreateDataTime { get; set; }
        public bool IsDelete { get; set; }
        public BasePvo()
        {
            CreateDataTime = DateTime.Now;
            IsDelete = false;
        }
    }
}
