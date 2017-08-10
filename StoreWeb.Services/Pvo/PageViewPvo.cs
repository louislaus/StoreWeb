using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class PageViewPvo:BasePvo
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Url { get; set; }
        public string IP { get; set; }
    }
}
