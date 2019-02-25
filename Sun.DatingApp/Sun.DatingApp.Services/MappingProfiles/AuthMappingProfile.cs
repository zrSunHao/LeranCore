using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Auth.Accounts.Model;
using Sun.DatingApp.Model.Auth.Login.Model;
using Sun.DatingApp.Model.Auth.Register.Dto;
using System;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            //登录
            CreateMap<AccessDataModel, Account>();
            CreateMap<Account, AccessDataModel>()
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(x => x.RefreshToken, x => x.MapFrom(y => y.RefreshToken))
                .ForMember(x => x.Permissions, x => x.Ignore());

            //注册
            CreateMap<RegisterDto, Account>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(x => x.RoleId, x => x.Ignore())
                .ForMember(x => x.RoleCode, x => x.Ignore())
                .ForMember(x => x.PasswordSalt, x => x.Ignore())
                .ForMember(x => x.PasswordHash, x => x.Ignore())
                .ForMember(x => x.AccessFailedCount, x => x.MapFrom(y => 0))
                .ForMember(x => x.Active, x => x.MapFrom(y => true))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false))
                .ForMember(x => x.LatestLoginAt, x => x.MapFrom(y => DateTime.Now));

            //账号管理
            CreateMap<Account, AccountListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(x => x.Role, x => x.MapFrom(y => y.RoleCode))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.LatestLoginAt, x => x.MapFrom(y => y.LatestLoginAt))
                .ForMember(x => x.LockoutEndAt, x => x.MapFrom(y => y.LockoutEndAt))
                .ForMember(x => x.AccessFailedCount, x => x.MapFrom(y => y.AccessFailedCount))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt));

        }
    }
}
