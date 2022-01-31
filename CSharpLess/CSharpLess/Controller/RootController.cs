using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class RootController : ControllerBase
    {
        private readonly IImagesService _imagesService;
        private readonly SceneManager _sceneManager;
        private readonly ControllerFactory _controllerFactory;
        public RootController(ControllerFactory controllerFactory, SceneManager sceneManager, IImagesService imagesService)
        {
            _controllerFactory = controllerFactory;
            _imagesService = imagesService;
            _sceneManager = sceneManager;
        }

        public override async Task Run()
        {
            //показуємо бублік
            var loading = new LoadingCirclePage();
            await _sceneManager.Show(loading);
            
            //грузим базові реси, картінки і т д
            var isLoaded = await _imagesService.TryDownloadBaseImages();
            //ховаєм бублік
            await _sceneManager.Hide(loading);

            if (!isLoaded)
            {
                //тут можна еррор попап показати
                return;
            }
            //показуємо логін
            var loginController = _controllerFactory.Create<LoginController>();
            await loginController.Run();

            //включаємо хом пейдж контроллер
            var homeController = _controllerFactory.Create<HomeController>();
            await homeController.Run();
        }

        public override void Dispose()
        {
        }
    }
}
