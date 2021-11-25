using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainView : UserControl, IMainView
    {
        public Control Scene => this;

        public MainView()
        {
            InitializeComponent();
        }

        public event Action InfoClicked = delegate { };
        public event Action AdminClicked = delegate { };

        private void infoButton_Click(object sender, EventArgs e)
        {
            InfoClicked();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminClicked();
        }
    }
}
