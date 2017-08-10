using StoreWeb.Services.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Pvo
{
    public class UserPvo:BasePvo
    {
        [DisplayName("登录账号"),Required,StringLength(20,MinimumLength =5,ErrorMessage ="长度在5-20个字符之间")]
        public string LoginName { get; set; }
        [DisplayName("真实姓名"),Required,StringLength(20,MinimumLength =2,ErrorMessage ="长度在2-20个字符之间")]
        public string RealName { get; set; }
        [DisplayName("登录密码"),Required,StringLength(36,MinimumLength =6,ErrorMessage ="长度在6-36个字符之间")]
        public string Password { get; set; }
        [DisplayName("邮箱*"),Required,StringLength(36,MinimumLength =5,ErrorMessage ="长度在5-36个字符之间")]
        public string Email { get; set; }
        [DisplayName("用户状态*"),Required]
        public UserStatus Status { get; set; }
        public string StatusName
        {
            get { return Status.ToString(); }
        }
        public bool IsRememberMe { get; set; }
    }
}
