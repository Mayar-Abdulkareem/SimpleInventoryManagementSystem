// See https://aka.ms/new-console-template for more information

namespace InventorySystem;

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
    
    static int ReadInt(string prompt, string errorMessage)
    {
        int value;
        bool isValid;
        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
            if (!isValid || value < 0)
            {
                Console.WriteLine(errorMessage);
            }
        } while (!isValid || value < 0);
        return value;
    }
    
    static float ReadFloat(string prompt, string errorMessage)
    {
        float value;
        bool isValid;
        do
        {
            Console.Write(prompt);
            isValid = float.TryParse(Console.ReadLine(), out value);
            if (!isValid || value < 0)
            {
                Console.WriteLine(errorMessage);
            }
        } while (!isValid || value < 0);
        return value;
    }
    
    static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    
    static void AddProduct()
    {
        string productName = ReadString("Enter the product name: ");
        float productPrice = ReadFloat("Enter the product price: ", "Invalid price. Please enter a non-negative number.");
        int productQuantity = ReadInt("Enter the product quantity: ", "Invalid quantity. Please enter a non-negative integer.");
    
        _inventory.AddProduct(productName, productPrice, productQuantity);
    }
        static void Main()
        {
            
            bool continueRunning = true;

            while (continueRunning)
            {
                PrintMenu();

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Unknown option");
                }
                else
                {
                    switch (option)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            _inventory.ViewAllProducts();
                            break;
                        case 6:
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