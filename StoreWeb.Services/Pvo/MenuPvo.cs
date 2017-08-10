using StoreWeb.Services.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class MenuPvo:BasePvo
    {
        [DisplayName("上级分类")]
        public int ParentId { get; set; }
        [DisplayName("类型")]
        public MenuType Type { get; set; }
        public string TypeName
        {
            get { return Type.ToString(); }
        }
        [DisplayName("名称")]
        public string Name { get; set; }
        [DisplayName("URL")]
        public string Url { get; set; }
        [DisplayName("排序")]
        public int Order { get; set; }
    }
}
