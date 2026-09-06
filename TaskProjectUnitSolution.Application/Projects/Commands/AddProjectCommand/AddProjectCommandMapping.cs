using TaskProjectUnitSolution.Application.Common.Helpers;
using TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte;

namespace TaskProjectUnitSolution.Application.Projects.Commands.AddProjectCommand
{
    public static class AddProjectCommandMapping
    {
        public static List<Units> Mapping(this List<UnitDto> unitDto)
        {
            return unitDto.Select(dto => Units.Init(
                dto.Descrption,
                dto.Location,
                dto.UnitArea,
                dto.NumberOfRooms
              )).ToList();
        }
    }
}
