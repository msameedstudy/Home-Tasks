using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    class Product
    {
        public int ProductID;
        public string Name;
        public double Price;

        public Product(int pid, string name, double price)
        {
            Name = name;
            ProductID = pid;
            Price = price;
        }

    }

    class ShoppingCart
    {
        private static int cartCounter = 1;
        public int CartID;
        public string CustomerName;
        public double TotalPrice;
        public Product[] Product = new Product[3];
        public int productCount;

        public ShoppingCart()
        {
            CartID = cartCounter++;
            CustomerName = "";
            TotalPrice = 0.0;
            productCount = 0;
        }

        public void AddProduct(Product product)
        {
            if (productCount < Product.Length)
            {
                Product[productCount++] = product;
                TotalPrice += product.Price;
                Console.WriteLine("Your Product Has Successfully Added.");
            }
            else
            {
                Console.WriteLine("Cart is Full Cannot Add More Products.");
            }
        }

        public void RemoveProduct(int productID)
        {
            for (int i = 0; i < productCount; i++)
            {
                if (Product[i] != null && Product[i].ProductID == productID)
                {
                    TotalPrice -= Product[i].Price;
                    Console.WriteLine($"{Product[i].Name} Removed From The Cart.");
                    for (int j = i; j < productCount - 1; j++)
                    {
                        Product[j] = Product[j + 1];
                    }
                    Product[productCount - 1] = null;
                    productCount--;
                    return;
                }
            }
            Console.WriteLine("Product Not Found");
        }



        public void DisplayCart()
        {
            Console.WriteLine($"Cart ID: {CartID}, Customer: {CustomerName}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Products in Cart");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"ID: {Product[i].ProductID}, Name: {Product[i].Name}, Price: {Product[i].Price}");
            }
            Console.WriteLine($"Total Price: {TotalPrice}\n");
           
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart1 = new ShoppingCart();
           
            cart1.CustomerName = "Pappu Pan Wala\n";

            Product p1 = new Product(1, "Katha 500g", 1000);
            Product p2 = new Product(2, "Chuna 500mg", 14100);
            Product p3 = new Product(3, "Pan Patta (2kg)", 200);

            cart1.AddProduct(p1);
            cart1.AddProduct(p2);
            cart1.AddProduct(p3);
            Console.WriteLine("------------------------------------------------------------------------");
            cart1.DisplayCart();

            Console.WriteLine("Enter Product ID for the product you want to remove");
            int a = Convert.ToInt32(Console.ReadLine());
            cart1.RemoveProduct(a);
            cart1.DisplayCart();
            Console.ReadKey();
        }
    }
}