using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sun.DatingApp.Data.Entities;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.System.Users.Model;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SystemUserInfo, UserInfoModel>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Sex, x => x.MapFrom(y => y.Sex))
                .ForMember(x => x.Birthday, x => x.MapFrom(y => y.Birthday))
                .ForMember(x => x.Motto, x => x.MapFrom(y => y.Motto))
                .ForMember(x => x.QQ, x => x.MapFrom(y => y.QQ))
                .ForMember(x => x.WeChart, x => x.MapFrom(y => y.WeChart))
                .ForMember(x => x.Occupation, x => x.MapFrom(y => y.Occupation))
                .ForMember(x => x.Company, x => x.MapFrom(y => y.Company))
                .ForMember(x => x.Address, x => x.MapFrom(y => y.Address))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro));
        }
    }
}
