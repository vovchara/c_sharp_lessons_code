using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSharpLess.Scene
{
    public class SceneManager
    {
        private static SceneManager _instance;

        public static SceneManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SceneManager();
            }
            return _instance;
        }
        private SceneManager()
        {
            _pagesStack = new Stack<Page>();
            _empty = new Page();
        }

        private readonly Stack<Page> _pagesStack;
        private readonly Page _empty;
        private Frame _rootFrame;

        public void SetRoot(Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public Task Show(Page page)
        {
            if (_rootFrame.Content != null && _rootFrame.Content != _empty)
            {
                _pagesStack.Push(_rootFrame.Content as Page);
            }

            return ShowInternal(page);
        }

        private Task ShowInternal(Page page)
        {
            var tcs = new TaskCompletionSource();
            void ContentReady(object sender, EventArgs e)
            {
                _rootFrame.ContentRendered -= ContentReady;
                tcs.TrySetResult();
            }
            _rootFrame.Content = page;
            _rootFrame.ContentRendered += ContentReady;
            return tcs.Task;
        }

        public async Task Hide(Page page)
        {
            if (_rootFrame.Content != page)
            {
                return;
            }
            await ShowInternal(_empty);
            if (_pagesStack.Count > 0)
            {
                await Show(_pagesStack.Pop());
            }
        }
    }
}
