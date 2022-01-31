using System;
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
        }

        private Frame _rootFrame;
        private readonly Page _empty = new Page();

        public void SetRoot(Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public Task Show(Page page)
        {
            var tcs = new TaskCompletionSource(); //для того щоб відпустити await Show лише тоді як контент відрендериться на екрані.
            void OnContentReady(object sender, EventArgs e) //локальний хендлер щоб можна було кожному виклику Show давати свій власний хендлер та відписуватись всередині нього.
            {
                _rootFrame.ContentRendered -= OnContentReady;
                tcs.TrySetResult();
            }
            _rootFrame.Content = page;
            _rootFrame.ContentRendered += OnContentReady;
            return tcs.Task;
        }

        public Task Hide(Page page)
        {
            if (_rootFrame.Content != page)
            {
                //log error
                return Task.CompletedTask;
            }

            return Show(_empty);
        }
    }
}
