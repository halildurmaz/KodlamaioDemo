using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class CategoryBusinessRules
{
    private ICategoryDal _categoryDal;

    public CategoryBusinessRules(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void CategoryNameShouldBeCanNotDuplicatedWhenInserted(string categoryName)
    {
        var category = _categoryDal.GetByName(categoryName);
        if (category != null)
        {
            throw new Exception("Category name already exists!");
        }
    }

    public void CategoryNameShouldBeCanNotDuplicatedWhenUpdated(Category category)
    {
        var result = _categoryDal.GetByName(category.Name);
        if (result != null && result.Id != category.Id)
        {
            throw new Exception("Category name already exists!");
        }
    }

    public void CategoryShouldBeExistsWhenSelected(Category category)
    {
        if (category == null) { throw new Exception("Category not exists!"); }
    }
}
