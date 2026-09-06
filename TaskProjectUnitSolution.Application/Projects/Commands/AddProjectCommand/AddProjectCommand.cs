using MediatR;
using TaskProjectUnitSolution.Application.Common.Helpers;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.AddProjectCommand
{
    public class AddProjectCommand : IRequest<TResponse<string>>
    {
        public string Name { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public string ProjectLocation { get; set; }
        public int UnitsCount { get; set; }
        public List<UnitDto>? ProjectUnits { get; set; } = new List<UnitDto>();
    }
}
