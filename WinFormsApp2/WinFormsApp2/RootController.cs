using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    class RootController : ControllerBase
    {
        private readonly IWelcomeView _welcomeView;
        private readonly AdminController _adminController;

        public RootController(Form scene) : base(scene)
        {
            _welcomeView = new WelcomeScreen();
            _adminController = new AdminController(scene);
        }

        private void WestHadnler()
        {
        }

        private void CentralHandler()
        {
        }

        private void AdminHandler()
        {
            _adminController.Back += BackFromAdmin;
            _adminController.Start();
            RemoveChild(_welcomeView.GetScene);
        }

        private void BackFromAdmin()
        {
            _adminController.Back -= BackFromAdmin;
            _adminController.Stop();
            AddChild(_welcomeView.GetScene);
        }

        public override void Start()
        {
            _welcomeView.AdminClicked += AdminHandler;
            _welcomeView.CentralClicked += CentralHandler;
            _welcomeView.WestClicked += WestHadnler;

            AddChild(_welcomeView.GetScene);
        }

        public override void Stop()
        {
            _welcomeView.AdminClicked -= AdminHandler;
            _welcomeView.CentralClicked -= CentralHandler;
            _welcomeView.WestClicked -= WestHadnler;

            RemoveChild(_welcomeView.GetScene);
        }
    }
}
