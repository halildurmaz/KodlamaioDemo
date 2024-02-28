using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class CourseDal : ICourseDal
{

    private List<Course> _courses;

    public CourseDal()
    {
        _courses = new List<Course>();
    }

    public Course Add(Course course)
    {
        _courses.Add(course);
        return course;
    }
    public Course Update(Course course, Course deleteCourse)
    {
        _courses.Remove(deleteCourse);
        _courses.Add(course);

        return course;
    }

    public Course Delete(Course course)
    {
        _courses.Remove(course);
        return course;
    }



    public List<Course> GetAll()
    {
        return _courses;
    }

    public Course GetById(int id)
    {
        return _courses.Where(c => c.Id == id).FirstOrDefault();
    }

    public Course GetByName(string name)
    {
        return _courses.Where(c => c.Name == name).FirstOrDefault();
    }

}

