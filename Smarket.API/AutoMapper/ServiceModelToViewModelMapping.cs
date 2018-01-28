﻿using AutoMapper;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smarket.API.AutoMapper
{
    public class ServiceModelToViewModelMapping : Profile
    {

        public ServiceModelToViewModelMapping()
        {
            CreateMap<Users, UserModel>()
                .ForMember(dest => dest.UserId,                 to => to.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserLogin,              to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,               to => to.MapFrom(src => src.UserPass))
                .ForMember(dest => dest.TypeUserId,             to => to.MapFrom(src => src.TypeUserId))
                .ForMember(dest => dest.UserLastAccess,         to => to.MapFrom(src => src.UserLastAccess));

            CreateMap<Consumers, ConsumerModel>()
                .ForMember(dest => dest.UserId,                 to => to.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name,                   to => to.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName,               to => to.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Avatar,                 to => to.MapFrom(src => src.Avatar));

            CreateMap<Commerce, CommerceModel>()
                .ForMember(dest => dest.CommerceId,             to => to.MapFrom(src => src.CommerceId))
                .ForMember(dest => dest.SocialName,             to => to.MapFrom(src => src.SocialName))
                .ForMember(dest => dest.FantasyName,            to => to.MapFrom(src => src.FantasyName))
                .ForMember(dest => dest.CNPJ,                   to => to.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.StateRegistration,      to => to.MapFrom(src => src.StateRegistration))
                .ForMember(dest => dest.MunicipalRegistration,  to => to.MapFrom(src => src.MunicipalRegistration))
                .ForMember(dest => dest.Logo,                   to => to.MapFrom(src => src.Logo))
                .ForMember(dest => dest.Banner,                 to => to.MapFrom(src => src.Banner));
        }

    }
}