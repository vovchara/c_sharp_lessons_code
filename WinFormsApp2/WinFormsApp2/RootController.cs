using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    class RootController
    {
        private readonly Form _scene;
        private readonly IWelcomeView _welcomeView;
        private readonly AdminController _adminController;

        public RootController(Form scene)
        {
            _scene = scene;
            _welcomeView = new WelcomeScreen();
            _adminController = new AdminController(_scene);
        }

        public void Start()
        {
            _welcomeView.AdminClicked += AdminHandler;
            _welcomeView.CentralClicked += CentralHandler;
            _welcomeView.WestClicked += WestHadnler;
            
            _scene.Controls.Add(_welcomeView.GetScene);
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
        }

        private void BackFromAdmin()
        {
            _adminController.Back -= BackFromAdmin;
            _adminController.Stop();
        }
    }
}
