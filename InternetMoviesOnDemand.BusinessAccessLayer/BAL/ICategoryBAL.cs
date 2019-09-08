using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public interface ICategoryBAL
    {
        void AddCategory(CategoryVM category);

        void DeleteCatergory(int id);

        List<CategoryVM> GetAllCategory();

        CategoryVM GetCategoryByName(string name);

        CategoryVM GetCategoryById(int id);
     }
}
