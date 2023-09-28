namespace Framework.Domain;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
    }
    public Guid Id { get; private set; }

    public DateTime Timestamp { get; private set; }

}