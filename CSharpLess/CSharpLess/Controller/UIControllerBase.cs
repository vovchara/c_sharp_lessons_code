using CSharpLess.Scene;
using System.Windows.Controls;

namespace CSharpLess.Controller
{
    public abstract class UIControllerBase : ControllerBase
    {
        protected T CreateAndShowPage<T>() where T : Page, new()
        {
            var page = new T();
            SceneManager.GetInstance().ShowPage(page);
            return page;
        }

        protected void HidePage(Page page)
        {
            SceneManager.GetInstance().HidePage(page);
        }
    }
}
