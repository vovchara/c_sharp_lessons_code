using MonDbCons0.model;
using System;
using System.IO;

namespace MonDbCons0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var service = new PhonesDbService();

            //byte[] fileBytes = File.ReadAllBytes("../../../ibiza.jpg");

            //service.StoreImage("d7b5aca1cdc17f1152636d77", fileBytes, "just_car");

            //var device = service.Get("d7b5aca1cdc17f1152636d77");
            //var bytesImg = service.GetImage(device);
            //File.WriteAllBytes("../../../car_car_ibiza.jpg", bytesImg);

            Console.WriteLine("DONE");





            //var device = service.Get("d7b5aca1cdc17f1152636d77");
            //device.Price = 5000;
            //service.Update(device);

            //var device = service.Get("d7b5aca1cdc17f1152636d77");

            //Console.WriteLine($"Company={device.Company} and Model={device.Model}. Price is={device.Price}");




            //service.ShowCollection();

            //var myPhone = new PhoneModel();
            //myPhone.Company = "Siemens";
            //myPhone.Model = "S65";
            //myPhone.Price = 25;
            //myPhone.IsLegal = false;
            ////myPhone.Id = "d7b5aca1cdc17f1152636d77";

            //Console.WriteLine($"ID before insert:{myPhone.Id}");

            //service.Create(myPhone);

            //Console.WriteLine($"Done. Saved ID:{myPhone.Id}");


        }
    }
}
