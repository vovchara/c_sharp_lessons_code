using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class CategoriesService
    {
        public async Task<CategoryModel[]> GetAllCategories()
        {
            var storage = CategoriesStorage.GetInstance();
            if (storage.Categories == null)
            {
                storage.Categories = await LoadJson();
            }
            
            return storage.Categories;
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
