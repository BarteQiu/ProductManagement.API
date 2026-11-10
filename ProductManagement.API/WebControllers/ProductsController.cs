using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductManagement.API.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetProducts()
        {
            return DataStore.Products;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductFromId(int Id)
        {
            Product? product = DataStore.Products.FirstOrDefault(p => p.Id == Id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public IActionResult GetProductByName(string Name)
        {
            Product? product = DataStore.Products.FirstOrDefault(p => p.Name == Name);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var ProductAddId = DataStore.Products
                .Select(p => p.Id)
                .DefaultIfEmpty(0)
                .Max();

            ProductAddId += 1;

            product.Id = ProductAddId;

            product.CreatedAt = DateTime.Now;
            DataStore.Products.Add(product);

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
            Product? product = DataStore.Products.FirstOrDefault(p => p.Id == Id);

            if(product == null)
            {
                return NotFound();
            }

            DataStore.Products.Remove(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int Id, Product UpdatedProduct)
        {
            Product? product = DataStore.Products.FirstOrDefault(p => p.Id == Id);

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
