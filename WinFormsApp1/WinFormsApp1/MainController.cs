using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class MainController
    {
        private readonly Form root;
        private readonly IMainView _mainView;
        private readonly InfoController _infoController;

        public MainController(Form rootForm)
        {
            root = rootForm;
            _mainView = new MainView();
            _mainView.InfoClicked += OnInfoClicked;
            _mainView.AdminClicked += OnAdminClicked;

            _infoController = new InfoController();
            _infoController.BackClicked += OnBackFromInfoClicked;
        }

        private void OnInfoClicked()
        {
            _infoController.Run();
            root.Controls.Add(_infoController.Scene);
            _infoController.Scene.BringToFront(); // в ідеалі краще не класти на верх, а робити щоб на екрані завжди був лиш один скрін, всі інши - прибирати.
        }

        private void OnBackFromInfoClicked()
        {
            _infoController.Stop();
            root.Controls.Remove(_infoController.Scene);
        }

        private void OnAdminClicked()
        {

        }

        public void Run()
        {
            root.Controls.Add(_mainView.Scene);
        }
    }
}
