using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Rules;

public class InstructorBusinessRules
{
    private readonly IInstructorDal _instructorDal;

    public InstructorBusinessRules(IInstructorDal instructorDal)
    {
        _instructorDal = instructorDal;
    }

    public void InstructorIdentityNumberCanNotDuplicatedWhenInserted(Instructor instructor)
    {
        var result = _instructorDal.GetByIdentityNumber(instructor.IdentityNumber);
        if (result != null)
        {
            throw new Exception("Instructor already exists!");
        }
    }
    public void InstructorShouldBeExistsWhenSelected(Instructor instructor)
    {
        if (instructor == null) { throw new Exception("Instructor not exists!"); }
    }

    public void InstructorIdentityNumberCanNotDuplicatedWhenUpdated(Instructor instructor)
    {
        var result = _instructorDal.GetByIdentityNumber(instructor.IdentityNumber);
        if (result != null && result.Id != instructor.Id)
        {
            throw new Exception("Instructor already exists!");
        }
    }
}
