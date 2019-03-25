using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View;
using Sun.DatingApp.Model.System.Menus.Model;
using Sun.DatingApp.Model.System.Roles.Model;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<SystemRole, RoleListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.PageNames, x => x.Ignore());

            CreateMap<ViewRolePageList, PageItem>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.PageId))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order));
        }
    }
}
