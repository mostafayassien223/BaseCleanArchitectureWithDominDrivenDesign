using AutoMapper;
using MediatR;
using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.EditProjectCommand
{
    public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand, TResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TResponse<string>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.Project.GetProjectById(request.Id);
            if (query == null)
                return TResponse<string>.Failure("NotFound");
            var checkprojectcode = await _unitOfWork.Project.CheckUniqueProjectCode(request.ProjectCode,query.Id);
            if (checkprojectcode)
                return TResponse<string>.Failure("thiscodeAlreadyExist");

            query.Update(request.Name, request.ProjectCode, request.Description, request.ProjectLocation, request.UnitsCount);

            var mappingToUnits = _mapper.Map(request.ProjectUnits, query.Units).ToList();
            query.UpdateUnits(mappingToUnits);

            _unitOfWork.Project.Update(query);

            var rows = await _unitOfWork.CommitAsync(cancellationToken);
            if (rows >= 0)
             return TResponse<string>.Success("EditSuccess");

            return TResponse<string>.Failure("EditFailed");
        }
    }
}
