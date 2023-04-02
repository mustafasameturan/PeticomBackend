using Core.Entities;

namespace Entities.Concretes;

public class SomeFeatureEntity : BaseEntity<Guid>
{
    public string Name { get; set; }
    public int Price { get; set; }

    public SomeFeatureEntity()
    {
        
    }

    public SomeFeatureEntity(string name, int price)
    {
        Name = name;
        Price = price;
    }
}