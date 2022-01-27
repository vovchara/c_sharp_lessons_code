using MyShopLib.Model;
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
        public event Action<UserCredModel> LoginEvent = delegate { };
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
            var user = new UserCredModel(LoginInputTxt.Text, PassInputTxt.Text);
            LoginEvent(user);
        }
    }
}
