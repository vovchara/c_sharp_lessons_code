using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class CategoriesService
    {
        private readonly CategoriesStorage _storage;

        public CategoriesService()
        {
            _storage = CategoriesStorage.GetInstance();
        }

        public async Task<CategoryModel[]> GetAllCategories()
        {
            if (_storage.Categories == null)
            {
                _storage.Categories = await LoadJson(); //save cache to not read file each time, only once
            }
            return _storage.Categories;
        }

        private async Task<CategoryModel[]> LoadJson()
        {
            using (StreamReader r = new StreamReader("categories.json"))
            {
                string json = await r.ReadToEndAsync();
                var items = JsonConvert.DeserializeObject<List<CategoryModel>>(json);
                return items.ToArray();
            }
        }
    }
}
