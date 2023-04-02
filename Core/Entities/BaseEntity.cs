namespace Core.Entities;

public abstract class BaseEntity<TId> : BaseEntity
{
    public TId Id { get; set; }

    public BaseEntity()
    {
        
    }

    protected BaseEntity(TId ıd)
    {
        Id = ıd;
    }
}

public abstract class BaseEntity
{
    protected BaseEntity(DateTime createdDate, DateTime updatedDate)
    {
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public BaseEntity()
    {
        
    }
    
    
}