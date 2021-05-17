using System;
using System.Collections;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<decimal> validCoins = new List<decimal>() { .1M, .25M, .5M };
            decimal insertCoinValue = 0.0M;
            bool isValidMoney = false;
            Console.WriteLine("These are the products Available. ");
            List<Product> products = new List<Product>()
                {
                    new Product(){Id=1,Name="cola", Cost=1.00M,Currency="$"},
                    new Product(){Id=2,Name="Chips", Cost=0.50M,Currency="$"},
                    new Product(){Id=3,Name="Candy", Cost=0.65M,Currency="$"}
                };
            foreach (var product in products)
            {
                Console.WriteLine(string.Format("{0}.{1}     for {2}{3}", product.Id, product.Name, product.Currency, product.Cost));
            }
            Console.WriteLine("choose one product and enter respective number");
            string choosenProduct = Console.ReadLine();
            Console.WriteLine(string.Format("You choosen {0} product. Please insert money", products.Find(x => x.Id == Convert.ToInt32(choosenProduct)).Name));
            decimal choosenProductCost = products.Find(x => x.Id == Convert.ToInt32(choosenProduct)).Cost;
            while (!isValidMoney)
            {
                string insertCoin = Console.ReadLine();

                bool isExists = validCoins.Contains(Convert.ToDecimal(insertCoin));
                if (isExists)
                {
                    insertCoinValue += Convert.ToDecimal(insertCoin);
                    Console.WriteLine(string.Format("Inserted total amount : {0} and Please insert coin", insertCoinValue));
                    if (insertCoinValue >= choosenProductCost)
                    {
                        isValidMoney = true;
                        Console.WriteLine("Dispense the product. Thank you");
                        insertCoinValue = 0.0M;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Insert valid coin.Return coin value: {0} and Total Insertion : {1}", insertCoin, insertCoinValue));
                }
            }

        }


    }
}
