using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);
                    Console.WriteLine(result.TransactionAmount);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"Null  for payment number {i}.");
                    continue;
                }
                catch (Exception ex)
                {
                    if (ex is IndexOutOfRangeException || ex is FormatException)
                    {
                        Console.WriteLine($"Payment skipped for payment with {i} items.");
                        continue;
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
