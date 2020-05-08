using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace tinycrm
{
    class Program
    {

        static void Main(string[] args)
        {
            var tinycrmdbcontext = new TinyCrmDbContext();

            string[] productsFromFile;//saves the lines of the csv
            try
            {
                productsFromFile = File.ReadAllLines("products.txt");
            }
            catch (Exception)
            {
                return;
            }

            if (productsFromFile.Length == 0)
            {
                return;
            }

            var productsArray = new Product[productsFromFile.Length];
            var TotalProducts = new List<Product>();

            for (var i = 0; i < productsFromFile.Length; i++)
            {
                var isDuplicate = false;
                var values = productsFromFile[i].Split(';');

                foreach (var p in productsArray)
                {
                    if (p != null && p.ProductId.Equals(values[0]))
                    {
                        isDuplicate = true;
                    }
                }

                if (!isDuplicate)
                {
                    var product = new Product()
                    {
                        ProductId = values[0],
                        Name = values[1],
                        Description = values[2],
                        Price = AddPricestoProducts()
                    };

                    productsArray[i] = product;

                }
            }

            foreach (var p in productsArray)
            {
                if (p != null)
                {
                    //Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");  
                    TotalProducts.Add(p);
                }
            }

            foreach(var p in TotalProducts)
            {
                Console.WriteLine($"Id: {p.ProductId} ,Name: {p.Name} ,Price: {p.Price}");
                //tinycrmdbcontext.Add(p);
            }
            //tinycrmdbcontext.SaveChanges();

            //var customer = new Customer()
            //{
            //    FirstName = "Geroge",
            //    LastName = "Oikonomou",
            //    Email = "goikonomou@gmail.com",
            //    Created = DateTime.Now

            //};

            //tinycrmdbcontext.Add(customer);

            //var customer1 = new Customer()
            //{
            //    FirstName = "Xaris",
            //    LastName = "Mpouras",
            //    Email = "mpouras.gr",
            //    Created = DateTime.Now
            //};

            //tinycrmdbcontext.Add(customer1);

            //var petrogiannos = new Customer()
            //{
            //    FirstName = "Dimitris",
            //    LastName = "Petrogiannos",
            //    Email = "petrogiannos.gr",
            //    Created = DateTime.Now
            //};

            //tinycrmdbcontext.Add(petrogiannos);
            //tinycrmdbcontext.SaveChanges();

            var customerlist = tinycrmdbcontext.Set<Customer>();
            var productlist = tinycrmdbcontext.Set<Product>();

        }

        public static IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options, TinyCrmDbContext dbContext)
        {
            if (options == null)
            {
                return null;
            }

            var query = dbContext
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Firstname))
            {
                query = query.Where(c => c.FirstName == options.Firstname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }

        public static decimal AddPricestoProducts()
        {
            var rnd = new Random();
            return (decimal)Math.Round(rnd.NextDouble(), 2) * 10M;
        }
    }
    
}           
/*string[] productsFromFile;//saves the lines of the csv

            try
            {
                productsFromFile = File.ReadAllLines("products.txt");
            }
            catch (Exception)
            {
                return;
            }

            if (productsFromFile.Length == 0)
            {
                return;
            }

            var productsArray = new Product[productsFromFile.Length];
            var TotalProducts = new List<Product>();

            for (var i = 0; i < productsFromFile.Length; i++)
            {
                var isDuplicate = false;
                var values = productsFromFile[i].Split(';');

                foreach (var p in productsArray)
                {
                    if (p != null && p.ProductId.Equals(values[0]))
                    {
                        isDuplicate = true;
                    }
                }

                if (!isDuplicate)
                {
                    var product = new Product()
                    {
                        ProductId = values[0],
                        Name = values[1],
                        Description = values[2],
                        Price = GetRandomPrice()
                    };

                    productsArray[i] = product;

                }
            }

            foreach (var p in productsArray)
            {
                if (p != null)
                {
                    //Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");  
                    TotalProducts.Add(p);
                }
            }

            var random = new Random();

            var order1 = new List<Product>();
            var order2 = new List<Product>();

            var Order1 = new Order();
            var Order2 = new Order();

            var cust1 = new Customer();
            var cust2 = new Customer();

            for (int j = 1; j <= 10; j++)
            {
                //Choose a random product for 1st customer
                var randomproduct1 = TotalProducts[random.Next(TotalProducts.Count)];
                order1.Add(randomproduct1);


                //Choose a random product for 2st customer
                var randomproduct2 = TotalProducts[random.Next(TotalProducts.Count)];
                order2.Add(randomproduct2);
            }
            Order1.Products = order1;
            Order2.Products = order2;

            var totalorders = order1.Union(order2).ToList();
            //FiveMostSoldProducts(totalorders);


            (cust1.ListOfOrders).Add(Order1);
            (cust2.ListOfOrders).Add(Order2);
            foreach (var i in cust2.ListOfOrders)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"First customer has paid {Order1.TotalAmount}");
            Console.WriteLine($"Second customer has paid {Order2.TotalAmount}");

            var ListOfCustomers = new List<Customer>();
            ListOfCustomers.Add(cust1);
            ListOfCustomers.Add(cust2);
            FindMostValuableCustomer(ListOfCustomers);
            Console.WriteLine(cust1.TotalGross);
            */
//Added new code for migrations



// test();


//public static decimal GetRandomPrice()
//{
//   var random = new Random();
//  var randomNumber = random.NextDouble() * 100;
//  var roundedNumber = Math.Round(randomNumber, 2);

//return (decimal)roundedNumber;
//}

//public static void FindMostValuableCustomer(List<Customer> list)
//{

//  var templist = list.Select(x => x.TotalGross).ToList();
//Console.WriteLine($"The most valuable customer(MVC) is customer number {templist.IndexOf(templist.Max())+1}");
//}

//public static void FiveMostSoldProducts(List<Product> list)
//{
//  var most = list.GroupBy(i => i.ProductId)
//           .OrderByDescending(grp => grp.Count())
//             .Select(grp => grp.Key)
//               .Take(5);

// foreach (var item in most)
//{
// Console.WriteLine(item);
//}

// }


