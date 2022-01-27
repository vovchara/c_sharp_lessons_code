using CSharpLess.View;
using MyShopLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLess.Controller
{
    public class LoginController : UIControllerBase
    {
        private LoginPage _loginPage;
        private readonly TaskCompletionSource _tcs = new TaskCompletionSource();
        private readonly UserCredentialService _credentialService = new UserCredentialService();
        public override Task Run()
        {
            _loginPage = CreateAndShowPage<LoginPage>();
            _loginPage.LoginEvent += OnLoginClicked;
            return _tcs.Task;
        }

        private async void OnLoginClicked(UserCredModel model)
        {
            var isCorrectCred = await _credentialService.TryLogin(model);
            if (isCorrectCred)
            {
                //closing login 
                Dispose();
            }
        }

        public override void Dispose()
        {
            _loginPage.LoginEvent -= OnLoginClicked;
            HidePage(_loginPage);
            _tcs.TrySetResult();
        }
    }
}
