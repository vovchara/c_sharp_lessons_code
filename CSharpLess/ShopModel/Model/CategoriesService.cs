using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class CategoriesService : ICategoriesService
    {
        private readonly CategoriesStorage _categoriesStorage;

        public CategoriesService(CategoriesStorage categoriesStorage)
        {
            _categoriesStorage = categoriesStorage;
        }

        public async Task<CategoryModel[]> GetAllCategories()
        {
            if (_categoriesStorage.Categories == null)
            {
                _categoriesStorage.Categories = await LoadJson();
            }
            
            return _categoriesStorage.Categories;
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
