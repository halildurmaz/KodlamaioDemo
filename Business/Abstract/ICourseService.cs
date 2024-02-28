using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract;

public interface ICourseService
{
    Course Add(Course course);
    Course Update(Course course);
    Course Delete(Course course);
    List<Course> GetAll();
    Course GetById(int id);
}

