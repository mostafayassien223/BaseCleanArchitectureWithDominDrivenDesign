namespace TaskProjectUnitSolution.Domain;

public abstract class BaseResponse
{
    public bool Success => !Errors.Any();

    public ICollection<string> Errors { get; set; }
}
