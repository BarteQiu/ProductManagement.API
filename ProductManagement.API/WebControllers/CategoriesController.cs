using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductManagement.API.WebControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Akcesoria komputerowe", Description = "Akcesoria do komputerów i laptopów" },
            new Category { Id = 2, Name = "Audio", Description = "Sprzęt audio, słuchawki i głośniki" },
            new Category { Id = 3, Name = "Podzespoły komputerowe", Description = "Komponenty do komputerów stacjonarnych" },
            new Category { Id = 4, Name = "Meble biurowe", Description = "Meble i wyposażenie stanowiska pracy" },
            new Category { Id = 5, Name = "Urządzenia peryferyjne", Description = "Urządzenia podłączane do komputera" }
        };

        [HttpGet]
        public List<Category> GetCategory()
        {
            return categories;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int Id)
        {
            Category category = categories.FirstOrDefault(c => c.Id == Id);

            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("search")]
        public IActionResult GetCategoryByName(string Name)
        {
            Category category = categories.FirstOrDefault(c => c.Name == Name);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categories.Add(category);

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
            Category category = categories.FirstOrDefault(c => c.Id == Id);

            if(category == null)
            {
                return NotFound();
            }

            categories.Remove(category);

            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCategory(int Id, Category UpdatedCategory)
        {
            Category category = categories.FirstOrDefault(c => c.Id == Id);

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
