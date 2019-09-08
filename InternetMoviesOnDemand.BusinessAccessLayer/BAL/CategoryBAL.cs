using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using InternetMoviesOnDemand.Repository.Model;
using InternetMoviesOnDemand.Repository.Repository;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public class CategoryBAL : ICategoryBAL
    {
        private ICategoryRepository _categoryRepository;
        public CategoryBAL(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Method to add a new Category
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(CategoryVM category)
        {
            var cat = new Category { CategoryName = category.CategoryName };

            _categoryRepository.AddCategory(cat);
        }

        /// <summary>
        /// To delete a category using the id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCatergory(int id)
        {
            _categoryRepository.DeleteCatergory(id);
        }

        /// <summary>
        /// Get all the categories 
        /// </summary>
        /// <returns></returns>
        public List<CategoryVM> GetAllCategory()
        {
            var categoryVM = new List<CategoryVM>();
            var categories = _categoryRepository.GetAllCategory();
            if (categories.Count != 0)
            {
                foreach (var category in categories)
                {
                    categoryVM.Add(new CategoryVM { Id = category.Id, CategoryName = category.CategoryName });
                }
            }
            return categoryVM;
        }

        /// <summary>
        /// To get a category using category name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CategoryVM GetCategoryByName(string name)
        {
            var category = _categoryRepository.GetCategoryByName(name);
            var catVM = new CategoryVM();
            if (category != null)
            {
                catVM.CategoryName = category.CategoryName;
                catVM.Id = category.Id;
            }
            return catVM;
        }

        /// <summary>
        /// To get category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryVM GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            var catVM = new CategoryVM();
            if (category != null)
            {
                catVM.CategoryName = category.CategoryName;
                catVM.Id = category.Id;
            }
            return catVM;

        }
    }
}
