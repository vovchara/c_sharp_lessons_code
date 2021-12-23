using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MongoDBConsole0.model
{
    public class ProductService
    {
        IGridFSBucket gridFS;   // файловое хранилище
        IMongoCollection<ProductModel> Products; // коллекция в базе данных
        public ProductService()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017/mobilestore";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
            // обращаемся к коллекции Products
            Products = database.GetCollection<ProductModel>("Products");
        }
        // получаем все документы, используя критерии фальтрации
        public async Task<IEnumerable<ProductModel>> GetProducts(int? minPrice, int? maxPrice, string name)
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<ProductModel>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            // фильтр по имени
            if (!String.IsNullOrWhiteSpace(name))
            {
                filter = filter & builder.Regex("Name", new BsonRegularExpression(name));
            }
            if (minPrice.HasValue)  // фильтр по минимальной цене
            {
                filter = filter & builder.Gte("Price", minPrice.Value);
            }
            if (maxPrice.HasValue)  // фильтр по максимальной цене
            {
                filter = filter & builder.Lte("Price", maxPrice.Value);
            }

            return await Products.Find(filter).ToListAsync();
        }

        // получаем один документ по id
        public async Task<ProductModel> GetProduct(string id)
        {
            return await Products.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        // добавление документа
        public async Task Create(ProductModel p)
        {
            await Products.InsertOneAsync(p);
        }
        // обновление документа
        public async Task Update(ProductModel p)
        {
            await Products.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        // удаление документа
        public async Task Remove(string id)
        {
            await Products.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
        // получение изображения
        public async Task<byte[]> GetImage(string id)
        {
            return await gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }
        // сохранение изображения
        public async Task StoreImage(string id, Stream imageStream, string imageName)
        {
            ProductModel p = await GetProduct(id);
            if (p.HasImage())
            {
                // если ранее уже была прикреплена картинка, удаляем ее
                await gridFS.DeleteAsync(new ObjectId(p.ImageId));
            }
            // сохраняем изображение
            ObjectId imageId = await gridFS.UploadFromStreamAsync(imageName, imageStream);
            // обновляем данные по документу
            p.ImageId = imageId.ToString();
            var filter = Builders<ProductModel>.Filter.Eq("_id", new ObjectId(p.Id));
            var update = Builders<ProductModel>.Update.Set("ImageId", p.ImageId);
            await Products.UpdateOneAsync(filter, update);
        }
    }
}
