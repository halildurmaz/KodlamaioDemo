using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Rules;

public class CourseBusinessRules
{
    private readonly ICourseDal _courseDal;
    private readonly ICategoryDal _categoryDal;
    private readonly IInstructorDal _instructorDal;


    public CourseBusinessRules(ICourseDal courseDal)
    {
        _courseDal = courseDal;
        _categoryDal = new CategoryDal();
        _instructorDal = new InstructorDal();
    }

    public void CourseNameCanNotDuplicatedWhenInserted(Course course)
    {
        var result = _courseDal.GetByName(course.Name);
        if (result != null)
        {
            throw new Exception("Course name already exists!");
        }
    }

    public void CourseShouldBeExistsWhenSelected(Course course)
    {
        if (course == null) { throw new Exception("Course not exists!"); }
    }

    public void CourseNameCanNotDuplicatedWhenUpdated(Course course)
    {
        var result = _courseDal.GetByName(course.Name);
        if (result != null && result.Id != course.Id)
        {
            throw new Exception("Course name already exists!");
        }
    }

    public void CategoryAndInstructorShouldBeExists(Course course)
    {
        var categoryResult = _categoryDal.GetById(course.CategoryId);
        var instructorResult = _instructorDal.GetById(course.InstructorId);
        if (categoryResult == null && instructorResult == null)
        {
            throw new Exception("Category and Instructor not exists!");
        }
        else if (categoryResult == null)
        {
            throw new Exception("Category not exists!");
        }
        else if (instructorResult == null)
        {
            throw new Exception("Instructor not exists!");
        }
    }
}
