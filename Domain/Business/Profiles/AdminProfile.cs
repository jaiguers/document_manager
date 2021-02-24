using DocumentManager.CrossCutting.ApplicationModel;
using AutoMapper;
using Domain.Models;

namespace Domain.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<City, CityAM>().ReverseMap();
            CreateMap<Menu, MenuAM>().ReverseMap();
            CreateMap<Person, PersonAM>().ReverseMap();
            CreateMap<States, StatesAM>().ReverseMap();
            CreateMap<RolMenu, RolMenuAM>().ReverseMap();
            CreateMap<Documents, DocumentsAM>().ReverseMap();
            CreateMap<Department, DepartmentAM>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeAM>().ReverseMap();
            CreateMap<IdentificationType, IdentificationTypeAM>().ReverseMap();
            CreateMap<ConsecutiveConfig, ConsecutiveConfigAM>().ReverseMap();
        }
    }
}
