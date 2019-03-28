using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.System.Permissions.Dto;
using Sun.DatingApp.Model.System.Permissions.Model;
using Sun.DatingApp.Model.System.Roles.Model;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<SystemPermission, PermissionListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Code))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.Rank, x => x.MapFrom(y => y.Rank))
                .ForMember(x => x.PageId, x => x.MapFrom(y => y.PageId));

            CreateMap<PermissionEditDto, SystemPermission>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Active, x => x.MapFrom(y => true))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Code))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.Rank, x => x.MapFrom(y => y.Rank))
                .ForMember(x => x.PageId, x => x.MapFrom(y => y.PageId))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now));

            CreateMap<SystemPermission, RolePermissionModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Code))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.PageId, x => x.MapFrom(y => y.PageId))
                .ForMember(x => x.Checked, x => x.MapFrom(y => false));
        }
    }
}
