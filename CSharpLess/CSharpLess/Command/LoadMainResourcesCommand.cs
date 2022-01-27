using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess.Command
{
    public class LoadMainResourcesCommand
    {
        public async Task<bool> Execute()
        {
            try
            {
                await DownloadSomeImage();
                //maybe download some more stuff
            }
            catch (Exception ex)
            {
                //something went wrong
                return false;
            }

            return true;
        }

        private async Task DownloadSomeImage()
        {
            using (WebClient webClient = new WebClient())
            {
                await webClient.DownloadFileTaskAsync(new Uri("https://images.pexels.com/photos/1525041/pexels-photo-1525041.jpeg?cs=srgb&dl=pexels-francesco-ungaro-1525041.jpg"), "image.jpg");
            }
        }
    }
}
