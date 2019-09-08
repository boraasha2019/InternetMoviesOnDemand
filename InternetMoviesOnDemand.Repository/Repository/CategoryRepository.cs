using InternetMoviesOnDemand.Data;
using InternetMoviesOnDemand.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private InMemoryDataContext _context;
        public CategoryRepository(InMemoryDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to add a new Category
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(new Category { Id = _context.Categories.Count + 1, CategoryName = category.CategoryName });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to delete a category
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCatergory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category != null)
                _context.Categories.Remove(category);
        }

        /// <summary>
        /// To get a category using category name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(x => x.CategoryName == name).SingleOrDefault();
        }

        /// <summary>
        /// Method to get all the categories from DB
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategory()
        {
            return _context.Categories;
        }

        /// <summary>
        /// To get category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(x => x.Id == id).SingleOrDefault();

        }
    }
}
