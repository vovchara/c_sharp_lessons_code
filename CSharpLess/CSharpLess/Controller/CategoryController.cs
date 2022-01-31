using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class CategoryController : UIControllerBase
    {
        private readonly CategoryModel _model;
        private CategoryPage _categoryPage;

        public CategoryController(SceneManager sceneManager, CategoryModel model) : base(sceneManager)
        {
            _model = model;
        }

        protected override async void RunInternal()
        {
            _categoryPage = await CreateAndShowPage<CategoryPage>();
            _categoryPage.SetData(_model);
            _categoryPage.BackClicked += BackHandler;
            _categoryPage.AddGoodClicked += AddGoodToCart;
        }

        private void AddGoodToCart(GoodsItemModel good)
        {
            //todo save this item to user cart
        }

        private async void BackHandler()
        {
            _categoryPage.BackClicked -= BackHandler;
            _categoryPage.AddGoodClicked -= AddGoodToCart;
            await HidePage(_categoryPage);
            Dispose();
        }
    }
}
