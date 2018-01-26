using AutoMapper;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smarket.API.AutoMapper
{
    public class ViewModelToServiceModelMapping : Profile
    {


        public ViewModelToServiceModelMapping()
        {
            CreateMap<SaveUserCommand, Users>()
                .ForMember(dest => dest.TypeUserId, to => to.MapFrom(src => src.TypeUserId))
                .ForMember(dest => dest.UserLogin,  to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,   to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveConsumerCommand, Users>()
                .ForMember(dest => dest.UserLogin, to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass, to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveConsumerCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId, to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode, to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number, to => to.MapFrom(src => src.PhoneNumber));

            CreateMap<SaveConsumerCommand, Consumers>()
                .ForMember(dest => dest.Name, to => to.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, to => to.MapFrom(src => src.LastName));

        }
    }
}