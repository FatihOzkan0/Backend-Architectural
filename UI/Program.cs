using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            
            //foreach(var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            var result = productManager.GetProductsDetails();

            if(result.Success==true)
            {
                foreach (var p in result.Data)
                {
                    Console.WriteLine(p.ProductName + " - " + p.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }
    }
}
