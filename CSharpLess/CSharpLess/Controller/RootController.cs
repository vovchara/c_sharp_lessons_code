using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class RootController : ControllerBase
    {
        private readonly IImagesService _imagesService;
        private readonly LoginController _loginController;
        private readonly HomeController _homeController;

        public RootController(ISceneManager sceneManager,
            LoginController loginController,
            IImagesService imagesService,
            HomeController homeController)
            : base(sceneManager)
        {
            _loginController = loginController;
            _imagesService = imagesService;
            _homeController = homeController;
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
            await _loginController.Run();

            //включаємо хом пейдж контроллер
            await _homeController.Run();
        }


        public override void Dispose()
        {
        }
    }
}
