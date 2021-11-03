using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace Lab11_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------- Ejercicio 1 -------------------------------------------");

            using (AdventureWorksEntities AWEntities1 = new AdventureWorksEntities())
            {
                var products = AWEntities1.Product;
                IQueryable<string> productNames = from p in products
                                                select p.Name;
                
                Console.WriteLine("Productos:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 2 -------------------------------------------");
    
            using (AdventureWorksEntities AWEntities2 = new AdventureWorksEntities())
            {
                var products2 = AWEntities2.Product;
                IQueryable<string> productNames = products2.Select(p => p.Name);

                Console.WriteLine("Productos:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 3 -------------------------------------------");

            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;

                IQueryable<Product> productsQuery = from p in products
                                                    select p;
                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");
                Console.WriteLine("Productos de tamaño 'L':");
                foreach(var product in largeProducts)
                {
                    Console.WriteLine(product.Name + " - " + product.Size + " - " + product.ProductID);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 4 -------------------------------------------");

            using (AdventureWorksEntities context4 = new AdventureWorksEntities())
            {
                IQueryable<Product> productsQuery4 = from product in context4.Product
                                                     select product;
                Console.WriteLine("Productos:");
                foreach(var prod in productsQuery4)
                {
                    Console.WriteLine(prod.Name);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 5 ------------------------------------------");

            using (AdventureWorksEntities context5 = new AdventureWorksEntities())
            {
                var query5 = from product in context5.Product
                             select new
                             {
                                 ProductId = product.ProductID,
                                 ProudctName = product.Name
                             };
                Console.WriteLine("Informacion de Productos:");
                foreach(var productInfo in query5)
                {
                    Console.WriteLine("Product Id: {0} Product Name: {1}", productInfo.ProductId, productInfo.ProudctName);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 8 ------------------------------------------");

            int orderQtyMin = 2;
            int orderQtyMax = 6;
            using (AdventureWorksEntities context8 = new AdventureWorksEntities())
            {

                var query8 = from order in context8.SalesOrderDetail
                             where order.OrderQty > orderQtyMin && order.OrderQty < orderQtyMax
                             select new
                             {
                                 SalesOrderID = order.SalesOrderID,
                                 OrderQty = order.OrderQty
                             };
                foreach(var order in query8)
                {
                    Console.WriteLine("Order ID: {0} Order Quantity: {1}", order.SalesOrderID, order.OrderQty);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 9 ------------------------------------------");

            String color = "red";
            using (AdventureWorksEntities context9 = new AdventureWorksEntities())
            {
                var query9 = from product in context9.Product
                             where product.Color == color
                             select new
                             {
                                 Name = product.Name,
                                 ProductNumber = product.ProductNumber,
                                 ListPrice = product.ListPrice
                             };
                foreach(var product in query9)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("Product Number: {0}", product.ProductNumber);
                    Console.WriteLine("List Price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 10 ------------------------------------------");

            using (AdventureWorksEntities AWEntities10 = new AdventureWorksEntities())
            {
                int?[] productModelIds = { 19, 26, 118 };
                var products10 = from p in AWEntities10.Product
                               where productModelIds.Contains(p.ProductModelID)
                               select p;
                foreach(var product in products10)
                {
                    Console.WriteLine("{0}: {1}", product.ProductModelID, product.ProductID);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 12 ------------------------------------------");

            using (AdventureWorksEntities context12 = new AdventureWorksEntities())
            {
                IQueryable<Decimal> sortedPrices = from p in context12.Product
                                                   orderby p.ListPrice descending
                                                   select p.ListPrice;
                Console.WriteLine("Lista de precios desde el más alto al más bajo:");
                foreach(Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 14 ------------------------------------------");

            using(AdventureWorksEntities context14 = new AdventureWorksEntities())
            {
                var products14 = context14.Product;
                var query14 = from product in products14
                              group product by product.Style into g
                              select new
                              {
                                  Style = g.Key,
                                  AverageListPrice = g.Average(product => product.ListPrice)
                              };
                foreach(var product in query14)
                {
                    Console.WriteLine("Estilo: {0} Precio Promedio: {1}", product.Style, product.AverageListPrice);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 15 ------------------------------------------");

            using (AdventureWorksEntities context15 = new AdventureWorksEntities())
            {
                var products15 = context15.Product;
                var query15 = from product in products15
                              group product by product.Color into g
                              select new
                              {
                                  Color = g.Key,
                                  ProductCount = g.Count()
                              };
                foreach(var product in query15)
                {
                    Console.WriteLine("Color= {0} \t Cantidad= {1}", product.Color, product.ProductCount);
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("--------------------------------------- Ejercicio 16 ------------------------------------------");

            using (AdventureWorksEntities context16 = new AdventureWorksEntities())
            {
                var orders = context16.SalesOrderHeader;
                var query16 = from order in orders
                              group order by order.SalesPersonID into g
                              select new
                              {
                                  Category = g.Key,
                                  maxTotalDue = g.Max(order => order.TotalDue)
                              };
                foreach(var order in query16)
                {
                    Console.WriteLine("PersonID= {0} \t TotalDue maximo= {1}", order.Category, order.maxTotalDue);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
