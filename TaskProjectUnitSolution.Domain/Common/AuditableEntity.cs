namespace TaskProjectUnitSolution.Domain;

public abstract class AuditableEntity<TKey> 
{
    public TKey Id { get; set; }
    public DateTime Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public Guid? LastModifiedBy { get; set; }
}
