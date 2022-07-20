using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            
        }

        //private static void NewMethod()
        //{
        //    PaymentManager paymentManager = new PaymentManager(new EfPaymentDal());
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    var payments = paymentManager.GetAll();
        //    var products = productManager.GetAll();
        //    var users = userManager.GetAll();
        //    foreach (var item in products.Data)
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }
        //}
    }
}
