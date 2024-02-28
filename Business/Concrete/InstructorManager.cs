using Business.Abstract;
using Business.Rules;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorDal _instructorDal;
    private readonly InstructorBusinessRules _instructorBusinessRules;

    public InstructorManager(IInstructorDal instructorDal)
    {
        _instructorDal = instructorDal;
        _instructorBusinessRules = new InstructorBusinessRules(_instructorDal);
    }

    public Instructor Add(Instructor instructor)
    {
        _instructorBusinessRules.InstructorIdentityNumberCanNotDuplicatedWhenInserted(instructor);
        return _instructorDal.Add(instructor);
    }

    public Instructor Update(Instructor instructor)
    {
        var oldInstructor = _instructorDal.GetById(instructor.Id);
        _instructorBusinessRules.InstructorShouldBeExistsWhenSelected(oldInstructor);
        _instructorBusinessRules.InstructorIdentityNumberCanNotDuplicatedWhenUpdated(instructor);
        return _instructorDal.Update(instructor, oldInstructor);
    }

    public Instructor Delete(Instructor instructor)
    {
        var result = _instructorDal.GetById(instructor.Id);
        _instructorBusinessRules.InstructorShouldBeExistsWhenSelected(result);
        return _instructorDal.Delete(instructor);
    }

    public List<Instructor> GetAll()
    {
        return _instructorDal.GetAll();
    }

    public Instructor GetById(int id)
    {
        var result = _instructorDal.GetById(id);
        _instructorBusinessRules.InstructorShouldBeExistsWhenSelected(result);
        return result;
    }

    
}
