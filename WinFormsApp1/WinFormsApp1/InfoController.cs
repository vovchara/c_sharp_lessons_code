using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class InfoController
    {
        public Control Scene => _infoView.Scene;

        public event Action BackClicked = delegate { };

        private readonly IInfoView _infoView;

        public InfoController()
        {
            _infoView = new InfoView();
        }

        public void Run()
        {
            _infoView.BackClicked += BackHandler;
        }

        public void Stop()
        {
            _infoView.BackClicked -= BackHandler;
        }

        private void BackHandler()
        {
            BackClicked();
        }
    }
}
