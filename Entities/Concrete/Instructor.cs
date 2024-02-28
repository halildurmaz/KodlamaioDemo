using Entities.Abstract;

namespace Entities.Concrete;

public class Instructor : IEntities<int>
{
    public int Id { get; set; }
    public long IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }


}