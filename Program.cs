﻿using System;
using System.IO;
using System.Collections.Generic;

namespace RegistratoreCassa
{
    class Program
    {
        static void Main(string[] args)
        {
            var Time = DateTime.Now; 
            Console.WriteLine("Registratore di cassa esempio");
            Console.WriteLine("a fine registrazione prodotti si creerà un file tipo .txt dove alloggeranno tutti i dati raccolti");
            int NumberProducts = HowManyProducts();
            List<string> NameProducts = new List<string>();
            List<float> PriceProducts = new List<float>();
            (NameProducts, PriceProducts) = ProductsSubscription(NumberProducts);
            Product InfoProduct = new Product(NameProducts, PriceProducts);
            MakeReceipt(InfoProduct.GetNameProducts(), InfoProduct.GetPriceProducts(), Time, NumberProducts);
        }

        public static int HowManyProducts()
        {
            int ProductsNumber = 0;
            Console.WriteLine("Select How Many Products need to pay");
            while(ProductsNumber == 0)
            {
                ProductsNumber = Convert.ToInt32(Console.ReadLine());
            }
            return ProductsNumber;
        }
        public static (List<string>, List<float>) ProductsSubscription(int numerproduct)
        {
            List<string> productsname = new List<string>();
            List<float> productsprice = new List<float>();
            string name = "";
            float price = 0;
            for (int i = 0; i < numerproduct; i++)
            {
                Console.WriteLine("Insert the name of the " + (i+1) + " product");
                name = Console.ReadLine();
                productsname.Add(name);
                Console.WriteLine("Insert the price of the " + (i+1) + " product");
                price = float.Parse(Console.ReadLine());
                productsprice.Add(price);
            }
            return (productsname, productsprice);
        }
        public static void MakeReceipt (
            List<string> nameproduct,
            List<float> priceproduct,
            System.DateTime timenow,
            int numberproduct
            )
        {
            string PathReceipt = @"D:\Cartella Utente\Desktop\receipt.txt";
            using (StreamWriter rw = File.CreateText(PathReceipt))
            {
                rw.WriteLine(timenow);
                for(int i = 0; i < numberproduct; i++)
                {
                    rw.WriteLine(nameproduct[i]);
                    rw.WriteLine(priceproduct[i]);
                }

            }
        }
    }
    class Product
    {
        List<string> NomeProdotto = new List<string> ();
        List<float> PrezzoProdotto = new List<float> ();

        public Product(List<string> nomeprod, List<float> prezzoprod)
        {
            foreach(string nome in nomeprod)
            {
                NomeProdotto.Add(nome);
            }
            foreach(float prezzo in prezzoprod)
            {
                PrezzoProdotto.Add(prezzo);
            }
        }
        public List<string> GetNameProducts()
        {
            return NomeProdotto;
        }
        public List<float> GetPriceProducts()
        {
            return PrezzoProdotto;
        }
    }
}
