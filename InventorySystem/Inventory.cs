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
}