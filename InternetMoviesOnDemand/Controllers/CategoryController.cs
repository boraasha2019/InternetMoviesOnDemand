using InternetMoviesOnDemand.BusinessAccessLayer.BAL;
using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetMoviesOnDemand.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryBAL _categoryBAL;

        public CategoryController(ICategoryBAL categoryBAL)
        {
            _categoryBAL = categoryBAL;
        }


        /// <summary>
        /// Method to get all categories
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Viewer")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _categoryBAL.GetAllCategory();
                if (categories.Count > 0)
                    return Ok(categories);
                return NotFound();

            }
            catch (Exception ex)
            {
                // Implemement Ilogger to log the error.
                return BadRequest();
            }
        }


        /// <summary>
        /// Add a new CAtegory
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Add(CategoryVM category)
        {
            try
            {
                if (_categoryBAL.GetCategoryByName(category.CategoryName).CategoryName == null)
                {
                    _categoryBAL.AddCategory(category);
                    return Ok("Category Successfully Added!!");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                // log the exception using ILogger
                return BadRequest();
            }

        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _categoryBAL.GetCategoryById(id);
                if (category.CategoryName != null)
                {
                    _categoryBAL.DeleteCatergory(id);
                    return Ok();
                }
                return NotFound("Category with id=" + id.ToString() + "not found to delete.");
            }
            catch (Exception ex)
            {
                // log the exception using ILogger
                return BadRequest();
            }
        }
    }
}
