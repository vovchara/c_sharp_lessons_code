using CSharpLess.Scene;
using CSharpLess.View;
using ShopModel.Model;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class LoginController : ControllerBase
    {
        private readonly IUserCredentialsService _credentialsService;
        private LoginPage _loginPage;
        private readonly TaskCompletionSource _tcs = new TaskCompletionSource();

        public LoginController(ISceneManager sceneManager, IUserCredentialsService credentialsService) : base(sceneManager)
        {
            _credentialsService = credentialsService;
        }

        public override async Task Run()
        {
            _loginPage = await CreateAndShowPage<LoginPage>(); //_loginPage = new LoginPage(); //await _sceneManager.Show(_loginPage); //було
            _loginPage.LoginEvent += OnLogin;
            
            await _tcs.Task;
        }

        private async void OnLogin(string login, string pass)
        {
            var isUserCorrect = await _credentialsService.TryLogin(login, pass);
            if (isUserCorrect)
            {
                _tcs.TrySetResult(); //відпускаємо таск і логіка там де визивали await Run() йде далі.
                Dispose();
            }
            else
            {
                _loginPage.ShowIncorrectCredentials();
            }
        }

        public override async void Dispose()
        {
            if (_loginPage != null)
            {
                _loginPage.LoginEvent -= OnLogin;
                await HidePage(_loginPage); //_sceneManager.Hide(_loginPage); //було
            }
        }
    }
}
