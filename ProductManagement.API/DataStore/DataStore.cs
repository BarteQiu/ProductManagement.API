using Microsoft.AspNetCore.Http.HttpResults;

public static class DataStore
{
    public static void InitializeRelationships()
    {
        foreach(Product product in Products)
        {
            Category? category = DataStore.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

            if(category == null)
            {
                continue;
            }

            product.Category = category;
            category.Products.Add(product);
        }
    }

    public static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Słuchawki Bezprzewodowe", Price = 449.99m, CreatedAt = new DateTime(2026, 10, 15, 10, 30, 0), CategoryId = 2 },
        new Product { Id = 2, Name = "Mikrofon USB", Price = 389.50m, CreatedAt = new DateTime(2026, 10, 18, 14, 15, 0), CategoryId = 2 },
        new Product { Id = 3, Name = "Podkładka pod Mysz XXL", Price = 79.90m, CreatedAt = new DateTime(2026, 10, 22, 9, 45, 0), CategoryId = 1 },
        new Product { Id = 4, Name = "Fotel Ergonomiczny", Price = 899.00m, CreatedAt = new DateTime(2026, 10, 27, 16, 20, 0), CategoryId = 4 },
        new Product { Id = 5, Name = "Głośniki Komputerowe", Price = 259.99m, CreatedAt = new DateTime(2026, 11, 1, 12, 0, 0), CategoryId = 2 }
    };

    public static List<Category> Categories = new List<Category>
    {
        new Category { Id = 1, Name = "Akcesoria komputerowe", Description = "Akcesoria do komputerów i laptopów" },
        new Category { Id = 2, Name = "Audio", Description = "Sprzęt audio, słuchawki i głośniki" },
        new Category { Id = 3, Name = "Podzespoły komputerowe", Description = "Komponenty do komputerów stacjonarnych" },
        new Category { Id = 4, Name = "Meble biurowe", Description = "Meble i wyposażenie stanowiska pracy" },
        new Category { Id = 5, Name = "Urządzenia peryferyjne", Description = "Urządzenia podłączane do komputera" }
    };
}

