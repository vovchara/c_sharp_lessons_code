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
    public partial class AdminScreen : UserControl, IAdminView
    {
        public Control GetScene => this;

        public AdminScreen()
        {
            InitializeComponent();
        }

        public event Action<string, string> OkClicked = delegate { };
        public event Action BackClicked = delegate { };

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var userName = userTxt.Text;
            var pass = passTxt.Text;
            OkClicked(userName, pass);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            BackClicked();
        }

        public void ShowPassIncorrect(string errorText)
        {
            errorTxt.Visible = true;
            errorTxt.Text = errorText;
        }
    }
}
