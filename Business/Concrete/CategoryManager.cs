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

public class CategoryManager : ICategoryService
{
    private readonly CategoryBusinessRules _categoryBusinessRules;

    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
        _categoryBusinessRules = new CategoryBusinessRules(_categoryDal);
    }

    public Category Add(Category category)
    {
        _categoryBusinessRules.CategoryNameShouldBeCanNotDuplicatedWhenInserted(category.Name);
        return _categoryDal.Add(category);

    }
    public Category Update(Category category)
    {
        var updateCategory = _categoryDal.GetById(category.Id);
        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(updateCategory);
        _categoryBusinessRules.CategoryNameShouldBeCanNotDuplicatedWhenUpdated(category);
        return _categoryDal.Update(category, updateCategory);
    }

    public Category Delete(Category category)
    {
        var deleteCategory = _categoryDal.GetById(category.Id);
        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(deleteCategory);
        return _categoryDal.Delete(category);
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }

    public Category GetById(int id)
    {
        var result = _categoryDal.GetById(id);
        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(result);
        return result;
    }


}
