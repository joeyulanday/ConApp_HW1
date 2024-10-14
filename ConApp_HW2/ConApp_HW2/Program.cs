using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp_HW2
{
    class InvestmentCalc
    {
        enum TransactionType
        {
            Buy,
            Sell
        }

        class Program
        {
            static void Main(string[] args)
            {

                // Prompt user for nominal (number of securities traded)  
                Console.Write("Input the nominal of the trade:");
                string userInput = Console.ReadLine();
                int nominal = Int32.Parse(userInput); // Note: This example will throw an exception if invalid input is given.  

                // Prompt user for trade price  
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

                // For sell transactions, prompt for original price  
                decimal originalPrice = 0;
                if (trcType == TransactionType.Sell)
                {
                    Console.Write("Enter the original price of the investment: ");
                    while (!decimal.TryParse(Console.ReadLine(), out originalPrice) || originalPrice < 0)
                    {
                        Console.Write("Please enter a valid non-negative decimal for original price: ");
                    }
                }

                // Calculate current value based on transaction type  
                decimal currentValue = 0;
                int sign = (trcType == TransactionType.Buy) ? 1 : -1; // 1 for Buy, -1 for Sell  
                currentValue = sign * nominal * tradePrice;

                // Calculate profit/loss for sell transactions using ternary operator  
                decimal profitLossFactor = (trcType == TransactionType.Sell) ? 1 : 0; // 1 for Sell, 0 for Buy  
                decimal profitLoss = profitLossFactor * (tradePrice - originalPrice) * nominal;

                // Output the current value and profit/loss if applicable  
                Console.WriteLine($"The current value of your investment is: ${currentValue:F2}");
                if (trcType == TransactionType.Sell)
                {
                    Console.WriteLine($"Profit/Loss from the transaction is: ${profitLoss:F2}");
                }

                Console.ReadKey();
            }
        }
    }
}
