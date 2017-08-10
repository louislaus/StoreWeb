using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class RolePvo:BasePvo
    {
        [Required,DisplayName("角色名称"),MinLength(2),MaxLength(20)]
        public string Name { get; set; }
        [Required,DisplayName("描述"),MinLength(1),MaxLength(50)]
        public string Description { get; set; }
    }
}
