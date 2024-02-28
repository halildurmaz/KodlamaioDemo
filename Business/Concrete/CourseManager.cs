using Business.Abstract;
using Business.Rules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CourseManager : ICourseService

{
    private readonly CourseBusinessRules _courseBusinessRules;
    private readonly ICourseDal _courseDal;
    public CourseManager(ICourseDal courseDal)
    {
        _courseDal = courseDal;
        _courseBusinessRules = new CourseBusinessRules(_courseDal);
    }
    public Course Add(Course course)
    {
        _courseBusinessRules.CourseNameCanNotDuplicatedWhenInserted(course);
        _courseBusinessRules.CategoryAndInstructorShouldBeExists(course);
        return _courseDal.Add(course);
    }

    public Course Delete(Course course)
    {
        var deleteCourse = _courseDal.GetById(course.Id);
        _courseBusinessRules.CourseShouldBeExistsWhenSelected(deleteCourse);    
        return _courseDal.Delete(course);

    }

    public List<Course> GetAll()
    {
        return _courseDal.GetAll();
    }

    public Course GetById(int id)
    {

        var result = _courseDal.GetById(id);
        _courseBusinessRules.CourseShouldBeExistsWhenSelected(result);
        return result;
    }

    public Course Update(Course course)
    {
        var deleteCourse = _courseDal.GetById(course.Id);
        _courseBusinessRules.CourseShouldBeExistsWhenSelected(deleteCourse);
        _courseBusinessRules.CourseNameCanNotDuplicatedWhenUpdated(course);
        _courseBusinessRules.CategoryAndInstructorShouldBeExists(course);
        return _courseDal.Update(course, deleteCourse);
    }
}