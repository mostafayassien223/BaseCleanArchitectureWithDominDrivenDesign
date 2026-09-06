using MediatR;
using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.AddProjectCommand
{
    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, TResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var checkprojectcode = await _unitOfWork.Project.CheckUniqueProjectCode(request.ProjectCode);
            if (checkprojectcode)
                return TResponse<string>.Failure("thiscodeAlreadyExist");

            var query= Project.Init(request.Name,request.ProjectCode,request.Description,request.ProjectLocation,request.UnitsCount);

            if (request?.ProjectUnits.Count() > 0)
            {
                var mappingtoUnits = request.ProjectUnits.Mapping();
                query.AddUnits(mappingtoUnits);
            }

            await _unitOfWork.Project.Add(query, cancellationToken);
            var rows=await _unitOfWork.CommitAsync(cancellationToken);

            if (rows >= 0)
                return TResponse<string>.Success("AddedSuccess");

            return TResponse<string>.Failure("AddedFailed");


        }

    }
}
