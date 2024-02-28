using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IInstructorDal
{
    Instructor Add(Instructor instructor);
    Instructor Update(Instructor instructor , Instructor deleteInstructor);
    Instructor Delete(Instructor instructor);
    List<Instructor> GetAll();
    Instructor GetById(int id);
    Instructor GetByIdentityNumber(long identityNumber);

}


