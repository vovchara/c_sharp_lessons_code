using CSharpLess.View;
using ShopModel.Model;
using System;
using System.Linq;

namespace CSharpLess.Controller
{
    public class HomeController : UIControllerBase
    {
        private readonly CategoriesService _categoriesService;
        private readonly UserSessionStorage _sessionStorage;
        private HomePage _homePage;
        private CategoryModel[] _categories;

        public HomeController()
        {
            _categoriesService = new CategoriesService();
            _sessionStorage = UserSessionStorage.GetInstance();
        }

        protected override async void RunInternal()
        {
            _categories = await _categoriesService.GetAllCategories();
            _homePage = await CreateAndShowPage<HomePage>();
            _homePage.SetUserName(_sessionStorage.GetUser.NickName);
            _homePage.SetCategories(_categories);
            _homePage.CategorySelected += OnCategorySelected;
        }

        private async void OnCategorySelected(int catId)
        {
            if (_categories == null)
            {
                return;
            }
            var cat = _categories.FirstOrDefault(c => c.Id == catId);
            var categoryController = new CategoryController(cat);
            await categoryController.Run();
        }

        public override void Dispose()
        {
            if (_homePage != null)
            {
                _homePage.CategorySelected -= OnCategorySelected;
            }
            base.Dispose();
        }
    }
}
