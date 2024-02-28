using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class InstructorDal : IInstructorDal
{
    private List<Instructor> _instructors;
    public InstructorDal()
    {
        _instructors = new List<Instructor>();
    }
    public Instructor Add(Instructor instructor)
    {
        _instructors.Add(instructor);
        return instructor;
    }
    public Instructor Update(Instructor instructor, Instructor deleteInstructor)
    {
        _instructors.Remove(deleteInstructor);
        _instructors.Add(instructor);
        return instructor;
    }

    public Instructor Delete(Instructor instructor)
    {
        _instructors.Remove(instructor);
        return instructor;
    }

    public List<Instructor> GetAll()
    {
        return _instructors;
    }

    public Instructor GetById(int id)
    {
        return _instructors.Where(i => i.Id == id).FirstOrDefault();
    }


    public Instructor GetByIdentityNumber(long identityNumber)
    {
        return _instructors.Where(c => c.IdentityNumber == identityNumber).FirstOrDefault();
    }
}

