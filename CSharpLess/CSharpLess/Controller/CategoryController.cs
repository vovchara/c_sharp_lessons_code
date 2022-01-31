using CSharpLess.View;
using ShopModel.Model;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class CategoryController : ControllerBase
    {
        private readonly TaskCompletionSource _tcs = new TaskCompletionSource();
        private readonly CategoryModel _category;
        private CategoryPage _categoryPage;

        public CategoryController(CategoryModel category)
        {
            _category = category;
        }

        public override async Task Run()
        {
            _categoryPage = await CreateAndShowPage<CategoryPage>();
            _categoryPage.SetData(_category);
            _categoryPage.BackClicked += BackHandler;
            await _tcs.Task;
        }

        private void BackHandler()
        {
            Dispose();
        }

        public override async void Dispose()
        {
            if (_categoryPage != null)
            {
                _categoryPage.BackClicked -= BackHandler;
                await HidePage(_categoryPage);
            }
            _tcs.TrySetResult();
        }
    }
}
