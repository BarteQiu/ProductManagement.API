using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductManagement.API.WebControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public List<Category> GetCategory()
        {
            return DataStore.Categories;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int Id)
        {
            Category category = DataStore.Categories.FirstOrDefault(c => c.Id == Id);

            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("search")]
        public IActionResult GetCategoryByName(string Name)
        {
            Category category = DataStore.Categories.FirstOrDefault(c => c.Name == Name);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var CategoryAddId = DataStore.Categories
                .Select(p => p.Id)
                .DefaultIfEmpty(0)
                .Max();

            CategoryAddId += 1;

            category.Id = CategoryAddId;

            DataStore.Categories.Add(category);

            return CreatedAtAction
                (
                    nameof(GetCategoryByID),
                    new { Id = category.Id },
                    category
                );
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCategory(int Id)
        {
            Category category = DataStore.Categories.FirstOrDefault(c => c.Id == Id);

            if(category == null)
            {
                return NotFound();
            }

            DataStore.Categories.Remove(category);

            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCategory(int Id, Category UpdatedCategory)
        {
            Category category = DataStore.Categories.FirstOrDefault(c => c.Id == Id);

            if(category == null)
            {
                return NotFound();
            }

            category.Name = UpdatedCategory.Name;
            category.Description = UpdatedCategory.Description;
            category.Products = UpdatedCategory.Products;

            return NoContent();
        }
    } 
}
