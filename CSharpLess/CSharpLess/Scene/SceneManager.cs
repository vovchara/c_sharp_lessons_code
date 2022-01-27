using System.Collections.Generic;
using System.Windows.Controls;

namespace CSharpLess.Scene
{
    public class SceneManager
    {
        private static SceneManager _instance;
        private SceneManager()
        {
        }
        public static SceneManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SceneManager();
            }
            return _instance;
        }

        private Frame _rootFrame;
        private Page _currentContent;
        private readonly Stack<Page> _pagesStack = new Stack<Page>();

        public void SetRootFrame(Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public void ShowPage(Page page)
        {
            if (_currentContent != null)
            {
                _pagesStack.Push(_currentContent);
            }
            SetCurrentContent(page);
        }

        public void HidePage(Page page)
        {
            if (_currentContent != page)
            {
                //incorrect removing, anothe popup on screen!
                return;
            }
            SetCurrentContent(null);
            if (_pagesStack.Count > 0)
            {
                SetCurrentContent(_pagesStack.Pop());
            }
        }

        private void SetCurrentContent(Page page)
        {
            _currentContent = page;
            _rootFrame.Content = page;
        }
    }
}
