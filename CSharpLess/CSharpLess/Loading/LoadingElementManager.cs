using CSharpLess.Scene;

namespace CSharpLess.Loading
{
    public class LoadingElementManager
    {
        private static LoadingElementManager _instance;

        public static LoadingElementManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoadingElementManager();
            }
            return _instance;
        }

        private readonly LoadingElementPage _loadingElement;
        private bool _isShown;

        private LoadingElementManager()
        {
            _loadingElement = new LoadingElementPage();
        }

        public void ShowLoading()
        {
            if (_isShown)
            {
                return;
            }
            _isShown = true;
            SceneManager.GetInstance().ShowPage(_loadingElement);
        }

        public void HideLoading()
        {
            if (!_isShown)
            {
                return;
            }
            _isShown = false;
            SceneManager.GetInstance().HidePage(_loadingElement);
        }
    }
}
