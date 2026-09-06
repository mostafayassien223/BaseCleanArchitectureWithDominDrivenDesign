using MediatR;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.DeleteProjectCommand
{
    public class DeleteProjectCommand: IRequest<TResponse<string>>
    {
        public Guid Id  { get; set; }
    }
}
