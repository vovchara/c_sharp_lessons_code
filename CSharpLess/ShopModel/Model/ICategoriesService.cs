using System.Threading.Tasks;

namespace ShopModel.Model
{
    public interface ICategoriesService
    {
        Task<CategoryModel[]> GetAllCategories();
    }
}
