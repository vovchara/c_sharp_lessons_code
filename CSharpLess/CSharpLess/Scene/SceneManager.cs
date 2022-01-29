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
        public void SetRoot(Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public async Task Show(Page page)
        {
            _rootFrame.Content = page;
            await Task.Delay(5);
        }

        public void Hide(Page page)
        {
            if (_rootFrame.Content == page)
            {
                _rootFrame.Content = null;
            }
        }
    }
}
