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
                .ForMember(dest => dest.TypeUserId,     to => to.MapFrom(src => src.TypeUserId))
                .ForMember(dest => dest.UserLogin,      to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,       to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveConsumerCommand, Users>()
                .ForMember(dest => dest.UserLogin,      to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,       to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveConsumerCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId,    to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode,       to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number,         to => to.MapFrom(src => src.PhoneNumber));

            CreateMap<SaveConsumerCommand, Consumers>()
                .ForMember(dest => dest.Name, to =>     to.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName,       to => to.MapFrom(src => src.LastName));

            CreateMap<SaveCommerceCommand, Users>()
                .ForMember(dest => dest.UserLogin,      to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,       to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveCommerceCommand, Employee>()
                .ForMember(dest => dest.Name,           to => to.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.LastName,       to => to.MapFrom(src => src.EmployeeLastName))
                .ForMember(dest => dest.CPF,            to => to.MapFrom(src => src.CPF))
                .ForMember(dest => dest.RoleId,         to => to.MapFrom(src => src.EmployeeRoleId));

            CreateMap<SaveCommerceCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId,    to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode,       to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number,         to => to.MapFrom(src => src.Number));

            CreateMap<SaveCommerceCommand, Commerce>()
                .ForMember(dest => dest.CNPJ,           to => to.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.SocialName,     to => to.MapFrom(src => src.SocialName))
                .ForMember(dest => dest.FantasyName,    to => to.MapFrom(src => src.FantasyName));

        }
    }
}