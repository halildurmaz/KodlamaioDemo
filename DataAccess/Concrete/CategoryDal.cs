using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class CategoryDal : ICategoryDal
{
    private List<Category> _categories;

    public CategoryDal()
    {
        _categories = new List<Category>();
    }

    public Category Add(Category category)
    {
        _categories.Add(category);
        return category;
    }
    public Category Update(Category category, Category deleteCategory)
    {
        _categories.Remove(deleteCategory);
        _categories.Add(category);
        return category;
    }

    public Category Delete(Category category)
    {
        _categories.Remove(category);
        return category;
    }

    public List<Category> GetAll()
    {
        return _categories;
    }

    public Category GetById(int id)
    {
        return _categories.Where(c => c.Id == id).FirstOrDefault();
    }
    public Category GetByName(string name)
    {
        return _categories.Where(c => c.Name == name).FirstOrDefault();
    }

}

