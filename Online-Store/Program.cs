namespace Online_Store
{
    #region Product

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    #endregion

    #region Delegates

    public delegate bool ProductCondition(Product p);

    #endregion



    internal class Program
    {
        static List<Product> catalog = new List<Product>
        {
            new Product { Id=1,  Name="Laptop",       Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2,  Name="Phone",        Category="Electronics", Price=800,  Stock=25 },
            new Product { Id=3,  Name="T-Shirt",      Category="Clothing",    Price=30,   Stock=100 },
            new Product { Id=4,  Name="Jeans",        Category="Clothing",    Price=60,   Stock=50 },
            new Product { Id=5,  Name="Chocolate",    Category="Food",        Price=5,    Stock=200 },
            new Product { Id=6,  Name="Coffee Beans", Category="Food",        Price=15,   Stock=80 },
            new Product { Id=7,  Name="C# Book",      Category="Books",       Price=45,   Stock=30 },
            new Product { Id=8,  Name="Novel",        Category="Books",       Price=20,   Stock=60 },
            new Product { Id=9,  Name="Headphones",   Category="Electronics", Price=150,  Stock=40 },
            new Product { Id=10, Name="Jacket",       Category="Clothing",    Price=120,  Stock=15 }
        };
        static void Main(string[] args)
        {
            
        }
        #region List Search
        static List<Product> SearchWithCustomDelegate(List<Product> products, ProductCondition condition)
        {
            List<Product> result = new List<Product>();
            foreach (Product p in products)
            {
                if (condition(p))
                    result.Add(p);
            }
            return result;
        }

        #endregion

        #region Product Search

        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (Product p in products)
            {
                if (filter(p))
                    result.Add(p);
            }
            return result;
        }

        static void PrintSearchResult(string title, List<Product> products)
        {
            Console.WriteLine("-----" + title + " ------=-");
            foreach (Product p in products)
                Console.WriteLine(p.Name + " - $" + p.Price + " (Stock: " + p.Stock + ")");
            Console.WriteLine();
        }
        static void RunTask01()
        {
            PrintSearchResult("Electronics",
                SearchProducts(catalog, delegate (Product p) { return p.Category == "Electronics"; }));
            PrintSearchResult("Under $50",
                SearchProducts(catalog, delegate (Product p) { return p.Price < 50; }));
            PrintSearchResult("In Stock",
                SearchProducts(catalog, p => p.Stock > 0));
            PrintSearchResult("Clothing Under $100",
                SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100));
        }

        #endregion


        

        #region Print Reports
        static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product p in products)
                action(p);
        }
        #endregion
    }
}
