using AutoMapper;
using StoreWeb.Entity;
using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services.Abstract
{
    public class AutoMappingConfig
    {
        public static void Config()
        {
            Mapper.CreateMap<LoginLogEntity, LoginLogPvo>();
            Mapper.CreateMap<LoginLogPvo, LoginLogEntity>();
            Mapper.CreateMap<MenuEntity, MenuPvo>();
            Mapper.CreateMap<MenuPvo, MenuEntity>();
            Mapper.CreateMap<PageViewEntity, PageViewPvo>();
            Mapper.CreateMap<PageViewPvo, PageViewEntity>();
            Mapper.CreateMap<RoleEntity, RolePvo>();
            Mapper.CreateMap<RolePvo, RoleEntity>();
            Mapper.CreateMap<RoleMenuEntity, RoleMenuPvo>();
            Mapper.CreateMap<RoleMenuPvo, RoleMenuEntity>();
            Mapper.CreateMap<UserEntity, UserPvo>();
            Mapper.CreateMap<UserPvo, UserEntity>();
            Mapper.CreateMap<UserRoleEntity, UserRolePvo>();
            Mapper.CreateMap<UserRolePvo, UserRoleEntity>();
        }
    }
}
