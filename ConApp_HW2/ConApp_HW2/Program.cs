using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp_HW2
{
    enum TransactionType { Buy, Sell}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the nominal of the trade:");
            string userInput = Console.ReadLine();
            int nominal = Int32.Parse(userInput);

            TransactionType trcType;
            userInput = Console.ReadLine();
            trcType = (TransactionType)Enum.Parse(typeof(TransactionType), userInput, true);

            Console.Write("Enter the trade price: ");
            decimal tradePrice = 0;
            while (!decimal.TryParse(Console.ReadLine(), out tradePrice) || tradePrice < 0)
            {
                Console.Write("Please enter a valid non-negative decimal for trade price: ");
            }

            // Prompt user for transaction type  
            Console.Write("Enter the transaction type (Buy/Sell): ");
            userInput = Console.ReadLine();

            TransactionType trcType;
            try
            {
                trcType = (TransactionType)Enum.Parse(typeof(TransactionType), userInput, true);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid transaction type. Please enter 'Buy' or 'Sell'.");
                return;
            }

            // Calculate current value based on transaction type  
            decimal currentValue = 0;
            int sign = (trcType == TransactionType.Buy) ? 1 : -1; // 1 for Buy, -1 for Sell  

            // Calculate the current value using the formula CV = Sign × Nominal × Price  
            currentValue = sign * nominal * tradePrice;

            // Output the current value  
            Console.WriteLine($"The current value of your investment is: ${currentValue:F2}");

            // Wait for user input before closing  
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
