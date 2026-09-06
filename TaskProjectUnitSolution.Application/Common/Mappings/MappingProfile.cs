using AutoMapper;
using TaskProjectUnitSolution.Application.Common.Helpers;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;
using TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte;

namespace TaskProjectUnitSolution.Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Units, UnitDto>().ReverseMap();
        
    }

}
