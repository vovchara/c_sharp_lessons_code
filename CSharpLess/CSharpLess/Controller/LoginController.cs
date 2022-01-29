using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class LoginController : ControllerBase
    {
        private readonly SceneManager _sceneManager;
        private readonly UserCredentialsService _credentialsService;
        private LoginPage _loginPage;

        public LoginController()
        {
            _sceneManager = SceneManager.GetInstance();
            _credentialsService = new UserCredentialsService();
        }

        public override async Task Run()
        {
            _loginPage = new LoginPage();
            _loginPage.LoginEvent += OnLogin;
            await _sceneManager.Show(_loginPage);
        }

        private async void OnLogin(string login, string pass)
        {
            var isUserCorrect = await _credentialsService.TryLogin(login, pass);
        }

        public override void Dispose()
        {
            _loginPage.LoginEvent -= OnLogin;
        }
    }
}
