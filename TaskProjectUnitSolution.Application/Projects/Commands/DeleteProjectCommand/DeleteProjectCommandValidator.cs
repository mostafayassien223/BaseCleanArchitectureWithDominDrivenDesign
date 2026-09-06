using FluentValidation;

namespace TaskProjectUnitSolution.Application.Projects.Commands.DeleteProjectCommand
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Project Id must not be empty.")
                .NotEqual(Guid.Empty).WithMessage("Project Id must not be an empty Guid.");
        }
    }
   
}
