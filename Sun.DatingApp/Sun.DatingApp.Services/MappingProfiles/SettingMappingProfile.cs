using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.System.Setting.Dto;
using Sun.DatingApp.Model.System.Setting.Model;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<ViewSettingList, SettingListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Key, x => x.MapFrom(y => y.Key))
                .ForMember(x => x.Value, x => x.MapFrom(y => y.Value))
                .ForMember(x => x.CreatedById, x => x.MapFrom(y => y.CreatedById))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt))
                .ForMember(x => x.Creator, x => x.MapFrom(y => y.Creator))
                .ForMember(x => x.UpdatedById, x => x.MapFrom(y => y.UpdatedById))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt))
                .ForMember(x => x.Modifier, x => x.MapFrom(y => y.Modifier));

            CreateMap<EditSettingDto, SystemSetting>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Key, x => x.MapFrom(y => y.Key))
                .ForMember(x => x.Value, x => x.MapFrom(y => y.Value))
                .ForMember(x => x.CreatedById, x => x.Ignore())
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false));
        }
    }
}
