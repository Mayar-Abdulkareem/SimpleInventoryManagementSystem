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
}