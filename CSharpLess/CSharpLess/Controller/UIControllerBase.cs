using CSharpLess.Scene;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSharpLess.Controller
{
    public abstract class UIControllerBase : ControllerBase
    {
        private readonly TaskCompletionSource _tcs = new TaskCompletionSource();
        private readonly SceneManager _sceneManager;

        public UIControllerBase(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        public override Task Run()
        {
            RunInternal();
            return _tcs.Task;
        }

        protected abstract void RunInternal();

        protected async Task<T> CreateAndShowPage<T>() where T : Page, new()
        {
            var page = new T();
            await _sceneManager.Show(page);
            return page;
        }

        protected Task HidePage(Page page)
        {
            return _sceneManager.Hide(page);
        }

        public override void Dispose()
        {
            _tcs.TrySetResult();
        }
    }
}
