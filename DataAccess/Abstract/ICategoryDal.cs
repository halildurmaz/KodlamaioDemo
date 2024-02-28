using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;

public interface ICategoryDal
{
    Category Add(Category category);
    Category Update(Category category , Category deleteCategory);
    Category Delete(Category category);
    List<Category> GetAll();
    Category GetById(int id);
    Category GetByName(string name);

}


