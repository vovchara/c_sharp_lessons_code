using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpLess.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public event Action<string, string> LoginEvent = delegate { };
        public LoginPage()
        {
            InitializeComponent();

            LoginBtn.Click += OnLoginClicked;
        }

        private void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            if (LoginInputTxt.Text == null || PassInputTxt.Text == null)
            {
                return;
            }
            LoginEvent(LoginInputTxt.Text, PassInputTxt.Text);
        }

        public void ShowIncorrectCredentials()
        {
            MessageBox.Show("Incorrect credentials!!!");
        }
    }
}
