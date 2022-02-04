using System.Threading.Tasks;

namespace ShopModel.Model
{
    public interface IImagesService
    {
        Task<bool> TryDownloadBaseImages();
    }
}
