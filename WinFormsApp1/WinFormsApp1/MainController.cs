using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class MainController
    {
        private readonly Form _mainForm;

        public MainController(Form mainForm)
        {
            _mainForm = mainForm;
        }

        public void Run()
        {
            Button helloButton = new Button();
            helloButton.BackColor = Color.LightGray;
            helloButton.ForeColor = Color.DarkGray;
            helloButton.Location = new Point(10, 10);
            helloButton.Text = "Привет";
            _mainForm.Controls.Add(helloButton);
            helloButton.Click += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e)
        {
            _mainForm.Text = "OOOOOOO";
            var myForm = new UserControl1();
            myForm.Name = "AAAAAAAAAAAAA";
            _mainForm.Controls.Add(myForm);
        }
    }
}
