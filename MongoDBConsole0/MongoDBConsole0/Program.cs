using MongoDBConsole0.model;
using System;
using System.Threading.Tasks;

namespace MongoDBConsole0
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var db = new ProductService();

            //var myProduct = new ProductModel();
            //myProduct.Id = "61c4844ef96951496693a30f"
            //myProduct.Name = "3310";
            //myProduct.Price = 100500;
            //myProduct.Company = "Nokia";
            //await db.Create(myProduct);

            var myProd = await db.GetProduct("61c4844ef96951496693a30f");
            Console.WriteLine( $"company={myProd.Company}. model={myProd.Name}");
            Console.WriteLine("DONE!");
        }
    }
}
