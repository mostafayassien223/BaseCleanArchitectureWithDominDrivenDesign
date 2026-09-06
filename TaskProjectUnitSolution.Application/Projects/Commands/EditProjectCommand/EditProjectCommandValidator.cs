using FluentValidation;

namespace TaskProjectUnitSolution.Application.Projects.Commands.EditProjectCommand
{
    public class EditProjectCommandValidator:AbstractValidator<EditProjectCommand>
    {
        public EditProjectCommandValidator()
        {
            RuleFor(command => command.ProjectCode)
            .NotEmpty().WithMessage("Project code is required.")
            .Length(5).WithMessage("Project code must consist of 5 characters/numbers.")
            .Matches("^[a-zA-Z0-9]{5}$").WithMessage("Project code must consist of letters and numbers only.");



            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(command => command.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");



            RuleFor(command => command.UnitsCount)
             .Must(count => count > 0 && count <= 100000)
             .WithMessage("The number of units must be greater than zero and not exceed 100,000.");


            RuleForEach(x => x.ProjectUnits).ChildRules(unit =>
            {
                unit.RuleFor(u => u.Descrption)
               .NotEmpty().WithMessage("Description is required.");

                unit.RuleFor(u => u.UnitArea)
                    .GreaterThan(0).WithMessage("Area must be greater than zero.");

                unit.RuleFor(u => u.NumberOfRooms)
                    .GreaterThan(0).WithMessage("Number of rooms must be greater than zero.");
            });
        }
    }
}
