using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class AdminController : ControllerBase
    {
        public event Action Back = delegate { };

        private readonly IAdminView _adminView;
        private const string user = "admin";
        private const string pass = "qwerty";

        public AdminController(Form scene) : base(scene)
        {
            _adminView = new AdminScreen();
        }

        public override void Start()
        {
            _adminView.BackClicked += BackHandler;
            _adminView.OkClicked += OkHandler;
            AddChild(_adminView.GetScene);
        }

        public override void Stop()
        {
            _adminView.BackClicked -= BackHandler;
            _adminView.OkClicked -= OkHandler;
            RemoveChild(_adminView.GetScene);
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
