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
    public partial class InfoView : UserControl, IInfoView
    {
        public InfoView()
        {
            InitializeComponent();
        }

        public Control Scene => this;

        public event Action BackClicked = delegate { };
        public event Action ShowAllClicked = delegate { };
        public event Action<int> FindByIdClicked = delegate { };
        public event Action<string> FindByDestinationClicked = delegate { };

        private void backBtn_Click(object sender, EventArgs e)
        {
            BackClicked();
        }

        private void findByIdBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tripIdInputTxt.Text, out var num) && num > 0)
            {
                FindByIdClicked(num);
            }
            else
            {
                tripIdInputTxt.PlaceholderText = "ТІЛЬКИ ЦИФРИ!";
            }
        }

        private void findByDestination_Click(object sender, EventArgs e)
        {

        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            ShowAllClicked();
        }
    }
}
