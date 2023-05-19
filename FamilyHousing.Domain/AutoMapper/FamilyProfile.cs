using AutoMapper;
using FamilyHousing.Domain.Entities;
using FamilyHousing.Domain.Models;

namespace FamilyHousing.Domain.AutoMapper
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {
            CreateMap<FamilyModel, Family>().ReverseMap();

        }
    }
}
