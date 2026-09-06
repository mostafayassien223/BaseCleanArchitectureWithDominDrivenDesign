using MediatR;
using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Commands.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, TResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.Project.GetProjectById(request.Id);
            if (query == null)
                return TResponse<string>.Failure("NotFound");

            if (query.Units.Count() > 0)
                return TResponse<string>.Failure("لا يمكن حذف المشروع لانه مرتبط بوحدات");


            _unitOfWork.Project.Remove(query);
            var rows = await _unitOfWork.CommitAsync(cancellationToken);

            if (rows >= 0)
                return TResponse<string>.Success("DeletedSuccess");

            return TResponse<string>.Failure("DeletedFailed");

        }
    }
}
