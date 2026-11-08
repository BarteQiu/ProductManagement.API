using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductManagement.API.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Słuchawki Bezprzewodowe", Price = 449.99m, CreatedAt = new DateTime(2026, 10, 15, 10, 30, 0) },
            new Product { Id = 2, Name = "Mikrofon USB", Price = 389.50m, CreatedAt = new DateTime(2026, 10, 18, 14, 15, 0) },
            new Product { Id = 3, Name = "Podkładka pod Mysz XXL", Price = 79.90m, CreatedAt = new DateTime(2026, 10, 22, 9, 45, 0) },
            new Product { Id = 4, Name = "Fotel Ergonomiczny", Price = 899.00m, CreatedAt = new DateTime(2026, 10, 27, 16, 20, 0) },
            new Product { Id = 5, Name = "Głośniki Komputerowe", Price = 259.99m, CreatedAt = new DateTime(2026, 11, 1, 12, 0, 0) }
        };

        [HttpGet]
        public List<Product> GetProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductFromId(int Id)
        {
            Product? product = products.FirstOrDefault(p => p.Id == Id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public IActionResult GetProductByName(string Name)
        {
            Product? product = products.FirstOrDefault(p => p.Name == Name);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.CreatedAt = DateTime.Now;
            products.Add(product);

            return CreatedAtAction
                (
                    nameof(GetProductFromId),
                    new { Id = product.Id },
                    product
                );
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int Id)
        {
            Product? product = products.FirstOrDefault(p => p.Id == Id);

            if(product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int Id, Product UpdatedProduct)
        {
            Product? product = products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = UpdatedProduct.Name;
            product.Price = UpdatedProduct.Price;
            UpdatedProduct.UpdatedAt = DateTime.Now;
            product.UpdatedAt = UpdatedProduct.UpdatedAt;

            return NoContent();
        }
    }
}
