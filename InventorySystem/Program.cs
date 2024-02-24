// See https://aka.ms/new-console-template for more information

namespace InventorySystem;
using static ConsoleHelper;

class Program
{
    static Inventory _inventory = new ();

    static void PrintMenu()
    {
        Console.Write("""
                          ****************************
                          Inventory System Menu:
                          ****************************
                          1. Add a product,
                          2. View all products,
                          3. Edit a product,
                          4. Delete a product,
                          5. Search a product,
                          6. Exit
                          ****************************
                          Select an option: 
                          """);
    }
    
    static void AddProduct()
    {
        string productName = ReadString("Enter the product name: ");
        float productPrice = ReadFloat("Enter the product price: ", "Invalid price. Please enter a non-negative number.");
        int productQuantity = ReadInt("Enter the product quantity: ", "Invalid quantity. Please enter a non-negative integer.");
    
        _inventory.AddProduct(productName, productPrice, productQuantity);
    }

    static void EditProduct()
    {
        bool editMode = true;
        string productName = string.Empty;
        while (editMode)
        {
            productName = ReadString("Enter the product name or cancel to exit edit mode: ");
            if (productName.Equals("cancel", StringComparison.OrdinalIgnoreCase))
            {
                editMode = false;
            }
            else if (_inventory.CheckIfProductExist(productName) == -1)
            {
                Console.WriteLine("Product doesn't exist!");
            }
            else
            {
                break;
            }
        }
        while (editMode)
        {
            Console.Write("""
                          1. Edit Price.
                          2. Edit Quantity.
                          3. Exit Edit Mode.
                          Enter your option: 
                          """);
            if (!int.TryParse(Console.ReadLine(), out int editOption))
            {
                Console.WriteLine("Unknown option");
            }
            else
            {
                EditOptions option = (EditOptions)editOption;
                switch (option)
                {
                    case EditOptions.EditPrice:
                        float productPrice = ReadFloat("Enter the product price: ",
                            "Invalid price. Please enter a non-negative number.");
                        _inventory.EditProductByName(productName, price: productPrice);
                        break;
                    case EditOptions.EditQuantity:
                        int productQuantity = ReadInt("Enter the product quantity: ",
                            "Invalid quantity. Please enter a non-negative integer.");
                        _inventory.EditProductByName(productName, quantity: productQuantity);
                        break;
                    case EditOptions.Exit: 
                        editMode = false;
                        break;
                }
            }
        }
    }

    static void Main()
    {
            
        bool continueRunning = true;

        while (continueRunning)
        {
            PrintMenu();

            if (!int.TryParse(Console.ReadLine(), out int optionInput))
            { 
                Console.WriteLine("Unknown option");
            }
            else
            {
                MenuOptions option = (MenuOptions)optionInput;
                
                switch (option)
                {
                    case MenuOptions.AddProduct:
                        AddProduct();
                        break;
                    case MenuOptions.ViewAllProducts: 
                        _inventory.ViewAllProducts(); 
                        break;
                    case MenuOptions.EditProduct:
                        EditProduct(); 
                        break;
                    case MenuOptions.DeleteProduct:
                        string productName = ReadString("Enter the product name: ");
                        _inventory.DeleteProduct(productName);
                        break;
                    case MenuOptions.SearchProduct:
                        productName = ReadString("Enter the product name: ");
                        _inventory.SearchProduct(productName);
                        break;
                    case MenuOptions.Exit: 
                        continueRunning = false;
                        break;
                    default: 
                        Console.WriteLine("Unknown option"); 
                        break;
                }
            } 
        }
    }
}