namespace InventorySystem;

public class Product
{
    private float _price;
    private int _quantity;
    
    public string Name { get; set; } 

    public float Price
    {
        get => _price;
        set => _price = value >= 0 ? value : 0;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value >= 0 ? value : 0;
    }
    
    public Product(string name, float price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void ShowProductInfo()
    {
        Console.WriteLine($"Product name: {Name}, Product price: {Price}, Product Quantity: {Quantity}");
    }
}