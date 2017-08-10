using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class ResultPvo<T>where T:class
    {
        public int start { get; set; }
        public int length { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered
        {
            get { return recordsTotal; }
        }
        public List<T> data { get; set; }
    }
    public class Result<T>
    {
        public Result()
        {
            flag = false;
            data = default(T);
            msg = string.Empty;
        }
        public bool flag { get; set; }
        public T data { get; set; }
        public string msg { get; set; }
    }
}
