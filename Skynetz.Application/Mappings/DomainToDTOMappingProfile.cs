using AutoMapper;
using Skynetz.Application.DTOs;
using Skynetz.Domain.Entities;

namespace Skynetz.Application.Mappings
{
    public class DomainToDTOMappingProfile
    {
        public DomainToDTOMappingProfile()
        {
            Mapper.CreateMap<FlatRate, FlatRateDTO>().ReverseMap();
            Mapper.CreateMap<PlanFaleMais, PlanFaleMaisDTO>().ReverseMap();
        }
    }
}
