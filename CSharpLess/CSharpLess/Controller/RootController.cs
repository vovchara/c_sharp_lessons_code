using CSharpLess.Command;
using CSharpLess.Loading;
using CSharpLess.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSharpLess.Controller
{
    public class RootController : ControllerBase
    {
        private readonly LoadMainResourcesCommand _loadMainResourcesCommand;
        public RootController(Frame rootFrame)
        {
            SceneManager.GetInstance().SetRootFrame(rootFrame);
            _loadMainResourcesCommand = new LoadMainResourcesCommand();
        }

        public override async Task Run()
        {
            //loading screen show
            LoadingElementManager.GetInstance().ShowLoading();
            //load required resources
            var isLoaded = await _loadMainResourcesCommand.Execute();
            //hide loading
            LoadingElementManager.GetInstance().HideLoading();
            if (!isLoaded)
            {
                //here we can show error popup and close application.
                return;
            }
            //await Task.Delay(1);
            //show login page
            var loginController = new LoginController();
            await loginController.Run();
            //show home page
        }

        public override void Dispose()
        {
        }
    }
}
