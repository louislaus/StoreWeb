using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public partial interface IUserService
    {
        Result<UserPvo> Login(UserPvo pvo);
        void Logout();
        List<MenuPvo> GetMyMenus(int userId);
        ResultPvo<RolePvo> GetMyRole(QueryBase query, int userId);
        ResultPvo<RolePvo> GetNotMyRoles(QueryBase query, int userId);
    }
}
