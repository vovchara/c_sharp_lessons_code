using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopModel.Model
{
    public class ImagesService : IImagesService
    {
        public async Task<bool> TryDownloadBaseImages()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var fileBytes = await client.GetByteArrayAsync("https://images.pexels.com/photos/3791466/pexels-photo-3791466.jpeg");
                    await File.WriteAllBytesAsync("image3.jpeg", fileBytes);
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
