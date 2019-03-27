using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.System.Auth.Accounts.Model;
using Sun.DatingApp.Model.System.Auth.Info;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Model.System.Auth.Register.Dto;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            //登录
            CreateMap<AccessDataModel, SystemAccount>();
            CreateMap<SystemAccount, AccessDataModel>()
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.Nickname))
                .ForMember(x => x.RefreshToken, x => x.MapFrom(y => y.RefreshToken))
                .ForMember(x => x.Permissions, x => x.Ignore());

            //注册
            CreateMap<RegisterDto, SystemAccount>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.Mobile, x => x.MapFrom(y => y.Mobile))
                .ForMember(x => x.RoleId, x => x.Ignore())
                .ForMember(x => x.PasswordSalt, x => x.Ignore())
                .ForMember(x => x.PasswordHash, x => x.Ignore())
                .ForMember(x => x.AccessFailedCount, x => x.MapFrom(y => 0))
                .ForMember(x => x.Active, x => x.MapFrom(y => true))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false))
                .ForMember(x => x.LatestLoginAt, x => x.MapFrom(y => DateTime.Now));

            //账号管理
            CreateMap<SystemAccount, AccountListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.Nickname))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(x => x.LatestLoginAt, x => x.MapFrom(y => y.LatestLoginAt))
                .ForMember(x => x.LockoutEndAt, x => x.MapFrom(y => y.LockoutEndAt))
                .ForMember(x => x.AccessFailedCount, x => x.MapFrom(y => y.AccessFailedCount))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt));

            CreateMap<ViewAccountList, AccountListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.AvatarUrl, x => x.MapFrom(y => this.GetAvatarUrl(y.AvatarUrl)))
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.Nickname))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(x => x.RoleName, x => x.MapFrom(y => y.RoleName))
                .ForMember(x => x.LatestLoginAt, x => x.MapFrom(y => y.LatestLoginAt))
                .ForMember(x => x.LockoutEndAt, x => x.MapFrom(y => y.LockoutEndAt))
                .ForMember(x => x.AccessFailedCount, x => x.MapFrom(y => y.AccessFailedCount))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt));


            CreateMap<ViewAccountList, AccountInfo>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.Email))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Nickname))
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(x => x.RoleName, x => x.MapFrom(y => y.RoleName))
                .ForMember(x => x.Avatar, x => x.MapFrom(y => y.AvatarUrl))
                .ForMember(x => x.RefreshToken, x => x.MapFrom(y => y.RefreshToken))
                .ForMember(x => x.AccessToken, x => x.Ignore());

            //账号菜单
            CreateMap<SystemMenu, AccountMenu>()
                .ForMember(x => x.Key, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Text, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Icon, x => x.MapFrom(y => "anticon anticon-" + y.Icon))
                .ForMember(x => x.ShortcutRoot, x => x.MapFrom(y => true))
                .ForMember(x => x.Children, x => x.Ignore());

            //账号菜单页面
            CreateMap<ViewRolePageList, AccountPage>()
                .ForMember(x => x.Key, x => x.MapFrom(y => y.PageId))
                .ForMember(x => x.Text, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Link, x => x.MapFrom(y => y.Url));

        }

        private string GetAvatarUrl(string url)
        {
            var avatarUrl = "http://zeus-dev.oss-cn-qingdao.aliyuncs.com/2feb9e5b-1179-5e96-ecaf-db11347bd998.jpg";
            if (!string.IsNullOrEmpty(url))
            {
                avatarUrl = url;
            }

            return avatarUrl;
        }
    }
}
