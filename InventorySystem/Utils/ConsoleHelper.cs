namespace InventorySystem;

public class ConsoleHelper
{
    /// <summary>
    /// Read a positive integer
    /// </summary>
    /// <param name="prompt"> will be printed before reading the value </param>
    /// <param name="errorMessage"> if the user enter a non-valid value</param>
    /// <returns></returns>
    public static int ReadInt(string prompt, string errorMessage)
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
    
    /// <summary>
    /// Read a positive float
    /// </summary>
    /// <param name="prompt"> will be printed before reading the value </param>
    /// <param name="errorMessage"> if the user enter a non-valid value</param>
    /// <returns></returns>
    public static float ReadFloat(string prompt, string errorMessage)
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
    
    /// <summary>
    /// Read a non nullable string that doesn't consis of only white spaces or 
    /// </summary>
    /// <param name="prompt"> will be printed before reading the value </param>
    /// <returns></returns>
    public static string ReadString(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = (Console.ReadLine() ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("The input cannot be empty or consist of only whitespace. Please enter a valid value.");
            }
        }
        while (string.IsNullOrWhiteSpace(input)); 

        return input;
    }
}