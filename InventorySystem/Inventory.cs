namespace InventorySystem;

/// <summary>
/// Manages the inventory of products, providing functionalities to add, edit, delete, and search products.
/// </summary>
public class Inventory
{
    // Store all products 
    private List<Product> _products = new List<Product>();

    /// <summary>
    /// Add product to inventory
    /// </summary>
    /// <param name="name"> the name of the product </param>
    /// <param name="price"> the price of the product </param>
    /// <param name="quantity"> the quantity in the stock</param>
    public void AddProduct(string name, float price, int quantity)
    {
        var product = new Product(name, price, quantity);
        _products.Add(product);
        Console.WriteLine($"Product {name} added successfully");
    }

    /// <summary>
    /// Show All products with their details and check if the inventory is empty
    /// </summary>
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
    
    /// <summary>
    /// Edit a product by name
    /// First I check if the product exists if so edit price and/or quantity
    /// </summary>
    /// <param name="name"> the name of the product </param>
    /// <param name="price"> the price of the product </param>
    /// <param name="quantity"> the quantity in the stock</param>
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

    /// <summary>
    /// Check if the product exists in the inventory
    /// return index if it is found, -1 otherwise
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Delete a product from inventory
    /// Check if the product exists first, if yes then delete it
    /// </summary>
    /// <param name="name"></param>
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
    
    /// <summary>
    /// Search for a product
    /// Check if the product exists, if yes then show details
    /// </summary>
    /// <param name="name"></param>
    public void SearchProduct(string name)
    {
        int index = CheckIfProductExist(name);

        if (index != -1)
        {
            _products.ElementAt(index).ShowProductInfo();
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}