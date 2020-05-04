using AutoMapper;
using DataStorage.DataAccess.EntityFramework.Entities;
using DataStorage.Dtos;

namespace DataStorage.DataAccess.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
