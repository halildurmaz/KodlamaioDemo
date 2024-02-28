using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICourseDal
{
    Course Add(Course course);
    Course Update(Course course, Course deleteCourse);
    Course Delete(Course course);
    List<Course> GetAll();
    Course GetById(int id);
    Course GetByName(string name);

}


