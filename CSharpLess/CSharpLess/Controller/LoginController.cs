using CSharpLess.View;
using ShopModel.Model;

namespace CSharpLess.Controller
{
    public class LoginController : UIControllerBase
    {
        private readonly UserCredentialsService _credentialsService;
        private LoginPage _loginPage;

        public LoginController() : base()
        {
            _credentialsService = new UserCredentialsService();
        }

        protected override async void RunInternal()
        {
            _loginPage = await CreateAndShowPage<LoginPage>();
            _loginPage.LoginEvent += OnLogin;
        }

        private async void OnLogin(string login, string pass)
        {
            var isUserCorrect = await _credentialsService.TryLogin(login, pass);
            if (isUserCorrect)
            {
                Dispose();
            }
            else
            {
                _loginPage.ShowCredentialsError();
            }
        }

        public override async void Dispose()
        {
            _loginPage.LoginEvent -= OnLogin;
            await HidePage(_loginPage);
            base.Dispose();
        }
    }
}
