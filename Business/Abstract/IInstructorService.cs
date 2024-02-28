using Entities.Concrete;


namespace Business.Abstract;

public interface IInstructorService
{
    Instructor Add(Instructor instructor);
    Instructor Update(Instructor instructor);
    Instructor Delete(Instructor instructor);
    List<Instructor> GetAll();
    Instructor GetById(int id);
}

