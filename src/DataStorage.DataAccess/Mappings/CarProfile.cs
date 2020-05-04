using System;
using AutoMapper;
using DataStorage.DataAccess.EntityFramework.Entities;
using DataStorage.Dtos;

namespace DataStorage.DataAccess.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(
                    dest => dest.Status,
                    src =>
                        src.MapFrom(s =>
                            s.LastConnectionTime.AddMinutes(1) > DateTime.UtcNow ?
                                StatusEnum.Online.ToString() :
                                StatusEnum.Offline.ToString()))
                .ReverseMap();
        }
    }
}
