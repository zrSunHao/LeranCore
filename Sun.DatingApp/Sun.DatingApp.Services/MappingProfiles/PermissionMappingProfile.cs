using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.System.Permissions.Model;

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
                .ForMember(x => x.PageId, x => x.MapFrom(y => y.PageId));
        }
    }
}
