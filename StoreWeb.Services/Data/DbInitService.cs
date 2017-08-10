using StoreWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Data
{
    public class DbInitService
    {
        public static void Init()
        {
            InitialData.Init();
        }
    }
}
