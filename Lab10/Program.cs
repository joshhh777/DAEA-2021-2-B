using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwndDataContext context = new NorthwndDataContext();

            //var query = from p in context.Products
            //            where p.Categories.CategoryName == "Beverages"
            //            select p;
            //var query = from p in context.Products
            //            where p.UnitPrice < 20
            //            select p;

            //Products p = new Products();
            //p.ProductName = "Peruvian Coffe";
            //p.SupplierID = 20;
            //p.CategoryID = 1;
            //p.QuantityPerUnit = "10pkg";
            //p.UnitPrice = 25;
            //context.Products.InsertOnSubmit(p);
            //context.SubmitChanges();

            //var query = from pro in context.Products
            //            where pro.CategoryID == 1
            //            select pro;


            // -----------------Listar ID, nombre de productos que incluye la palabra queso-----------------------------
            Console.WriteLine("---------------------------------nombre de productos que incluye la palabra queso----------------------------------------------------------------------");

            var queryqueso = from proqueso in context.Products
                       where proqueso.ProductName.Contains("queso")
                             select proqueso;

            foreach (var queso in queryqueso)
            {
                Console.WriteLine("ID={0} \t Name={1}", queso.ProductID, queso.ProductName);
            }

            // -----------------Listar ID, nombre, presentación (QuantityPerUnit) productos cuya presentación sea paquetes (pkg o pkgs)-----------------------------
            Console.WriteLine("---------------------------------productos cuya presentación sea paquetes (pkg o pkgs)----------------------------------------------------------------------"); 

            var querypresentacion = from proqpresentacion in context.Products
                             where proqpresentacion.QuantityPerUnit.Contains("pkg") || proqpresentacion.QuantityPerUnit.Contains("pkg")
                             select proqpresentacion;

            foreach (var presentacion in querypresentacion)
            {
                Console.WriteLine("ID={0} \t Name={1} \t QuantityPerUnit={2}", presentacion.ProductID, presentacion.ProductName, presentacion.QuantityPerUnit);
            }

            //--------------Listar nombre, precio de productos que empiezan con la letra A---------------------------
            Console.WriteLine("-----------------Listar nombre, precio de productos que empiezan con la letra A------------------------");

            var queryprimero = from proprimera in context.Products
                                    where proprimera.ProductName.StartsWith("A")
                                    select proprimera;

            foreach (var primero in queryprimero)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Price={2}", primero.ProductID, primero.ProductName, primero.UnitPrice);
            }

            //-------------- Listar ID, nombre de productos sin stock ---------------------------
            Console.WriteLine("----------------------Listar ID, nombre de productos sin stock---------------------------");

            var querysinStock = from prostock in context.Products
                                where prostock.UnitsInStock == 0
                                select prostock;

            foreach (var stock in querysinStock)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Stock={2}", stock.ProductID, stock.ProductName, stock.UnitsInStock);
            }

            //-------------- Listar ID, nombre de productos descontinuados ---------------------------
            Console.WriteLine("----------------------Listar ID, nombre de productos descontinuados---------------------------");

            var queryDescontinuados = from prodescontinuado in context.Products
                                      where prodescontinuado.Discontinued == true
                                      select prodescontinuado;

            foreach (var descontinuado in queryDescontinuados)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Discontinued={2}", descontinuado.ProductID, descontinuado.ProductName, descontinuado.Discontinued);
            }

            //--------------------- Modificar el valor de un Producto -------------------------------------

            var query = from pro in context.Products
                        where pro.ProductName == "Tofu  "
                        select pro;

            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Price={2} \t Stock={3} \t Discontinued={4}", prod.ProductID, prod.ProductName, prod.UnitPrice, prod.UnitsInStock, prod.Discontinued);
            }
            var product = (from p in context.Products
                           where p.ProductName == "Tofu"
                           select p).FirstOrDefault();
            product.UnitPrice = 100;
            product.UnitsInStock = 15;
            product.Discontinued = true;
            context.SubmitChanges();

            var query2 = from pro2 in context.Products
                         where pro2.ProductName == "Tofu "
                         select pro2;

            foreach (var prod2 in query)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Price={2} \t Stock={3} \t Discontinued={4}", prod2.ProductID, prod2.ProductName, prod2.UnitPrice, prod2.UnitsInStock, prod2.Discontinued);
            }

            //------------------------------ Eliminar un Producto ---------------------------------------

            //var productEliminar = (from p3 in context.Products
            //                       where p3.ProductName == "Tofu"
            //                       select p3).FirstOrDefault();
            // context.Products.DeleteOnSubmit(productEliminar);
            // context.SubmitChanges();

            // var queryEliminar = from pro4 in context.Products
            //                     where pro4.CategoryID == 1
            //                     select pro4;

            // foreach (var prod4 in queryEliminar)
            // {
            //     Console.WriteLine("ID={0} \t Name={1} \t Price={2} \t Stock={3} \t Discontinued={4}", prod4.ProductID, prod4.ProductName, prod4.UnitPrice, prod4.UnitsInStock, prod4.Discontinued);
            // }

            //--------------------------------------------- TABLA SUPPLIERS ----------------------------------------------
            //Listar ID, nombre de producto, nombre del proveedor (Suppliers/CompanyName) productos de los productos de la categoría “Dairy Products”
            Console.WriteLine("----------Listar los productos de los proveedores ubicados en USA------------------");
            var querysupplier = from supp in context.Suppliers
                                join app in context.Products
                                on supp.SupplierID equals app.SupplierID
                                where supp.City == "USA"
                                select new
                                {
                                    app.ProductID,
                                    app.ProductName,
                                    app.SupplierID,
                                    supp
                                };

            foreach (var suplier in querysupplier)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Supplier={2}", suplier.ProductID, suplier.ProductName, suplier.SupplierID);
            }


            Console.ReadKey();
        }
    }
}
