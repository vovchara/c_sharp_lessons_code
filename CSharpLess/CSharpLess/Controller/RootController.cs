using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class RootController : ControllerBase
    {
        private readonly ImagesService _imagesService;
        public RootController()
        {
            _imagesService = new ImagesService();
        }

        public override async Task Run()
        {
            //показуємо бублік
            var loading = new LoadingCirclePage();
            await SceneManager.GetInstance().Show(loading);
            
            //грузим базові реси, картінки і т д
            var isLoaded = await _imagesService.TryDownloadBaseImages();
            //ховаєм бублік
            await SceneManager.GetInstance().Hide(loading);

            if (!isLoaded)
            {
                //тут можна еррор попап показати
                return;
            }
            //показуємо логін
            var loginController = new LoginController();
            await loginController.Run();

            //включаємо хом пейдж контроллер
            var homeController = new HomeController();
            await homeController.Run();
        }

        public override void Dispose()
        {
        }
    }
}
