using MediatR;
using TaskProjectUnitSolution.Application.Common.Helpers;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.EditProjectCommand
{
    public class EditProjectCommand : IRequest<TResponse<string>>
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public string ProjectLocation { get; set; }
        public int UnitsCount { get; set; }
        public List<UnitDto>? ProjectUnits { get; set; } = new List<UnitDto>();
    }
}
