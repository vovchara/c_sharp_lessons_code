using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonDbCons0.model
{
    class PhonesDbService
    {
        private IMongoCollection<PhoneModel> Phones; // коллекция в базе данных
        IGridFSBucket gridFS;   // файловое хранилище
        private readonly IMongoDatabase _db;
        public PhonesDbService()
        {
            // строка подключения
            var connectionString = "mongodb://localhost:27017/moblesson";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            var client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            _db = client.GetDatabase(connection.DatabaseName);
            Phones = _db.GetCollection<PhoneModel>("Phones");
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(_db);
        }

        // сохранение изображения
        public void StoreImage(string id, byte[] imageBytes, string imageName)
        {
            var phoneModel = Get(id);
            if (phoneModel.HasImage())
            {
                // если ранее уже была прикреплена картинка, удаляем ее
                gridFS.Delete(new ObjectId(phoneModel.ImageId));
            }
            // сохраняем изображение
            var imageId = gridFS.UploadFromBytes(imageName, imageBytes);
            // обновляем данные по документу
            phoneModel.ImageId = imageId.ToString();

            var filter = Builders<PhoneModel>.Filter.Eq("_id", new ObjectId(phoneModel.Id));
            var update = Builders<PhoneModel>.Update.Set("ImageId", phoneModel.ImageId);
            Phones.UpdateOne(filter, update);
        }

        public byte[] GetImage(PhoneModel phone)
        {
            var bytesImg = gridFS.DownloadAsBytes(new ObjectId(phone.ImageId));
            return bytesImg;
        }

        // добавление документа
        public void Create(PhoneModel phone)
        {
            Phones.InsertOne(phone);
        }

        // получаем один документ по id
        public PhoneModel Get(string id)
        {
            return Phones.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefault();
        }

        // обновление документа
        public void Update(PhoneModel p)
        {
            Phones.ReplaceOne(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }

        // удаление документа
        public void Remove(string id)
        {
            Phones.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
        }

        public void ShowCollection()
        {
            var names = _db.ListCollectionNames().ToList();
            foreach(var name in names)
            {
                Console.WriteLine($"Collection: {name}");
            }
        }
    }
}
