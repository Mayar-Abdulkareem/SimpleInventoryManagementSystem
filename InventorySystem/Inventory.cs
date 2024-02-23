namespace InventorySystem;

public class Inventory
{
    private List<Product> _products = new List<Product>();

    public void AddProduct(string name, float price, int quantity)
    {
        var product = new Product(name, price, quantity);
        _products.Add(product);
        Console.WriteLine($"Product {name} added successfully");
    }

    public void ViewAllProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("No products in inventory");
        }
        
        foreach (var product in _products)
        {
            product.ShowProductInfo();
        }
    }
    
    public void EditProductByName(string name, float? price = null, int? quantity = null)
    {
        Product? productToEdit = null;

        foreach (Product product in _products)
        {
            if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                productToEdit = product;
                break; 
            }
        }

        if (productToEdit != null)
        {
            if (price.HasValue)
            {
                productToEdit.Price = price.Value; 
            }

            if (quantity.HasValue)
            {
                productToEdit.Quantity = quantity.Value;
            }

            Console.WriteLine($"Product '{name}' updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public int CheckIfProductExist(string name)
    {
        for (int index = 0; index < _products.Count; index++)
        {
            if (_products[index].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return index; 
            }
        }
        return -1; 
    }

    public void DeleteProduct(string name)
    {
        int index = CheckIfProductExist(name);
        if (index  != -1)
        {
            _products.RemoveAt(index);
            Console.WriteLine($"Product {name} deleted successfully");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}