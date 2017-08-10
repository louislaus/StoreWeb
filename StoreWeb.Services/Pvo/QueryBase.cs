using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class QueryBase
    {
        public int Length { get; set; }
        public int Start { get; set; }
        public string SearchKey { get; set; }
        public int Draw { get; set; }
    }
}
