using AutoMapper;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Resources.Utils;

namespace Smarket.API.AutoMapper
{
    public class ViewModelToServiceModelMapping : Profile
    {


        public ViewModelToServiceModelMapping()
        {
            CreateMap<SaveUserCommand, Users>()
                .ForMember(dest => dest.TypeUserId,             to => to.MapFrom(src => src.TypeUserId))
                .ForMember(dest => dest.UserLogin,              to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,               to => to.MapFrom(src => EncryptString.Encrypt(src.UserPass)));

            CreateMap<SaveConsumerCommand, Users>()
                .ForMember(dest => dest.UserLogin,              to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,               to => to.MapFrom(src => EncryptString.Encrypt(src.UserPass)));

            CreateMap<SaveConsumerCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId,            to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode,               to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number,                 to => to.MapFrom(src => src.PhoneNumber));

            CreateMap<SaveConsumerCommand, Consumers>()
                .ForMember(dest => dest.Name,                   to => to.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName,               to => to.MapFrom(src => src.LastName));

            CreateMap<SaveCommerceCommand, Users>()
                .ForMember(dest => dest.UserLogin,              to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,               to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveCommerceCommand, CommerceEmployee>()
                .ForMember(dest => dest.Name,                   to => to.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.LastName,               to => to.MapFrom(src => src.EmployeeLastName))
                .ForMember(dest => dest.CPF,                    to => to.MapFrom(src => src.CPF))
                .ForMember(dest => dest.RoleId,                 to => to.MapFrom(src => src.EmployeeRoleId));

            CreateMap<SaveCommerceCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId,            to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode,               to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number,                 to => to.MapFrom(src => src.Number));

            CreateMap<SaveCommerceCommand, Commerce>()
                .ForMember(dest => dest.CNPJ,                   to => to.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.SocialName,             to => to.MapFrom(src => src.SocialName))
                .ForMember(dest => dest.FantasyName,            to => to.MapFrom(src => src.FantasyName));

            CreateMap<SaveMarketCommand, Users>()
                .ForMember(dest => dest.UserLogin,              to => to.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.UserPass,               to => to.MapFrom(src => src.UserPass));

            CreateMap<SaveMarketCommand, MarketEmployee>()
                .ForMember(dest => dest.Name,                   to => to.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.LastName,               to => to.MapFrom(src => src.EmployeeLastName))
                .ForMember(dest => dest.CPF,                    to => to.MapFrom(src => src.CPF))
                .ForMember(dest => dest.RoleId,                 to => to.MapFrom(src => src.EmployeeRoleId));

            CreateMap<SaveMarketCommand, Phones>()
                .ForMember(dest => dest.TypePhoneId,            to => to.MapFrom(src => src.TypePhoneId))
                .ForMember(dest => dest.AreaCode,               to => to.MapFrom(src => src.AreaCode))
                .ForMember(dest => dest.Number,                 to => to.MapFrom(src => src.Number));

            CreateMap<SaveMarketCommand, Address>()
                .ForMember(dest => dest.Street,                 to => to.MapFrom(src => src.Street))
                .ForMember(dest => dest.Number,                 to => to.MapFrom(src => src.StreetNumber))
                .ForMember(dest => dest.ZipCode,                to => to.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.Neighborhood,           to => to.MapFrom(src => src.Neighborhood))
                .ForMember(dest => dest.CityId,                 to => to.MapFrom(src => src.CityId))
                .ForMember(dest => dest.StateId,                to => to.MapFrom(src => src.StateId));

            CreateMap<SaveMarketCommand, Market>()
                .ForMember(dest => dest.CNPJ,                   to => to.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.SocialName,             to => to.MapFrom(src => src.SocialName))
                .ForMember(dest => dest.FantasyName,            to => to.MapFrom(src => src.FantasyName))
                .ForMember(dest => dest.StateRegistration,      to => to.MapFrom(src => src.StateRegistration))
                .ForMember(dest => dest.MunicipalRegistration,  to => to.MapFrom(src => src.MunicipalRegistration));

            CreateMap<SaveCityCommand, Cities>()
                .ForMember(dest => dest.CityId,                 to => to.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Description,            to => to.MapFrom(src => src.Description))
                .ForMember(dest => dest.Latitude,               to => to.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude,              to => to.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.StateId,                to => to.MapFrom(src => src.StateId));

            CreateMap<SaveCategoryCommand, Categories>()
                .ForMember(dest => dest.Description, to => to.MapFrom(src => src.Description));

            CreateMap<SaveBrandCommand, Brands>()
                .ForMember(dest => dest.Description, to => to.MapFrom(src => src.Description));
        }
    }
}