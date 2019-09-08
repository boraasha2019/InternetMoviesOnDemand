using InternetMoviesOnDemand.Repository.Model;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();

        Category GetCategoryByName(string name);

        Category GetCategoryById(int id);

        void AddCategory(Category category);

        void DeleteCatergory(int id);
    }
}
