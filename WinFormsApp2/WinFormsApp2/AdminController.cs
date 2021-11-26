using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class AdminController
    {
        public event Action Back = delegate { };

        private readonly IAdminView _adminView;
        private readonly Form _scene;
        private const string user = "admin";
        private const string pass = "qwerty";

        public AdminController(Form scene)
        {
            _scene = scene;
            _adminView = new AdminScreen();
        }

        public void Start()
        {
            _adminView.BackClicked += BackHandler;
            _adminView.OkClicked += OkHandler;
            _scene.Controls.Add(_adminView.GetScene);
            _adminView.GetScene.BringToFront();
        }

        public void Stop()
        {
            _adminView.BackClicked -= BackHandler;
            _adminView.OkClicked -= OkHandler;
            _scene.Controls.Remove(_adminView.GetScene);
        }

        private void OkHandler(string u, string p)
        {
            if (u == user && p == pass)
            {
                //open editing screen
            }
            else
            {
                _adminView.ShowPassIncorrect("INCORRECT LOG OR PASS!!!");
            }
        }

        private void BackHandler()
        {
            Back();
        }
    }
}
