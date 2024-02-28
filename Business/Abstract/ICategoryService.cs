using Entities.Concrete;


namespace Business.Abstract;

public interface ICategoryService
{
    Category Add(Category category);
    Category Update(Category category);
    Category Delete(Category category);
    List<Category> GetAll();
    Category GetById(int id);
}

