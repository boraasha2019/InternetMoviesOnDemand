using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public interface ICategoryBAL
    {
        /// <summary>
        /// To add a new category
        /// </summary>
        /// <param name="category"></param>
        void AddCategory(CategoryVM category);

        /// <summary>
        /// To delete a category
        /// </summary>
        /// <param name="id"></param>
        void DeleteCatergory(int id);

        /// <summary>
        /// To get all the categories
        /// </summary>
        /// <returns></returns>
        List<CategoryVM> GetAllCategory();

        /// <summary>
        /// To get Category by category name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        CategoryVM GetCategoryByName(string name);

        /// <summary>
        /// To get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryVM GetCategoryById(int id);
     }
}
