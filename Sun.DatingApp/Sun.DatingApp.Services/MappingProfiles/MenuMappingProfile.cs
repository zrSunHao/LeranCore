﻿using System;
using AutoMapper;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.System.Menus.Dto;
using Sun.DatingApp.Model.System.Menus.Model;

namespace Sun.DatingApp.Services.MappingProfiles
{
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<MenuEditDto, SystemMenu>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.Active, x => x.MapFrom(y => true))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now));

            CreateMap<SystemMenu, MenuListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro));

            CreateMap<PageEditDto, SystemPage>()
                .ForMember(x => x.Id, x => x.MapFrom(y => Guid.NewGuid()))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Url, x => x.MapFrom(y => y.Url))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.MenuId, x => x.MapFrom(y => y.MenuId))
                .ForMember(x => x.Active, x => x.MapFrom(y => true))
                .ForMember(x => x.Deleted, x => x.MapFrom(y => false))
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => DateTime.Now));

            CreateMap<SystemPage, PageListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Url, x => x.MapFrom(y => y.Url))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order))
                .ForMember(x => x.MenuId, x => x.MapFrom(y => y.MenuId))
                .ForMember(x => x.MenuName, x => x.Ignore())
                .ForMember(x => x.MenuTagColor, x => x.Ignore())
                .ForMember(x => x.MenuIcon, x => x.Ignore());

            CreateMap<ViewPageList, PageListModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Url, x => x.MapFrom(y => y.Url))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Icon))
                .ForMember(x => x.TagColor, x => x.MapFrom(y => y.TagColor))
                .ForMember(x => x.Active, x => x.MapFrom(y => y.Active))
                .ForMember(x => x.Intro, x => x.MapFrom(y => y.Intro))
                .ForMember(x => x.Order, x => x.MapFrom(y => y.Order))
                .ForMember(x => x.MenuId, x => x.MapFrom(y => y.MenuId))
                .ForMember(x => x.MenuName, x => x.MapFrom(y => y.MenuName))
                .ForMember(x => x.MenuTagColor, x => x.MapFrom(y => y.MenuTagColor))
                .ForMember(x => x.MenuIcon, x => x.MapFrom(y => y.MenuIcon));

        }
    }
}
