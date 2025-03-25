namespace Question_1
{
    class Product
    {
        private int ProductID;
        private string Name;
        private decimal Price;
        private int QuantityInStocke;


        //method 1
        public void CheckQuantity(int qunatity)
        {
            if (qunatity > 0 && qunatity < 100)
            {
                QuantityInStocke = qunatity;
            }
            else
            {
                Console.WriteLine("Wale nu ayhi kam ay");
                QuantityInStocke = 0;
            }
        }

        public Product(int PID, string name, decimal Price, int qunatity)
        {
            ProductID = PID;
            this.Name = name;
            this.Price = Price;
            CheckQuantity(qunatity);
        }




        //method 3
        public Product(int PID, string name, decimal Price) : this(PID, name, Price, 0) { }
        public Product(int PID, int qunatity) : this(PID, "", 0, qunatity) { }
        public Product() : this(0, "", 0, 0) { }
        public Product(int PID, string name) : this(PID, name, 0, 0) { }




        ////Constructor Chainnig method 4 here we go
        //public Product(int P_ID=1, string name="", decimal Price=0.0 int qunatity=0)
        //{
        //    ProductID = P_ID;
        //    this.Name = name;
        //    this.Price = Price;
        //    if (qunatity > 0 && qunatity < 100)
        //    {
        //        QuantityInStocke = qunatity;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Wale no aihi kam ae");
        //        QuantityInStocke = 0;
        //    }




       //getter-setter
        public int P_ID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }
        public decimal PriceValue
        {
            get { return Price; }
            set { Price = value; }
        }
        public string ProductName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int qunatity
        {
            get { return QuantityInStocke; }
            set { CheckQuantity(value); }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product ID: {ProductID}, Name: {Name}, Price: {Price}, Quantity: {QuantityInStocke}");
        }

        //Destructor "Sb ka khatama"
        ~Product()
        {
            Console.WriteLine($"Product {Name} is Khatam Shudh");

        }
    }
    class Store
    {
        private string StoreName;
        private string Location;
        private Product[] Products;
        private int ProductCount;

        public Store(string StoreName, string Location)
        {
            this.StoreName = StoreName;
            this.Location = Location;
            this.Products = new Product[4];
            this.ProductCount = 0;
        }

        public void AddProduct(Product product)
        {
            if (ProductCount < Products.Length)
            {
                Products[ProductCount] = product;
                ProductCount++;
            }
            else
            {
                Console.WriteLine("Naa ji naa.. Hun Nahi.");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine($"Store: {StoreName}, Location: {Location}");
            Console.WriteLine("Products Availabe:");
            for (int i = 0; i < ProductCount; i++)
            {
                Products[i].DisplayInfo();
            }
        }

        ~Store()
        {
            Console.WriteLine("FBI.... Raid Pa gai je");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store s1 = new Store("Nimo ka Khoka", "Atlantic Ocean");

            //Inputs-------------

            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"Enter Details For Product {i}");
                Product product = new Product();
                Console.WriteLine("Enter ProductID:");
                product.P_ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Product Name:");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Product Price:");
                product.PriceValue = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Quantity In Stock:");
                product.qunatity = Convert.ToInt32(Console.ReadLine());
                s1.AddProduct(product);
                Console.ReadKey();
            }

            s1.DisplayProducts();
            Console.ReadKey();


        }
    }
}