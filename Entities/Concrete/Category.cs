using Entities.Abstract;

namespace Entities.Concrete;

public class Category : IEntities<int>
{
    public int Id { get; set; }
    public string Name { get; set; }

}