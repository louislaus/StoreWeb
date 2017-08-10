using AutoMapper;
using StoreWeb.Entity;
using StoreWeb.Services.Enum;
using StoreWeb.Services.Pvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Services
{
    public class AutoMapperConfiguration
    {
        public static void ConfigExt()
        {
            Mapper.CreateMap<UserPvo, UserEntity>().ForMember(u => u.Status, e => e.MapFrom(s => (byte)s.Status));
            Mapper.CreateMap<UserEntity, UserPvo>().ForMember(u => u.Status, e => e.MapFrom(s => (UserStatus)s.Status));
            Mapper.CreateMap<MenuEntity, MenuPvo>().ForMember(u => u.Type, e => e.MapFrom(s => (MenuType)s.Type));
            Mapper.CreateMap<MenuPvo, MenuEntity>().ForMember(u => u.Type, e => e.MapFrom(s => (byte)s.Type));
        }
    }             
}
