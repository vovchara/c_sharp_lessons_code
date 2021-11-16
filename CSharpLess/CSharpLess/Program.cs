using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CSharpLess
{
    // класс и его члены объявлены как public
    //[Serializable]
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    // стандартный конструктор без параметров
    //    public Person()
    //    { }

    //    public Person(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //}

    class Person
    {
        public string Name;
        public string Occupation;
    }


    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            using var httpClient = new HttpClient();

            byte[] imageBytes = await httpClient.GetByteArrayAsync("https://s.dou.ua/CACHE/images/img/static/companies/Horizontal_ON_WHITE/b31ef3218956e947ff40e3dda31faa9a.png");

            string localFilename = "C:\\111test_favicon.png";
            Console.WriteLine(localFilename);
            File.WriteAllBytes(localFilename, imageBytes);








            //var person = new Person() { Name = "John Doe", Occupation = "gardener" };

            //var json = JsonConvert.SerializeObject(person);

            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //using var client = new HttpClient();

            //var response = await client.PostAsync("https://httpbin.org/post", data);
            //string result = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);



            //Console.ReadLine();









            //using (var client = new HttpClient())
            //{
            //    var url = "http://webcode.me";
            //    var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            //    Console.WriteLine(result);

            //}




















            // объект для сериализации
            //Person person = new Person("Tom", 29);
            // Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            //XmlSerializer formatter = new XmlSerializer(typeof(Person));

            // получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("C://persons.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, person);

            //    Console.WriteLine("Объект сериализован");
            //}

            // десериализация
            //using (FileStream fs = new FileStream("C://persons.xml", FileMode.OpenOrCreate))
            //{
            //    Person newPerson = (Person)formatter.Deserialize(fs);

            //    Console.WriteLine("Объект десериализован");
            //    Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            //}

            //Console.ReadLine();



















            //var xdoc = XDocument.Load("C://phones.xml");
            //foreach (var phoneElement in xdoc.Element("phones").Elements("phone"))
            //{
            //    var nameAttribute = phoneElement.Attribute("name");
            //    var companyElement = phoneElement.Element("company");
            //    var priceElement = phoneElement.Element("price");

            //    if (nameAttribute != null && companyElement != null && priceElement != null)
            //    {
            //        Console.WriteLine($"Смартфон: {nameAttribute.Value}");
            //        Console.WriteLine($"Компания: {companyElement.Value}");
            //        Console.WriteLine($"Цена: {priceElement.Value}");
            //    }
            //    Console.WriteLine();
            //}


















            //XDocument xdoc = new XDocument();
            //// создаем первый элемент
            //XElement iphone6 = new XElement("phone");
            //// создаем атрибут
            //XElement iphoneNameAttr = new XElement("name", "iPhone 6");
            //XElement iphoneCompanyElem = new XElement("company", "Apple");
            //XElement iphonePriceElem = new XElement("price", "40000");
            //// добавляем атрибут и элементы в первый элемент
            //iphone6.Add(iphoneNameAttr);
            //iphone6.Add(iphoneCompanyElem);
            //iphone6.Add(iphonePriceElem);

            //// создаем второй элемент
            //XElement galaxys5 = new XElement("phone");
            //XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            //XElement galaxysCompanyElem = new XElement("company", "Samsung");
            //XElement galaxysPriceElem = new XElement("price", "33000");
            //galaxys5.Add(galaxysNameAttr);
            //galaxys5.Add(galaxysCompanyElem);
            //galaxys5.Add(galaxysPriceElem);
            //// создаем корневой элемент
            //XElement phones = new XElement("phones");
            //// добавляем в корневой элемент
            //phones.Add(iphone6);
            //phones.Add(galaxys5);
            //// добавляем корневой элемент в документ
            //xdoc.Add(phones);
            ////сохраняем документ
            //xdoc.Save("C://phones.xml");















            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load("C://test1.xml");
            //XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов

            //XmlNodeList childnodes = xRoot.SelectNodes("*");
            //foreach (XmlNode n in childnodes)
            //{
            //    Console.WriteLine(n.OuterXml);
            //}

            //XmlNodeList childnodes = xRoot.SelectNodes("user");
            //foreach (XmlNode n in childnodes)
            //    Console.WriteLine(n.SelectSingleNode("@name").Value);

            //XmlNode childnode = xRoot.SelectSingleNode("user[@name='Bill Gates']");
            //if (childnode != null)
            //    Console.WriteLine(childnode.OuterXml);

            //XmlNode childnode = xRoot.SelectSingleNode("user[company='Microsoft']");
            //if (childnode != null)
            //    Console.WriteLine(childnode.OuterXml);

            //XmlNodeList childnodes = xRoot.SelectNodes("//user/company");
            //foreach (XmlNode n in childnodes)
            //    Console.WriteLine(n.InnerText);















            //using var httpClient = new HttpClient();
            //byte[] imageBytes = await httpClient.GetByteArrayAsync("http://webcode.me/favicon.ico");
            //string localFilename = "C:\\test_favicon.ico";
            //Console.WriteLine(localFilename);
            //File.WriteAllBytes(localFilename, imageBytes);
        }
    }
}
