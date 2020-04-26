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
                TransactionModel result = new TransactionModel();
                try
                {
                    result = paymentProcessor.MakePayment($"Demo{ i }", i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Payment skipped for payment with {i} items.");
                    continue;
                }

                if (result == null)
                {
                    Console.WriteLine($"Null  for payment number {i}.");
                }
                else
                {
                    Console.WriteLine(result.TransactionAmount);
                }
            }
            Console.ReadLine();
        }
    }
}
