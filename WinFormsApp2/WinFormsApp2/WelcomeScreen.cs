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
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            AdminClicked();
        }

        public Control GetScene => this;
    }
}
