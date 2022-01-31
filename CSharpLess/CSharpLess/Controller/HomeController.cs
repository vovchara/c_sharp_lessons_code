using CSharpLess.View;
using ShopModel.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class HomeController : ControllerBase
    {
        private HomePage _homePage;
        private UserSessionStorage _sessionStorage;
        private CategoriesService _categoriesService;
        private CategoryModel[] _categories;
        public HomeController()
        {
            _sessionStorage = UserSessionStorage.GetInstance();
            _categoriesService = new CategoriesService();
        }

        public override async Task Run()
        {
            //todo show loading
            _categories = await _categoriesService.GetAllCategories();
            //todo hide loading
            _homePage = await CreateAndShowPage<HomePage>();
            _homePage.SetUser(_sessionStorage.GetUser.NickName);
            _homePage.SetCategories(_categories);
            _homePage.CategoryClicked += CategorySelectedHandler;
        }

        private async void CategorySelectedHandler(int catId)
        {
            var selectedCat = _categories.FirstOrDefault(c => c.Id == catId);
            if (selectedCat == null)
            {
                return;
            }
            var categoryController = new CategoryController(selectedCat);
            await categoryController.Run();
            await _sceneManager.Show(_homePage);
        }

        public override async void Dispose()
        {
            if (_homePage != null)
            {
                _homePage.CategoryClicked -= CategorySelectedHandler;
                await HidePage(_homePage);
            }
        }
    }
}