using CSharpLess.Scene;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSharpLess.Controller
{
    public abstract class ControllerBase : IDisposable
    {
        protected readonly ISceneManager _sceneManager;

        public ControllerBase(ISceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        protected async Task<T> CreateAndShowPage<T>() where T : Page, new()
        {
            var page = new T();
            await _sceneManager.Show(page);
            return page;
        }

        protected Task HidePage(Page page)
        {
            if (page != null)
            {
                return _sceneManager.Hide(page);
            }
            return Task.CompletedTask;
        }

        public abstract void Dispose();

        public abstract Task Run();

    }
}
