using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class WelcomeScreen : UserControl, IWelcomeView
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        public event Action WestClicked = delegate { };
        public event Action CentralClicked = delegate { };
        public event Action AdminClicked = delegate { };

        private void westBtn_Click(object sender, EventArgs e)
        {
            WestClicked();
        }

        private void centralBtn_Click(object sender, EventArgs e)
        {
            CentralClicked();

            var but = new Button();
            but.Size = new Size(200, 200);
            but.Location = new Point(300, 400);
            //but.Click += (s, e) => Parent.Text = "AAAAAAAAA";
            but.Click += OnCentCl;
            Controls.Add(but);
        }

        private void OnCentCl(object sender, EventArgs e)
        {
            (sender as Button).Text = "AAAAAAAAA";
            (sender as Button).Click -= OnCentCl;
            Controls.Remove(sender as Button);
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            AdminClicked();
        }

        public Control GetScene => this;
    }
}
