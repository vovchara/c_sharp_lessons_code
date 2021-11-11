using Newtonsoft.Json;
using System;
using System.IO;


namespace CSharpLess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //DisksIO();
            //JsonConverterExample();
            //SerializeJsonExample();
            //DeserializeJsonExample();
            string writePath = @"C:\www.json";

            using (StreamReader sr = new StreamReader(writePath))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            //string text = "Привет мир!\nПока мир...";
            //try
            //{
            //    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            //    {
            //        sw.WriteLine(text);
            //    }

            //    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            //    {
            //        sw.WriteLine("Дозапись");
            //        sw.Write(4.5);
            //    }
            //    Console.WriteLine("Запись выполнена");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        private static void DisksIO()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }

        private static void JsonConverterExample()
        {
            string stringjsonData = "{'FirstName': 'Jignesh', 'LastName': 'Trivedi'}";
            var myDetails = JsonConvert.DeserializeObject<MyDetail>(stringjsonData);
            Console.WriteLine($"Hi, {myDetails.FirstName} {myDetails.LastName}");
        }

        private static void SerializeJsonExample()
        {
            Product product = new Product();
            product.Name = "Apple";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };

            string json = JsonConvert.SerializeObject(product);
            // {
            //   "Name": "Apple",
            //   "Expiry": "2008-12-28T00:00:00",
            //   "Sizes": [
            //     "Small"
            //   ]
            // }
        }

        private static void DeserializeJsonExample()
        {
            string json = @"{
                            'Name': 'Bad Boys',
                            'CreationDate': '1995-4-7T00:00:00',
                            'Genres': [
                                    'Action',
                                    'Comedy'
                                      ]
                            }";

            Movie m = JsonConvert.DeserializeObject<Movie>(json);

            string name = m.Name;
            // Bad Boys
        }
    }

    public class Movie
    {
        public string Name { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime ReleaseDate { get; set; }

        public string[] Genres { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public string[] Sizes { get; set; }
    }


    public class MyDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
